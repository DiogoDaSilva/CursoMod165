using CursoMod165.Data;
using CursoMod165.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoMod165.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            IEnumerable<Customer> customers = _context.Customers.ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // TODO Criar novo customer
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(customer);
        }

        public IActionResult Details(int id)
        {
            Customer? customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Customer? customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                // return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer? customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer? customer = _context.Customers.Find(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); 
            }

            return View(customer);
        }















        public IActionResult EditNum(string num)
        {
            int numInt = int.Parse(num);
            Customer? customer = _context.Customers.Find(numInt);

            if (customer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }
    }
}
