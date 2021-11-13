﻿using System;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace si_net_project_api
{
    public class DataModel
    {
        [BsonElement("Value")] 
        public double Value { get; set; }
        
        [BsonElement("Date")] 
        public DateTime DateTime { get; set; }
        
        [BsonElement("Hive")] 
        public int HiveId { get; set; }

        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DataModel()
        {
            
        }
    }
}