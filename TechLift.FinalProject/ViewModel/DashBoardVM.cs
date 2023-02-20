using System.Diagnostics.Contracts;

namespace TechLift.FinalProject.ViewModel
{
    public class DashBoardVM
    {
        public int TotalEmployee { get; set; }

        public List<DashBoardDepartmentVM> dashBoardDepartmentVMs { get; set; }

    }
    public class DashBoardDepartmentVM
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public int totalDepEmployee { get; set; }
    }
}
