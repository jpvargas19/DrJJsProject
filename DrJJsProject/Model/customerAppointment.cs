using System;
namespace DrJJsProject.Model
{
        public class CustomerAppointment
        {
            public Client client { get; set; }
            public Appointment appointment { get; set; }

            public CustomerAppointment(Client c, Appointment a)
            {
                client = c;
                appointment = a;
            }
        }
    
}

