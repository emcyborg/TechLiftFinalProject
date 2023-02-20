using Microsoft.AspNetCore.Identity;

namespace TechLift.FinalProject.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
