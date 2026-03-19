using System.Diagnostics;
using Hospital.DataAccess;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        /*        private readonly ILogger<HomeController> _logger;

                public HomeController(ILogger<HomeController> logger)
                {
                    _logger = logger;
                }*/

        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context=new ApplicationDbContext();    


        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BookAppointment( string? query= null)
        {
            var doctors = _context.Doctors.AsQueryable();

            if (query is not null) 
            {
                doctors = doctors.Where(e=> e.Specialization.Contains(query.Trim().ToLower()) );
            }
            return View(doctors.AsEnumerable());
        }

        public IActionResult CompleteAppointment(int id)
        {
           var doctor = _context.Doctors.SingleOrDefault(e=>e.Id == id);   
  
            return View(doctor);
        }

        [HttpPost]
        public IActionResult CompleteAppointment(int doctorId, string patientName, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            if (appointmentDate.DayOfWeek == DayOfWeek.Friday || appointmentDate.DayOfWeek == DayOfWeek.Saturday)
            {
                ModelState.AddModelError("", "Appointments are only available from Sunday to Thursday.");
            }

            var startTime = new TimeSpan(8, 0, 0);  
            var endTime = new TimeSpan(20, 0, 0);   

            if (appointmentTime < startTime || appointmentTime > endTime)
            {
                ModelState.AddModelError("", "Working hours are from 8:00 AM to 8:00 PM only.");
            }

            
            if (!ModelState.IsValid)
            {
                var doctor = _context.Doctors.SingleOrDefault(e => e.Id == doctorId);
                return View(doctor);
            }

            Patient patient = new Patient
            {
                Name = patientName,
            };
            _context.Patients.Add(patient);
            _context.SaveChanges();

            _context.Appointments.Add(new Appointment
            {
                DoctorId = doctorId,
                PatientId = patient.Id,
                AppointmentDate = appointmentDate,
                AppointmentTime = appointmentTime
            });
            _context.SaveChanges();


            return RedirectToAction("ReservationsManagement");
        }

        public IActionResult ReservationsManagement()
        {

            var appointments = _context.Appointments.Include(e => e.Doctor)
                 .Include(e => e.Patient);
            return View(appointments.AsEnumerable());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
