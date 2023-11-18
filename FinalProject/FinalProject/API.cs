using System;
using FinalProject.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
namespace FinalProject
{
    public class API
    {
        private const string BASE_URL = "https://ws.apps.miamioh.edu/api/";
        private const string TERM_API = "academicTerm/v2?numOfFutureTerms=2&numOfPastTerms=2";
        private const string CRN_API = "courseSection/v3/courseSection?crn=";
        private const string DEPARTMENT_API = "courseSection/v3/courseSection?campusCode=O&limit=20&termCode=";
        private const string COMPOSE_API = "&compose=%2Cschedules%2Cinstructors%2CenrollmentCount";
        private HttpClient httpClient;

        public API()
        {
            httpClient = new HttpClient();
        }

        public async Task<Term[]> GetTerms()
        {
            var res = await httpClient.GetAsync(BASE_URL + TERM_API);
            res.EnsureSuccessStatusCode();

            string result = await res.Content.ReadAsStringAsync();

            TermResponse tr = JsonConvert.DeserializeObject<TermResponse>(result);

            return tr!.terms;
        }
        public async Task<(List<Course>, bool)> GetCourseByDepartment(string departmentCode, string termCode, int offset)
        {
            List<Course> courseList = new List<Course>();
            CourseResponse cr;
            Course[] result;
            var res = await httpClient.GetAsync(
            BASE_URL +
            DEPARTMENT_API +
            termCode +
            COMPOSE_API +
            "&course_subjectCode=" +
            departmentCode +
            (offset > 0 ? "&offset=" +
            (offset * 20).ToString() : ""));
            res.EnsureSuccessStatusCode();

            string json_str = await res.Content.ReadAsStringAsync();

            cr = JsonConvert.DeserializeObject<CourseResponse>(json_str);

            result = new Course[cr.data.Length];
            for (int i = 0; i < cr.data.Length; i++)
            {
                Data data = cr.data[i];

                string instructor;
                if (data.Instructors.Length < 1) instructor = "Faculty";
                else instructor = data.Instructors.Where(data => data.IsPrimary)
                    .First().Person.InformalDisplayedName ?? "Faculty";

                Schedule[] schedules = parseSchedules(data.Schedules, Int32.Parse(data.Crn));

                result[i] = new Course(
                    data.Course.SubjectCode,
                    data.Course.Number,
                    Int32.Parse(data.Crn),
                    data.Title,
                    data.CourseSectionCode,
                    instructor,
                    data.Course.Description,
                    data.CreditHour,
                    data.EnrollmentCount.numberOfMax,
                    data.EnrollmentCount.numberOfCurrent,
                    data.SectionName,
                    schedules
                    );
                if (data.IsDisplayed && data.CourseSectionStatusCode == "A")
                {
                    courseList.Add(result[i]);
                    Console.WriteLine("Section Active");
                }
                else
                {
                    Console.WriteLine($"{data.IsDisplayed} {data.CourseSectionStatusCode}");
                }
                Console.WriteLine(data.Course.SubjectCode + data.Course.Number);
            }

            return (courseList, result.Length == 20);
        }
        private Schedule[] parseSchedules(ScheduleData[] datas, int crn)
        {
            List<Schedule> schedules = new List<Schedule>();

            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i].ScheduleTypeCode != "FEXM")
                {
                    Schedule schedule = new Schedule();
                    schedule.Crn = crn;
                    schedule.StartTime = datas[i].StartTime;
                    schedule.EndTime = datas[i].EndTime;
                    schedule.BuildingName = datas[i].BuildingName;
                    schedule.BuildingCode = datas[i].BuildingCode;
                    schedule.Days = datas[i].Days;
                    schedules.Add(schedule);
                }
            }

            return schedules.ToArray();
        }
    }
}

