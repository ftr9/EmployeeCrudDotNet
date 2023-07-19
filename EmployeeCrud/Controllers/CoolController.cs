using EmployeeCrud.Data;
using EmployeeCrud.Models;
using EmployeeCrud.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeCrud.Controllers
{
    public class CoolController : Controller
    {
        private readonly EmployeeCrudDbContext _employeeCrudDbContext;
        private readonly ILogger<CoolController> _logger;
        public CoolController(EmployeeCrudDbContext dbctx, ILogger<CoolController> logger) {
            this._employeeCrudDbContext = dbctx;
            this._logger = logger;
        } 
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult CoolThings()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Add(AddStudentViewModel addStudentModel)
        {
            if (!ModelState.IsValid)
            {

                return View("Index", addStudentModel);
            }
           
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentModel.Name,
                Age = addStudentModel.Age,
                Roll = addStudentModel.Roll
            };

            
                await this._employeeCrudDbContext.AddAsync(student);
            await this._employeeCrudDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            
           
        }
    }
}
