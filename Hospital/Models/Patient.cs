namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }= string.Empty;

        public string? Phone { get; set; }
        public List<Appointment> Appointments { get; set; } = [];
    }
}
