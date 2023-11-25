using System;
namespace FinalProject.Models
{
	public class Department
	{
        public string Value { get; set; }
        public string Label { get; set; }
        public string Icon { get
            {
                return Value.ToLower() + ".png";
            } }
        public override string ToString()
        {
            return Label;
        }
    }
}

