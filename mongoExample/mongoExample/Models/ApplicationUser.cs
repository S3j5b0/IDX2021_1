using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Driver;
using System.Linq;
using MongoDbGenericRepository.Attributes;


namespace mongoExample.Models
{
    
    [CollectionName("Users")]
    
    public class ApplicationUser:MongoIdentityUser<Guid>
    {
        public string penis { get; set; }

        
    }
}