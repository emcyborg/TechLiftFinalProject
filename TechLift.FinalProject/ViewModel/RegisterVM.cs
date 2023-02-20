using System.ComponentModel.DataAnnotations;

namespace TechLift.FinalProject.ViewModel
{
    public class RegisterVM
    {
        [Required, MaxLength(50)]
        public string Firstname { get; set; }
     
        [Required, MaxLength(11)]
        public string PhoneNumber { get; set; }
       
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
