using System;
namespace DrJJsProject.Model
{
    public class Appointment // Define a new C# class called Appointment
    {
        private static int autoIncreament; // Declare a private static integer variable to keep track of appointment IDs
        public int Id { get; set; } // Declare a public integer property for the appointment ID
        public DateTime date { get; set; } // Declare a public DateTime property for the appointment date

        public Appointment() // Constructor for the Appointment class
        {
            autoIncreament++; // Increment the static variable autoIncreament
            Id = autoIncreament; // Set the appointment ID to the current value of autoIncreament
        }
    }
}

