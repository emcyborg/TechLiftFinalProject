using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using TechLift.FinalProject.Models;
using TechLift.FinalProject.ViewModel;

namespace TechLift.FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        protected readonly ApllicationDBContext _db;
        public EmployeeController(ApllicationDBContext db)
        {
            _db = db;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetEmployeeDetail")]

        public JsonResult GetEmployeeDetail()
        {

            var employees = _db.Employees.Include(x => x.Departments).Select(s => new EmployeeVM
            {
                Id = s.Id,
                Name = s.Name,
                ContactNo = s.ContactNo,
                Email = s.Email,
                Designation = s.Designation,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.Departments.Name,
            }).ToList();


            return Json(employees);
        }


        [HttpGet("GetEmployeebyID")]

        public JsonResult GetEmployeebyID(int Id)
        {

            var employees = _db.Employees.Where(x => x.Id == Id).Include(x => x.Departments).Select(s => new EmployeeVM
            {
                Id = s.Id,
                Name = s.Name,
                ContactNo = s.ContactNo,
                Email = s.Email,
                Designation = s.Designation,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.Departments.Name,
            }).FirstOrDefault();


            return Json(employees);
        }


        [HttpPost("SaveEmployee")]
        public ActionResult SaveEmployee(EmployeeVM collection)
        {
            try
            {
                Employee vm = new Employee();
                vm.Name = collection.Name;
                vm.ContactNo = collection.ContactNo; 
                vm.Email = collection.Email;
                vm.Designation = collection.Designation;
                vm.DepartmentId = Convert.ToInt32(collection.DepartmentId);
                _db.Employees.Add(vm);
                var employee = _db.SaveChanges();

                return Json(vm);


            }
            catch
            {
                return View();
            }
        }
        [HttpPut("UpdateEmployee")]
        public ActionResult UpdateEmployee(EmployeeVM collection)
        {
            try
            {

                var vm = _db.Employees.FirstOrDefault(x => x.Id == collection.Id);
                vm.Name = collection.Name;
                vm.ContactNo = collection.ContactNo;
                vm.Email = collection.Email;
                vm.Designation = collection.Designation;
                vm.DepartmentId = Convert.ToInt32(collection.DepartmentId);
                _db.SaveChanges();

                return Json(vm);
            }
            catch
            {
                return View();
            }
        }
    }
}
