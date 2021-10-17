using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Driver;
using MongoDbGenericRepository.Attributes;

namespace mongoExample.Models
{
    [CollectionName("Role")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {
        
    }
}