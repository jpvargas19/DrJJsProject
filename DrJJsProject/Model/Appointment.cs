using System;
namespace DrJJsProject.Model
{
    public class Appointment // Define a new C# class called Appointment
    { 

        private static int autoIncrement; // Declare a static variable autoIncrement to keep track of the next Id value to be assigned
        public int Id { get; set; } // Declare a public property Id to hold the unique identifier of the Appointment object
        public DateTime date { get; set; } // Declare a public property date to hold the date and time of the Appointment object

        public Appointment(int year, int month, int day, int hour, int minute, int second) // // Define a constructor for the Appointment class that takes in year, month, day, hour, minute, second
        {
            DateTime dt1 = new DateTime(year, month, day, hour, minute, second); // Create a new DateTime object using the year, month, day, hour, minute, and second arguments
            date = dt1; // Assign the newly created DateTime object to the date property
            autoIncrement++; // Increment autoIncrement to get the next unique Id value for the object
            Id = autoIncrement;  // Assign the incremented autoIncrement value to the Id property
        }
        
           
    }
}

