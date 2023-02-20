using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLift.FinalProject.Models;
using TechLift.FinalProject.ViewModel;

namespace TechLift.FinalProject.Controllers
{
    public class HomeController : Controller
    {
        protected readonly ApllicationDBContext _db;
        public HomeController(ApllicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var user = _db.Employees.ToList();

       
             var employees = _db.Employees.Include(x => x.Departments)
                .GroupBy(x => x.DepartmentId)
                .Select(s => new DashBoardDepartmentVM
             {
                 departmentId = s.FirstOrDefault().DepartmentId,
                 departmentName = s.FirstOrDefault().Departments.Name,
                 totalDepEmployee = s.Count()
             }).ToList();

            DashBoardVM dashBoardVM = new DashBoardVM();

            dashBoardVM.TotalEmployee = user.ToList().Count();
            dashBoardVM.dashBoardDepartmentVMs= employees;

            return View(dashBoardVM);
        }
        public IActionResult Policy()
        {
            return View();
        }
        public IActionResult TermAndCondition()
        {
            return View();
        }
    }
}
