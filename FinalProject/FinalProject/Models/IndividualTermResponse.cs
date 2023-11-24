using System;
using Newtonsoft.Json;
namespace FinalProject.Models
{
	public class IndividualTermResponse
	{
        [JsonProperty("data")]
        public Term term;
    }
}

