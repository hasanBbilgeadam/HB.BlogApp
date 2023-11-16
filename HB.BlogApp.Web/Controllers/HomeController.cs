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
        private readonly IEmailService _emailService;

        public HomeController(ICategoryService categoryService, IEmailService emailService)
        {
            _categoryService = categoryService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {

            var htmlBody = $@"
    

                        <html>
                    <head>
   <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    </head>
                    <body>
                        <h2>bu bir test maili</h2>
                        <p>{DateTime.Now.ToString()}<p/>
                    </body>
                    </html>

                
                ";


            _emailService.SendMail("hasan.baysall@gmail.com", "Test", htmlBody);
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