using System;
using DrJJsProject.Model;
//using static DrJJsProject.Model.customerAppointment;

namespace DrJJsProject.Model
{
    public class Program
    {
        private static Clients customers;//Declare private static variables for clients
        private static List<Appointment> appointments;//Declare private static variables for appointments
        private static List<CustomerAppointment> customerAppointments;//Declare private static variables for customerAppointments 
        private static Client authenticatedCustomer;//Declare private static variables for authenticated customer

        private static Client client; // Declare a private static variable for a client

        static void Main(string[] args) // Define the Main method
        {
            Console.WriteLine("Initializing..."); // Print a message indicating the initialization of the program
            Initialize(); // Call the Initialize method to create sample clients, appointments, and customer appointments
            Menu(); // Call the Menu method to start the user interface
        }

        static void Initialize() // Define the Initialize method
        {
            var c1 = new Client
            { 
                FirstName = "Anthony", // Assign a first name
                LastName = "Esposito", // Assign a last name
                Username = "anthonye", // Assign a username
                Password = "1234" // Assign a password
            };
            var c2 = new Client // Create a new client
            {
                FirstName = "Katie", // Assign a first name
                LastName = "Trunda", // Assign a last name
                Username = "katiet", // Assign a username
                Password = "2345" // Assign a password
            };
            var a1 = new Appointment(2023, 05, 1, 04, 30, 30); // Create a new Appointment object and store it in a variable called "a1".
            var a2 = new Appointment(2023, 05, 2, 5, 15, 20); // Create a new Appointment object and store it in a variable called "a2".
            var a3 = new Appointment(2023, 06, 15, 6, 30, 50); // Create a new Appointment object and store it in a variable called "a3".

            customers = new Clients(); // Create a new instance of the Clients class
            customers.customers.Add(c1); // Add c1 created above to its list of customers
            customers.customers.Add(c2); // Add c2 created above to its list of customers

            appointments = new List<Appointment>(); //Initialize the appointments list with the created objects
            appointments.Add(a1); // Add the "a1" instance of the Appointment class to the "appointments" list
            appointments.Add(a2); // Add the "a2" instance of the Appointment class to the "appointments" list
            appointments.Add(a3); // Add the "a3" instance of the Appointment class to the "appointments" list

            var ca1 = new CustomerAppointment(c1, a1); // Create an instance of the CustomerAppointment class with the clients and appointments created above
            var ca2 = new CustomerAppointment(c1, a2); // Create an instance of the CustomerAppointment class with the clients and appointments created above
            var ca3 = new CustomerAppointment(c1, a3); // Create an instance of the CustomerAppointment class with the clients and appointments created above
            var ca4 = new CustomerAppointment(c2, a1); // Create an instance of the CustomerAppointment class with the clients and appointments created above
            var ca5 = new CustomerAppointment(c2, a2); // Create an instance of the CustomerAppointment class with the clients and appointments created above
            var ca6 = new CustomerAppointment(c2, a3); // Create an instance of the CustomerAppointment class with the clients and appointments created above

            customerAppointments = new List<CustomerAppointment>(); // Initialize a new list of customer appointments
            customerAppointments.Add(ca1); // Adds one instances of CustomerAppointment objects to the list.
            customerAppointments.Add(ca2); // Adds one instances of CustomerAppointment objects to the list.
            customerAppointments.Add(ca3); // Adds one instances of CustomerAppointment objects to the list.
            customerAppointments.Add(ca4); // Adds one instances of CustomerAppointment objects to the list.
            customerAppointments.Add(ca5); // Adds one instances of CustomerAppointment objects to the list.
            customerAppointments.Add(ca6); // Adds one instances of CustomerAppointment objects to the list.


        }

        static void Menu() // Define the Menu method
        {
            bool done = false; // Declare a variable to indicate if the user is done using the program

            while (!done) // Loop until "done" is true            
            {
                Console.WriteLine("Welcome to Dr. JJ's Salon Booking System! Please select an option below."); // Welcome the user to the program
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- Quit: q ---"); // Display menu options to the user
                Console.Write("Choice: "); // Prompt the user to enter a choice
                string choice = Console.ReadLine(); // Prompt the user to enter their choice
                switch (choice) // Evaluating the value of the "choice" variable
                {
                    case "1": // If the user's choice is "1"...
                        LoginMenu(); // Call the LoginMenu() function 
                        break; // Exit the switch statement
                    case "2": // If "choice" is equal to "2"...
                        LogoutMenu(); // Call the LogoutMenu() function
                        break; // Exit the switch statement
                    case "3": // If "choice" is equal to "3"...
                        SignUpMenu(); // Call the SignUpMenu() function
                        break; // Exit the switch statement
                    case "4": // If "choice" is equal to "4"...
                        GetCurrentAppointmentsMenu(); // Call the GetCurrentAppointmentsMenu() function
                        break; // Exit the switch statement
                    case "c": // If "choice" is equal to "c"...
                        Console.Clear(); // Clear the console
                        break; // Exit the switch statement
                    case "q": // If "choice" is equal to "q"...
                        done = true; // Set the "done" variable to "true"
                        break; // Exit the switch statement
                    default: // If none of the above cases match...
                        Console.WriteLine("Invalid command!"); // Display an error message
                        break;  // Exit the switch statement
                }

            }

        }


        static void LoginMenu() //This method displays the login menu and allows a customer to log in.
        {
            if (authenticatedCustomer == null) // Checks if the authenticated customer is null (not logged in)
            {
                Console.Write("Enter your username: ");  // Prompts the user to enter their username
                string username = Console.ReadLine(); // Stores the user input in the username variable
                Console.Write("Enter your password: "); // Prompts the user to enter their password
                string password = Console.ReadLine(); // Stores the user input in the password variable
                authenticatedCustomer = customers.Authenticate(username, password); // Attempts to authenticate the user with the entered username and password
                if (authenticatedCustomer != null) // If authentication succeeds, displays a welcome message
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}"); // Displays a welcome message with the customers first name
                }
                else // If authentication fails, displays an error message
                {
                    Console.WriteLine("invalid username or password"); // Gives the user a message letting them now that one of the entries is wrong
                }
            }
            else // If the authenticated customer is not null (already logged in), displays a message stating so
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}"); // It lets the user know that they are already logged in
            }
        }

        static void LogoutMenu() // This method logs out the current customer
        {
            authenticatedCustomer = null; // Sets the authenticated customer to null
            Console.WriteLine("Logged out!"); // Displays a message stating that the user has logged out
        }

        static void SignUpMenu() // This method displays the sign up menu and allows a new customer to create a profile
        {
            Console.Write("First Name: "); // Prompts the user to enter their first name
            string firstName = Console.ReadLine(); // Stores the user input in the firstName variable
            Console.Write("Last Name: "); // Prompts the user to enter their last name
            string LastName = Console.ReadLine(); // Stores the user input in the LastName variable
            Console.Write("Username: "); // Prompts the user to enter a username
            string username = Console.ReadLine(); // Stores the user input in the username variable
            Console.Write("Password: "); // Prompts the user to enter a password
            string password = Console.ReadLine(); // Stores the user input in the password variable

            var newCustomer = new Client // Creates a new customer object with the entered information
            {
                FirstName = firstName, // Sets the FirstName property of the Client instance to the value of the firstName variable.
                LastName = LastName, // Sets the LastName property of the Client instance to the value of the LastName variable.
                Username = username, // Sets the Username property of the Client instance to the value of the username variable.
                Password = password // Sets the Password property of the Client instance to the value of the password variable.
            };

            customers.customers.Add(newCustomer); // Adds the new customer to the list of customers

            Console.WriteLine("Profile created!"); // Displays a message stating that the profile has been created

        }


        static void GetCurrentAppointmentsMenu() // This method displays the current customer's appointments
        {
            if (authenticatedCustomer == null) // Checks if the authenticated customer is null (not logged in)
            {
                Console.WriteLine("You are not logged in."); //Displays a message stating that the user is not logged in
                return; // Since the user is not logged in, it returns
            }


            var appointmentList = customerAppointments.Where(o => o.client.Username == authenticatedCustomer.Username); // Gets a list of appointments for the current customer

            int appNumber = 0; // Initialize an integer variable called "appNumber" to 0.
            String app1 = "", app2 = "", app3 = ""; // Initialize three string variables called "app1", "app2", and "app3" to empty strings.
            String appString = ""; // Initialize a string variable called "appString" to an empty string.
            if (appointmentList.Count() == 0) // Check if the number of elements in the appointmentList is equal to 0.
            {
                Console.WriteLine("0 appointment found."); // Lets the user know that there aren't any appointment found
            }
            else // If appointments were found, displays each appointment's date
            {
                foreach (var appointment in appointmentList) // Begin a foreach loop that will iterate through each appointment in the appointmentList.
                {
                    appNumber++; // Increment the appNumber variable by 1.
                    if (appNumber == 1) // If the value of appNumber is 1:
                        app1 = appointment.appointment.date.ToString(); // Store the date of the appointment in the app1 variable.
                    if (appNumber == 2) // If the value of appNumber is 2:
                        app2 = appointment.appointment.date.ToString(); // Store the date of the appointment in the app2 variable.
                    if (appNumber == 3) // If the value of appNumber is 3:
                        app3 = appointment.appointment.date.ToString(); // Store the date of the appointment in the app3 variable.

                    appString = appointment.appointment.date.ToString(); // Store the date of the current appointment in the appString variable.
                    Console.WriteLine(appNumber + ": " + appString); // Display the number of the current appointment followed by its date.

                }

            }
            
            String choice = ""; // Initialice a string variable called "choice" to an empty string
            while (!(choice.Equals("1") || choice.Equals("2") || choice.Equals("3"))) // Begin a while loop that will continue executing as long as the user's input is not equal to "1", "2", or "3".
            {
                Console.WriteLine("Enter the number of your desired appointment from above."); // Display a message asking the user to enter the number of their desired appointment.
                choice = Console.ReadLine(); // Store the user's input in the "choice" variable.


                if (choice.Equals("1")) // Check if the user selected appointment 1.
                {
                    Console.WriteLine("Appointment booked for " + app1); // Display a message saying that appointment 1 has been booked.
                }
                else if (choice.Equals("2")) // Check if the user selected appointment 2.
                {
                    Console.WriteLine("Appointment booked for " + app2); // Display a message saying that appointment 2 has been booked.
                }
                else if (choice.Equals("3")) // Check if the user selected appointment 3.
                {
                    Console.WriteLine("Appointment booked for " + app3); // Display a message saying that appointment 3 has been booked.
                }
                else Console.WriteLine("Invalid input."); // If the user's input was not "1", "2", or "3", display a message saying that the input was invalid.
            }
        }
    }
}