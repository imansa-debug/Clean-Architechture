using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interface;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArch.MVC.Controllers
{
    public class CourseController : Controller
    {
        // GET: /<controller>/

        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            CourseViewModel model = _courseService.GetCourses();
            return View(model);
        }
    }
}
