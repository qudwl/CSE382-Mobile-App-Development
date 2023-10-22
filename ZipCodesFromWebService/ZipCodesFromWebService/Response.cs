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
        public string placeName;
        public string longitude;
        public string latitude;
        [JsonProperty("post code")]
        public string postCode;

        public override string ToString()
        {
            return $"{placeName} {longitude} {latitude} {postCode}";
        }
    }
}

