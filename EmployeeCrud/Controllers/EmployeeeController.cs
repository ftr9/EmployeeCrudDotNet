using EmployeeCrud.Data;
using EmployeeCrud.Models;
using EmployeeCrud.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Controllers
{


    public class EmployeeeController : Controller
    {
        private readonly EmployeeCrudDbContext _employeeCrudDbContext;
        
        public EmployeeeController(EmployeeCrudDbContext dbCtx)
        {   
            this._employeeCrudDbContext = dbCtx;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            List<Employee> employeesList = await this._employeeCrudDbContext.Employees.ToListAsync();

            return View(employeesList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel addEmployeeReq)
        {
            Employee employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeReq.Name,
                Email = addEmployeeReq.Email,
                Salary = addEmployeeReq.Salary,
                DateOfBirth = addEmployeeReq.DateOfBirth,
                Department = addEmployeeReq.Department
            };
            await this._employeeCrudDbContext.Employees.AddAsync(employee);
            await this._employeeCrudDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async  Task<IActionResult> Details(Guid id)
        {
          var employee = await  this._employeeCrudDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Details(Employee updateEmployeeReq)
        {
           var existingEmployee =  await this._employeeCrudDbContext.Employees.FirstOrDefaultAsync(x => x.Id == updateEmployeeReq.Id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = updateEmployeeReq.Name;
                existingEmployee.Salary = updateEmployeeReq.Salary;
                existingEmployee.DateOfBirth = updateEmployeeReq.DateOfBirth;
                existingEmployee.Email = updateEmployeeReq.Email;
                existingEmployee.Department = updateEmployeeReq.Department;

                await this._employeeCrudDbContext.SaveChangesAsync();

                return Redirect("/Home");
            }

            return RedirectToAction("Index");


        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            this._employeeCrudDbContext.Employees.Remove(employee);
            this._employeeCrudDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}
