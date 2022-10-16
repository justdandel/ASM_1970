using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment.Controllers
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
            return View(context.books.ToList());
        }

        public IActionResult List()
        {
            return View(context.books.ToList());
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                //tao ra object student co id duoc yeu cau
                var book = context.books.Find(id);
                //xoa object co id vua tim thay
                context.books.Remove(book);
                // luu lai thay doi trong db
                context.SaveChanges();

                //gui thong bao ve trang index
                TempData["Message"] = "Deleted!";
                //khi dung redirect thi phai dung tempdata
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Detail(int id)
        {
            var book = context.books.Include(s => s.Category).FirstOrDefault(s => s.Id == id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //lay ra du lieu tu bang university va luu vao list
            var category = context.categories.ToList();
            //du lieu day vao viewbag
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book b)
        {
            if (ModelState.IsValid)
            {
                context.books.Add(b);
                context.SaveChanges();
                TempData["Message"] = "Add successful!";
                return RedirectToAction("index");
            }
            else
            {
                return View(b);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.categories.ToList();
            //du lieu day vao viewbag
            ViewBag.Category = category;
            return View(context.categories.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                context.books.Update(b);
                context.SaveChanges();
                TempData["Message"] = "Edit successful!";
                return RedirectToAction("index");
            }
            else
            {
                return View(b);
            }
        }
    }
}
