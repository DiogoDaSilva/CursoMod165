using CursoMod165.Data;
using CursoMod165.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoMod165.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Appointment> appointments = _context.Appointments.ToList();
            
            return View(appointments);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
