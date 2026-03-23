using Hospital.Models;

namespace Hospital.ViewModels
{
    public class DoctorVM
    {
        public IEnumerable<Doctor> Doctors { get; set; } = null!;
        public double TotalPages { get; set; }  
        public int  CurrentPage { get; set; }
    }
}
