using System;
namespace FinalProject.Models
{
	public class CrnResponse
	{
        public CrnData[] data { get; set; }
	}

	public class CrnData
	{
		public int Crn;
		public EnrollCount EnrollmentCount { get; set; }
	}
}

