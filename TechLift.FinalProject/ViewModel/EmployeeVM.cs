using System.ComponentModel.DataAnnotations;

namespace TechLift.FinalProject.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
