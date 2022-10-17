using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext context;

        public AuthorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var authors = context.authors.ToList();
            return View(authors);
        }

        public IActionResult Info(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = context.authors.Include(c => c.BookList).FirstOrDefault(c => c.Id == id);

            //Note: khi muốn truy xuất dữ liệu của bảng B từ bảng A
            //thì cần sử dụng Include kết hợp với FirstOrDefault
            //còn nếu chỉ truy xuất thông tin id đơn thuần thì sử dụng
            //Find hoặc FirstOrDefault đều được
            return View(author);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author a)
        {
            if (ModelState.IsValid)
            {
                context.authors.Add(a);
                context.SaveChanges();
                TempData["Message"] = "Add successful!";
                return RedirectToAction("index");
            }
            else
            {
                return View(a);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(context.authors.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Author a)
        {
            if (ModelState.IsValid)
            {
                context.authors.Update(a);
                context.SaveChanges();
                TempData["Message"] = "Edit successful!";
                return RedirectToAction("index");
            }
            else
            {
                return View(a);
            }
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
                var author = context.authors.Find(id);
                //xoa object co id vua tim thay
                context.authors.Remove(author);
                // luu lai thay doi trong db
                context.SaveChanges();

                //gui thong bao ve trang index
                TempData["Message"] = "Deleted!";
                //khi dung redirect thi phai dung tempdata
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
