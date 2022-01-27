using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace EnigmaServer1.models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

       
        public string UserName { get; set; }

        public string Password { get; set; }

        public Int32 __v { get; set; }
    }
}
