using System.ComponentModel.DataAnnotations;

namespace TechLift.FinalProject.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
