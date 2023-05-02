using System;
namespace DrJJsProject.Model
{
    public class Clients
    {
        public List<Client> customers { get; set; }

        public Clients()
        {
            customers = new List<Client>();
        }

        public Client Authenticate(string username, string password)
        {
            var c = customers.Where(o => (o.Username == username) && (o.Password == password));

            if (c.Count() > 0)
            {
                return c.First();
            }
            else
            {
                return null;
            }
        }
    }
}

