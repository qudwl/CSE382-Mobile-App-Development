using System;
namespace FinalProject.Models
{
	public class Department
	{
        public string Value { get; set; }
        public string Label { get; set; }
        public override string ToString()
        {
            return Label;
        }
    }
}

