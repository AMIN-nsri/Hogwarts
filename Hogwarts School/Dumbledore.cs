using System;
namespace Hogwarts
{
	public class Dumbledore
	{
		public Dumbledore()
		{
		}
		public Dorm Dorm { get; set; } // Make it function

        private string MainUsername = "AMIN";
        private string MainPassword = "12345a";
        public bool LoginCheck(string username, string password)
        {
            if (username == MainUsername && password == MainPassword)
                return true;
            
            return false;
        }
    }
}

