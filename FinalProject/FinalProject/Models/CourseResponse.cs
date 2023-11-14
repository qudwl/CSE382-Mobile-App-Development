using System;
using Newtonsoft.Json;
namespace FinalProject.Models
{
    public class CourseResponse
    {
        public Data[] data;
    }

    public class Data
    {
        public string Crn { get; set; }
        public string Title { get; set; }
        public string SectionName { get; set; }
        public string CourseSectionCode { get; set; }
        [JsonProperty("creditHoursHigh")]
        public double CreditHour { get; set; }
        public bool IsDisplayed { get; set; }
        public string CourseSectionStatusCode { get; set; }
        public EnrollCount EnrollmentCount { get; set; }
        public CourseData Course { get; set; }
        public InstructorData[] Instructors { get; set; }
        public ScheduleData[] Schedules { get; set; }
    }

    public class CourseData
    {
        public string SubjectCode { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
    }
    public class EnrollCount
    {
        public int numberOfMax { get; set; }
        public int numberOfCurrent { get; set; }
        public int numberOfAvailable { get; set; }
    }

    public class ScheduleData
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Days { get; set; }
        public string ScheduleTypeCode { get; set; }
        public string BuildingCode { get; set; } 
        public string BuildingName { get; set; }
    }

    public class InstructorData
    {
        public bool IsPrimary { get; set; }
        public PersonData Person { get; set; }
    }

    public class PersonData
    {
        public string InformalDisplayedName { get; set; }
    }
}

