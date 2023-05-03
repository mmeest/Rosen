using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rosen.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FLName { get; set; }
        public string Phone { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
