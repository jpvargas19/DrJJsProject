using DrJJsProject.Model;
using System;
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
            var c1 = new Client // Create a new client
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
            var a1 = new Appointment(); // Create a new appointment 
            var a2 = new Appointment(); // Create a new appointment
            var a3 = new Appointment(); // Create a new appointment

            var ca1 = new CustomerAppointment(c1, a1); // Create a new customer appointments using the clients and appointments created above
            var ca2 = new CustomerAppointment(c1, a2); // Create a new customer appointments using the clients and appointments created above
            var ca3 = new CustomerAppointment(c2, a3); // Create a new customer appointments using the clients and appointments created above

            customers = new Clients(); // Initialize the clients list with the created objects
            customers.customers.Add(c1); // Add the "c1" instance of the Customer class to the "customers" list in the Clients class
            customers.customers.Add(c2); // Add the "c2" instance of the Customer class to the "customers" list in the Clients class

            appointments = new List<Appointment>(); //Initialize the appointments list with the created objects
            appointments.Add(a1); // Add the "a1" instance of the Appointment class to the "appointments" list
            appointments.Add(a2); // Add the "a2" instance of the Appointment class to the "appointments" list
            appointments.Add(a3); // Add the "a3" instance of the Appointment class to the "appointments" list

            customerAppointments = new List<CustomerAppointment>(); //Initialize the customerAppointments list with the created objects
            customerAppointments.Add(ca1); // Add the "ca1" instance of the CustomerAppointment class to the "customerAppointments" list
            customerAppointments.Add(ca2); // Add the "ca2" instance of the CustomerAppointment class to the "customerAppointments" list
            customerAppointments.Add(ca3); // Add the "ca3" instance of the CustomerAppointment class to the "customerAppointments" list


        }

        static void Menu() // Define the Menu method
        {
            bool done = false; // Declare a variable to indicate if the user is done using the program

            while (!done) // Loop until "done" is true            
            {
             
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- Quit: q ---"); // Display the available options
                Console.Write("Choice: "); // Prompt the user to enter a choice
                string choice = Console.ReadLine(); // Read the user's input and store it in the "choice" variable

                // Use a switch statement to execute the appropriate method based on user input
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

            if (appointmentList.Count() == 0) // If no appointments were found, displays a message stating so
            {
                Console.WriteLine("0 appointment found."); // Lets the user know that there aren't any appointment found
            }
            else // If appointments were found, displays each appointment's date
            {
                foreach (var appointmnet in appointmentList) // Loop through the appointmentLis
                {
                    Console.WriteLine(appointmnet.appointment.date); // Print the date of each appointment
                }
            }
        }




    }
}

