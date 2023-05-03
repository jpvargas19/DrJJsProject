using System;
namespace DrJJsProject.Model
{
    public class Clients // Define a new C# class called Clients
    {
        public List<Client> customers { get; set; } // Declare a public List object to hold Client objects

        public Clients() // Constructor for the Clients class
        {
            customers = new List<Client>(); // Create a new List object to hold Client objects
        }

        public Client Authenticate(string username, string password) // Authenticate method that takes a username and password as input and returns a Client object
        {
            var c = customers.Where(o => (o.Username == username) && (o.Password == password)); // Use LINQ to find the first Client object in the customers list that matches the provided username and password

            if (c.Count() > 0) // Check if a matching Client object was found
            {
                return c.First(); // If a matching Client object was found, return the first one
            }
            else
            {
                return null; // If no matching Client object was found, return null
            }
        }
    }
}

