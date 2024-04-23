using CursoMod165.Data;
using CursoMod165.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace CursoMod165.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IToastNotification _toastNotification; // Singleton

        public AppointmentController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            IEnumerable<Appointment> appointments = _context.Appointments
                                                            .Include(appointment => appointment.Staff.StaffRole)
                                                            .Include(appointment => appointment.Customer)
                                                            .ToList();
            
            return View(appointments);
        }



        public IActionResult TomorrowsAppointments()
        {
            var tomorrowsAppointments = _context.Appointments
                                                .Include(appointment => appointment.Staff.StaffRole)
                                                .Include(appointment => appointment.Customer)
                                                .Where(appointment => appointment.Date ==  DateTime.Today.AddDays(1))
                                                .ToList();
            return View(tomorrowsAppointments);
        }

        public IActionResult NextWeekAppointments()
        {
            int x = 1;
            if (DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
            {
                x = 8 - (int)DateTime.Today.DayOfWeek;
            }
             
            DateTime startDate = DateTime.Today.AddDays(x);
            DateTime endDate   = DateTime.Today.AddDays(x + 4);

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            var nextWeekAppointments = _context.Appointments
                                                .Include(appointment => appointment.Staff.StaffRole)
                                                .Include(appointment => appointment.Customer)
                                                .Where(appointment => appointment.Date >= startDate && appointment.Date <= endDate)
                                                .ToList();
            return View(nextWeekAppointments);
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

                // Toastr.SuccessMessage
                _toastNotification.AddSuccessToastMessage("Appointment successfully created.");

                return RedirectToAction(nameof(Index));
            }

            // Toastr.ErrorMessage
            _toastNotification.AddErrorToastMessage("Check the form again!",
                new ToastrOptions { 
                    Title = "Appointment Creation Error",
                    TapToDismiss = true,
                    TimeOut = 0
                });
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
