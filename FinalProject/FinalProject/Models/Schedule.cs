using System;
using SQLite;
namespace FinalProject.Models
{
	[Table("Schedule")]
	public class Schedule
	{
		public string StartTime { get; set; }
		public string EndTime { get; set; }
        public string Days { get; set; }
        public string BuildingCode { get; set; }
        public string BuildingName { get; set; }
        public override string ToString()
        {
            string result = Days + " " + StartTime + "-" + EndTime;
            return result;
        }
    }
}

