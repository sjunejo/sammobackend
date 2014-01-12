using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson.Serialization.Attributes;

namespace SammoBackend.Models
{
    public class Query
    {
        [BsonId]
        public string Id { get; set; }

        public string Title { get; set; }
        public string Location { get; set; }
        public string User_Id { get; set; }
        public string[] tags { get; set; }
    }
}