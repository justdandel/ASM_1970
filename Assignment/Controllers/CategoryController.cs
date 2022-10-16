using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var categories = context.categories.ToList();
            return View(categories);
        }

        public IActionResult Info(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.categories.Include(c => c.BookList).FirstOrDefault(c => c.Id == id);
            //Note: khi muốn truy xuất dữ liệu của bảng B từ bảng A
            //thì cần sử dụng Include kết hợp với FirstOrDefault
            //còn nếu chỉ truy xuất thông tin id đơn thuần thì sử dụng
            //Find hoặc FirstOrDefault đều được
            return View(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category cate)
        {
            if (ModelState.IsValid)
            {
                context.categories.Add(cate);
                context.SaveChanges();
                TempData["Message"] = "Add successful!";
                return RedirectToAction("index");
            }
            else
            {
                return View(cate);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(context.categories.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Category uni)
        {
            if (ModelState.IsValid)
            {
                context.categories.Update(uni);
                context.SaveChanges();
                TempData["Message"] = "Edit successful!";
                return RedirectToAction("index");
            }
            else
            {
                return View(uni);
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
                var category = context.categories.Find(id);
                //xoa object co id vua tim thay
                context.categories.Remove(category);
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
