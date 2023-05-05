using System;
namespace DrJJsProject.Model
{
    public class Appointment // Define a new C# class called Appointment
    { 

        private static int autoIncrement;
        public int Id { get; set; }
        public DateTime date { get; set; }

        public Appointment(int year, int month, int day, int hour, int minute, int second)
        {
            DateTime dt1 = new DateTime(year, month, day, hour, minute, second);
            date = dt1;
            autoIncrement++;
            Id = autoIncrement;
        }
        
           
    }
}

