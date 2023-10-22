using System;
using Newtonsoft.Json;

namespace ZipCodesFromWebService
{
	public class Response
	{
		[JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonProperty("places")]
        public Place[] Places { get; set; }

        public override string ToString()
        {
            return Places.Length.ToString();
        }
    }

    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        [JsonProperty("post code")]
        public string postCode { get; set; }

        public override string ToString()
        {
            return $"{PlaceName} {longitude} {latitude} {postCode}";
        }
    }
}

