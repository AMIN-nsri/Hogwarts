using System;
using System.Reflection;

namespace Hogwarts
{
    public class DMessage
    {
        public DMessage(string message, string sender)
        {
            this.message = message;
            this.Sender = sender;
        }
        public string Sender { get; set; }
        public string message { get; set; }
        public bool Seen { get; set; }
    }
	public class Dumbledore
	{
		public Dumbledore()
		{
            DumbMessage.Insert(0, new DMessage("hello","amin"));
            DumbMessage.Insert(0, new DMessage("hello2", "samin"));
            DumbMessage.Insert(0, new DMessage("hello3", "sina"));

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
        public int STLoginCheck(string username, string password, List<Student> studentlist)
        {
            for (int i = 0; i < studentlist.Count; i++)
            {
                if (username == studentlist[i].Username && password == studentlist[i].Password) return i;
            }
            return -1;
        }
        public int TELoginCheck(string username, string password, List<Teacher> teacherlist)
        {
            for (int i = 0; i < teacherlist.Count; i++)
            {
                if (username == teacherlist[i].Username && password == teacherlist[i].Password) return i;
            }
            return -1;
        }
        public List<DMessage> DumbMessage = new List<DMessage>();
        
        public bool NewDumbMessage;
        public void SendMessageFromST(string message, Student st)
        {
            DumbMessage.Insert(0, new DMessage(message, st.FirstName + " " + st.LastName));
            NewDumbMessage = true;
            Console.WriteLine("Message Sent Succussfully!");
        }
        public void Inbox_UnRead()
        {
            bool isThereAnyunreadMessage = false;
            for (int i = 0; i < DumbMessage.Count; i++)
            {
                if (!DumbMessage[i].Seen)
                {
                    isThereAnyunreadMessage = true;
                    Console.Write($"{(i + 1) + "-",-3} ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"{DumbMessage[i].Sender + ": ",-10}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{DumbMessage[i].message}");
                    Console.WriteLine();
                    DumbMessage[i].Seen = true;
                }
            }
            if (!isThereAnyunreadMessage) Console.WriteLine("Empty!");
        }
        public void Inbox_Read()
        {
            bool isThereAnyreadMessage = false;
                for (int i = 0; i < DumbMessage.Count; i++)
                {
                    if (DumbMessage[i].Seen)
                    {
                    isThereAnyreadMessage = true;
                    Console.Write($"{(i + 1) + "-",-3} ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"{DumbMessage[i].Sender + ": ",-10}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{DumbMessage[i].message}");
                    Console.WriteLine();
                    }
                }
            if (!isThereAnyreadMessage) Console.WriteLine("Empty!");
        }
        public void Inbox_All()
        {
            for (int i = 0; i < DumbMessage.Count; i++)
            {
                Console.Write($"{(i + 1) + "-",-3} ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"{DumbMessage[i].Sender + ": ",-10}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{DumbMessage[i].message}");
                Console.WriteLine();
            }
        }
        public void Invite(Human human)
        {
            if(human.Role== ERole.Teacher)
            {
                Console.WriteLine("You Cannot Invite Teachers!");
            }
            else if (human.Role==ERole.Student)
            {
                human.invited = true;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Student Invited Successfully!");
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("They Will Be Registered Once They Accept the Invitation.");
            }
        }
    }
}

