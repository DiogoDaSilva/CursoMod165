using CursoMod165.Data;
using CursoMod165.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CursoMod165.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            IEnumerable<Staff> Staffs = _context
                                            .Staffs
                                            .Include(s => s.StaffRole)
                                            .ToList();

            return View(Staffs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.StaffRoles = new SelectList(_context.StaffRoles, "ID", "Name");

            return View();
        }


        [HttpPost]
        public IActionResult Create(Staff Staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staffs.Add(Staff);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }


            return View(Staff);
        }

        public IActionResult Details(int id)
        {
            Staff? Staff = _context.Staffs.Find(id);

            if (Staff == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(Staff);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Staff? Staff = _context.Staffs.Find(id);

            if (Staff == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(Staff);
        }

        [HttpPost]
        public IActionResult Edit(Staff Staff)
        {

            if (ModelState.IsValid)
            {
                _context.Staffs.Update(Staff);
                _context.SaveChanges();
            }

            return View(Staff);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff? Staff = _context.Staffs.Find(id);

            if (Staff == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(Staff);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff? Staff = _context.Staffs.Find(id);

            if (Staff != null)
            {
                _context.Staffs.Remove(Staff);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(Staff);
        }
    }
}
