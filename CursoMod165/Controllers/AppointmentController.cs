using CursoMod165.Data;
using CursoMod165.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            IEnumerable<Appointment> appointments = _context.Appointments
                                                            .Include(appointment => appointment.Staff)
                                                            .Include(appointment => appointment.Customer)
                                                            .ToList();
            
            return View(appointments);
        }



        public IActionResult TomorrowsAppointments()
        {
            var tomorrowsAppointments = _context.Appointments
                                                .Include(appointment => appointment.Staff)
                                                .Include(appointment => appointment.Customer)
                                                .Where(appointment => appointment.Date ==  DateTime.Today.AddDays(1))
                                                .ToList();
            return View(tomorrowsAppointments);
        }






        [HttpGet]
        public IActionResult Create()
        {
            this.SetupAppointments();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.SetupAppointments();
            return View(appointment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Appointment? appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return RedirectToAction(nameof(Index));
            }

            this.SetupAppointments();
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.SetupAppointments();
            return View(appointment);
        }


        private void SetupAppointments()
        {
            ViewBag.CustomerList = new SelectList(_context.Customers, "ID", "Name");

            var staffList = _context.Staffs
                                    .Include(s => s.StaffRole)
                                    .Where(s => s.StaffRole.CanDoAppointments == true)
                                    .Select(s => new { 
                                                        ID = s.ID,
                                                        Name = $"{s.Name} [{s.StaffRole.Name}]" 
                                                     });

            ViewBag.StaffList = new SelectList(staffList, "ID", "Name");
        }
    }
}
