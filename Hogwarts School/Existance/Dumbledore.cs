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
        public int SearchSTByID(string username, List<Student> studentlist)
        {
            for (int i = 0; i < studentlist.Count; i++)
            {
                if (username == studentlist[i].Username) return i;
            }
            return -1;
        }
        public int SearchByID(string username, List<Human> humanlist)
        {
            for (int i = 0; i < humanlist.Count; i++)
            {
                if (username == humanlist[i].Username) return i;
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
        public void Invite(Human human,Student st)
        {
            if(human.Role== ERole.Teacher)
            {
                Console.WriteLine("You Cannot Invite Teachers!");
            }
            else if (human.Role==ERole.Student)
            {
                human.invited = true;
                st.invited = true;
                Random random = new Random();
                DateTime dt2 = DateTime.Now;
                DateTime randtime = dt2.AddMinutes(random.Next(60));
                st.Ticket = randtime;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student Invited Successfully!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("They Will Be Registered Once They Accept the Invitation.");
            }
        }
        public void SendTicket(Student st, DateTime dt)
        {
            st.Ticket = dt;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ticket with TIME: {dt:f} Generated Successfully!");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Wait.Dot("Sending", 3);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Sent!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Notify the Student by Sending Message.");
        }
        public void ChooseHour(string hour, Course cr)
        {
            switch (hour)
            {
                case "a":
                    cr.Hour.Add(8);
                    break;
                case "b":
                    cr.Hour.Add(10);
                    break;
                case "c":
                    cr.Hour.Add(13);
                    break;
                case "d":
                    cr.Hour.Add(14);
                    break;
                case "e":
                    cr.Hour.Add(16);
                    break;
                default:
                    Message.Default(3);
                    break;
            }
        }
        public void ChooseDay(string day, Course bt, string Hour)
        {
            switch (day)
            {
                case "a":
                    bt.DayOfWeek.Add(DayOfWeek.Saturday);
                    ChooseHour(Hour, bt);
                    break;
                case "b":
                    bt.DayOfWeek.Add(DayOfWeek.Sunday);
                    ChooseHour(Hour, bt);
                    break;
                case "c":
                    bt.DayOfWeek.Add(DayOfWeek.Monday);
                    ChooseHour(Hour, bt);
                    break;
                case "d":
                    bt.DayOfWeek.Add(DayOfWeek.Tuesday);
                    ChooseHour(Hour, bt);
                    break;
                case "e":
                    bt.DayOfWeek.Add(DayOfWeek.Wednesday);
                    ChooseHour(Hour, bt);
                    break;
                case "f":
                    bt.DayOfWeek.Add(DayOfWeek.Thursday);
                    ChooseHour(Hour, bt);
                    break;
                case "g":
                    bt.DayOfWeek.Add(DayOfWeek.Friday);
                    ChooseHour(Hour, bt);
                    break;
                default:
                    Message.Default(3);
                    break;
            }
        }
    }
}

