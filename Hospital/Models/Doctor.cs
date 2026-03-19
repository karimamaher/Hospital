namespace Hospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; }

        public string Image { get; set; }

        public List<Appointment> Appointments { get; set; } = [];

    }
}
