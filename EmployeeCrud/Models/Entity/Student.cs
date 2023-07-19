using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Models.Entity
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name is required"),MinLength(5,ErrorMessage ="Name must have atleast 5 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Age is required"),Range(0,150,ErrorMessage ="Age Range Exceeded")]
        public string Age { get; set; }

        [Required(ErrorMessage="Roll Number is required")]
        public int Roll { get; set; }   


    }
}
