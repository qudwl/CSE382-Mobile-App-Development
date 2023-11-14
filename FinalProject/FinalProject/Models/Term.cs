using System;
using Newtonsoft.Json;
namespace FinalProject.Models
{
	public class Term
	{
		[JsonProperty("termId")]
		public int id;
		[JsonProperty("name")]
		public string label;
		public string startDate;
		public string endDate;

        public override string ToString()
        {
            return label;
        }
    }
}

