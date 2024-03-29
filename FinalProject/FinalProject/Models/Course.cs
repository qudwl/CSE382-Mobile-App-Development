﻿using Newtonsoft.Json;
using SQLite;
namespace FinalProject.Models
{
	[Table("Course")]
	public class Course
	{
		public string Subject { get; set; }
		public string Cid { get; set; }
		public string SectionName { get; set; }
		[PrimaryKey, Unique]
        public int Crn { get; set; }
        public string Title { get; set; }
        public string Section { get; set; }
        public string Instructor { get; set; }
        public string Description { get; set; }
		public string TermDescription { get; set; }
		public string CampusName { get; set; }
        public double Credits { get; set; }
        public int MaxStudents { get; set; }
        public int CurrentStudents { get; set; }
		[Ignore]
        public Schedule[] Schedules { get; set; }

        public Course() { }
		public Course(
			string subject,
			string cid,
			int crn,
			string title,
			string section,
			string instructor,
			string description,
			double credits,
			int maxStudents,
			int currentStudents,
			string sectionName,
			string termDescription,
			string campusName,
			Schedule[] schedules)
		{
			this.Subject = subject;
			this.Cid = cid;
			this.Crn = crn;
			this.Title = title;
			this.Section = section;
			this.Instructor = instructor;
			this.Description = description;
			this.Credits = credits;
			this.MaxStudents = maxStudents;
			this.CurrentStudents = currentStudents;
            this.Schedules = schedules;
			this.SectionName = sectionName;
			this.TermDescription = termDescription;
			this.CampusName = campusName;
		}

        public override string ToString()
        {
			return Title;
        }

		public string Times
		{
			get
			{
				return string.Join("\n", (object[]) Schedules);
			}
		}
    }
}

