using System;
namespace DrJJsProject.Model
{
	public class Client
	{
		private static int autoIncrement;

		public int ID { get; set; }

		public string UserName { get; set; }
		public string Password { get; set; }

		public string FirstName { get; set; }
        public string LastName { get; set; }

		public Client()
		{
			autoIncrement++;
			ID = autoIncrement;
		}
    }
}

