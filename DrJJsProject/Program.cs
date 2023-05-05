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
                FirstName = "Anthony",
                LastName = "Esposito",
                Username = "anthonye",
                Password = "1234"
            };
            var c2 = new Client // Create a new client
            {
                FirstName = "Katie", // Assign a first name
                LastName = "Trunda", // Assign a last name
                Username = "katiet", // Assign a username
                Password = "2345" // Assign a password
            };
            var a1 = new Appointment(2023, 05, 1, 04, 30, 30);
            var a2 = new Appointment(2023, 05, 2, 5, 15, 20);
            var a3 = new Appointment(2023, 06, 15, 6, 30, 50);

            customers = new Clients();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            appointments = new List<Appointment>(); //Initialize the appointments list with the created objects
            appointments.Add(a1); // Add the "a1" instance of the Appointment class to the "appointments" list
            appointments.Add(a2); // Add the "a2" instance of the Appointment class to the "appointments" list
            appointments.Add(a3); // Add the "a3" instance of the Appointment class to the "appointments" list

            var ca1 = new CustomerAppointment(c1, a1);
            var ca2 = new CustomerAppointment(c1, a2);
            var ca3 = new CustomerAppointment(c1, a3);
            var ca4 = new CustomerAppointment(c2, a1);
            var ca5 = new CustomerAppointment(c2, a2);
            var ca6 = new CustomerAppointment(c2, a3);

            customerAppointments = new List<CustomerAppointment>();
            customerAppointments.Add(ca1);
            customerAppointments.Add(ca2);
            customerAppointments.Add(ca3);
            customerAppointments.Add(ca4);
            customerAppointments.Add(ca5);
            customerAppointments.Add(ca6);
            

        }

        static void Menu() // Define the Menu method
        {
            bool done = false; // Declare a variable to indicate if the user is done using the program

            while (!done) // Loop until "done" is true            
            {
                Console.WriteLine("Welcome to Dr. JJ's Salon Booking System! Please select an option below.");
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
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

            int appNumber = 0;
            String app1 = "", app2 = "", app3 = "";
            String appString = "";
            if (appointmentList.Count() == 0)
            {
                Console.WriteLine("0 appointment found."); // Lets the user know that there aren't any appointment found
            }
            else // If appointments were found, displays each appointment's date
            {
                foreach (var appointment in appointmentList)
                {
                    appNumber++;
                    if (appNumber == 1)
                        app1 = appointment.appointment.date.ToString();
                    if (appNumber == 2)
                        app2 = appointment.appointment.date.ToString();
                    if (appNumber == 3)
                        app3 = appointment.appointment.date.ToString();

                    appString = appointment.appointment.date.ToString();
                    Console.WriteLine(appNumber + ": " + appString);
                }
                
            }
            
            String choice = "";
            while (!(choice.Equals("1") || choice.Equals("2") || choice.Equals("3")))
            {
                Console.WriteLine("Enter the number of your desired appointment from above.");
                choice = Console.ReadLine();


                if (choice.Equals("1"))
                {
                    Console.WriteLine("Appointment booked for " + app1);
                }
                else if (choice.Equals("2"))
                {
                    Console.WriteLine("Appointment booked for " + app2);
                }
                else if (choice.Equals("3"))
                {
                    Console.WriteLine("Appointment booked for " + app3);
                }
                else Console.WriteLine("Invalid input.");
            }
        }
    }
}