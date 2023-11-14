using System;
using Newtonsoft.Json;
namespace FinalProject.Models
{
	public class TermResponse
	{
		[JsonProperty("data")]
		public Term[] terms;
	}
}

