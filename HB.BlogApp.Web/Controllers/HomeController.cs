using HB.BlogApp.BL.Services;
using HB.BlogApp.Dto;
using HB.BlogApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HB.BlogApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryAddDto dto)
        {

            _categoryService.Add(dto);
            return RedirectToAction("Index");
        }
      
    }
}