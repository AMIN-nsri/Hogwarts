using System;
namespace Hogwarts
{
	public class Dumbledore
	{
		public Dumbledore()
		{
            DumbMessage.Add("Hello");
            DumbMessage.Add("Hello2");
            DumbMessage.Add("Hello3");
            DumbMessage.Add("Hello4");

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
        List<string> DumbMessage = new List<string>();
        
        public bool NewDumbMessage;
        public void Inbox()
        {
            if (DumbMessage.Count >= 3)
            {
                Console.WriteLine("Your Last 3 Message:");
                for (int i = DumbMessage.Count - 1; i > DumbMessage.Count - 4; i--)
                {
                    Console.WriteLine((i+1) + "- " + DumbMessage[i]);
                }
                Console.WriteLine("Enter 'F' to See Full Inbox.");
            }
            if (DumbMessage.Count == 2)
            {
                Console.WriteLine("Your Only 2 Message:");
                for (int i = DumbMessage.Count - 1; i > DumbMessage.Count - 3; i--)
                {
                    Console.WriteLine((i+1) + "- " + DumbMessage[i]);
                }
            }
            if (DumbMessage.Count == 1)
            {
                Console.WriteLine("Your Only Message:");
                
                    Console.WriteLine(DumbMessage[0]);
                
            }
            if (DumbMessage.Count == 0)
            {
                Console.WriteLine("Your Inbox is Empty!");
            }
        }
        public void FullInbox()
        {
            Message.Program();
            Inbox();
            Wait.ClearLine();
            //Wait.ClearLine();
            for (int i = DumbMessage.Count - 4; i >= 0; i--)
            {
                Console.WriteLine((i + 1) + "- " + DumbMessage[i]);
            }
        }
    }
}

