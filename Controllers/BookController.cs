using ASM_1670.Data;
using Microsoft.AspNetCore.Mvc;
using ASM_1670.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASM_1670.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;

        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(context.Books.ToList);
        }
    }
}
