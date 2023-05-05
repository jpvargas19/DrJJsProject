using System;
using DrJJsProject.Model;
//using static DrJJsProject.Model.customerAppointment;

namespace DrJJsProject.Model
{
    public class Program
    {
        private static Clients customers;
        private static List<Appointment> appointments;
        private static List<CustomerAppointment> customerAppointments;
        private static Client authenticatedCustomer;

        private static Client client;
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            Initialize();
            Menu();
        }

        static void Initialize()
        {
            var c1 = new Client
            { 
                FirstName = "Anthony",
                LastName = "Esposito",
                Username = "anthonye",
                Password = "1234"
            };
            var c2 = new Client
            {
                FirstName = "Katie",
                LastName = "Trunda",
                Username = "katiet",
                Password = "2345"
            };
            var a1 = new Appointment(2023, 05, 1, 04, 30, 30);
            var a2 = new Appointment(2023, 05, 2, 5, 15, 20);
            var a3 = new Appointment(2023, 06, 15, 6, 30, 50);

            customers = new Clients();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            appointments = new List<Appointment>();
            appointments.Add(a1);
            appointments.Add(a2);
            appointments.Add(a3);

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

        static void Menu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Welcome to Dr. JJ's Salon Booking System! Please select an option below.");
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        LogoutMenu();
                        break;
                    case "3":
                        SignUpMenu();
                        break;
                    case "4":
                        GetCurrentAppointmentsMenu();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

            }

        }


        static void LoginMenu()
        {
            if (authenticatedCustomer == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                authenticatedCustomer = customers.Authenticate(username, password);
                if (authenticatedCustomer != null)
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
                }
                else
                {
                    Console.WriteLine("invalid username or password");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}");
            }
        }

        static void LogoutMenu()
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out!");
        }

        static void SignUpMenu()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var newCustomer = new Client
            {
                FirstName = firstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            customers.customers.Add(newCustomer);

            Console.WriteLine("Profile created!");

        }


        static void GetCurrentAppointmentsMenu()
        {
            if (authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }


            var appointmentList = customerAppointments.Where(o => o.client.Username == authenticatedCustomer.Username);

            int appNumber = 0;
            String app1 = "", app2 = "", app3 = "";
            String appString = "";
            if (appointmentList.Count() == 0)
            {
                Console.WriteLine("0 appointment found.");
            }
            else
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