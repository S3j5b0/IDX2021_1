using System;
using System.Collections.Generic;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Driver;
using System.Linq;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using Newtonsoft.Json.Converters;

namespace mongoExample.Models
{
    
    [CollectionName("Users")]
    
    public class ApplicationUser:MongoIdentityUser<Guid>
    {
        public List<string> friends { get; set; }


        public string password { get; set; }
        
        public EconomicModel EconomicModel { get; set; }
        public EnviormentModel EnviormentalStats { get; set; }
        public string status { get; set; }
        
        
        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
        [BsonRepresentation(BsonType.String)]     
        public color Color { get; set; }
        
    }
}