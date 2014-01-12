using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SammoBackend.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        public string User_name { get; set; }

        // Location should only be updated when required
        public string Location { get; set; }

        public string[] tags { get; set; }

        public int SP { get; set; }

        public string Avatar_URL { get; set; }
    }
}