using System.ComponentModel.DataAnnotations;

namespace mongoExample.Models
{
    public class CoreIdentityWithMongoDB
    {
        [Required]
        public string name { get; set; }
    }
}