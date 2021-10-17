using System.ComponentModel.DataAnnotations;

namespace mongoExample.Models
{
    public enum color
    {
        green,
        yellow,
        red,
        none
    }
    public class User
    {

        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        
        public EconomicModel EconomicModel { get; set; }
        public EnviormentModel EnviormentalStats { get; set; }
        public string status { get; set; }
        
        public color Color { get; set; }
    }
}