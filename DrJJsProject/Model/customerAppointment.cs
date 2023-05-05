using System;
namespace DrJJsProject.Model
{
        public class CustomerAppointment //defines a new class called "CustomerAppointment"
        {
            public Client client { get; set; } //declares a public property
            public Appointment appointment { get; set; } //declares a public property

            public CustomerAppointment(Client c, Appointment a) //public constructor that takes two parameters
            {
                client = c; //setting the value of client to c
                appointment = a; //setting the value of appointment to a
            }
        }
     
}

