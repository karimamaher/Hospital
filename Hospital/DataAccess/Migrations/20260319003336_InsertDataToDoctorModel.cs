using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InsertDataToDoctorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Doctors (Name, Specialization, Image) values ('Nani Baldassi', 'Psychiatry', 'doctor1.jpg'); insert into Doctors (Name, Specialization, Image) values ('Ethan Durand', 'Dermatology', 'doctor2.jpg'); insert into Doctors (Name, Specialization, Image) values ('Aloin Tarver', 'Dentistry', 'doctor3.jpg'); insert into Doctors (Name, Specialization, Image) values ('Odetta Roswarne', 'Dermatology', 'doctor4.jpg'); insert into Doctors (Name, Specialization, Image) values ('Farah Salway', 'Orthopedics', 'doctor1.jpg'); insert into Doctors (Name, Specialization, Image) values ('Glennie Medway', 'Psychiatry', 'doctor5.jpg'); insert into Doctors (Name, Specialization, Image) values ('Cory Polet', 'Dermatology', 'doctor6.jpg'); insert into Doctors (Name, Specialization, Image) values ('Carleen Janikowski', 'Orthopedics', 'doctor2.jpg');  ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Doctors ");
        }
    }
}
