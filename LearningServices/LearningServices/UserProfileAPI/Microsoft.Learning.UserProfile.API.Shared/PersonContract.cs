using Newtonsoft.Json;
using System;

namespace Microsoft.Learning.UserProfile.API.Shared
{
    public class PersonContract
    {
        public string FirstName;
        public string LastName;
        [JsonProperty("id")]
        public string PUID;
    }
}
