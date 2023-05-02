using System;
namespace DrJJsProject.Model
{
    public class Client
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Client()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}

