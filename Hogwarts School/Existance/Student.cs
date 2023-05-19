using System;
using System.Reflection;

namespace Hogwarts
{
    public class SMessage
    {
        public SMessage(string message , string sender)
        {
            this.message = message;
            this.Sender = sender;
        }
        public string Sender { get; set; }
        public string message { get; set; }
        public bool Seen { get; set; }
    }
    public class Student : AllowedPerson
	{
		public Student(Human human):base(human)
		{

		}

        public int PassedUnit { get; set; } = 0;
		public int Term { get; set; } = 1;
		public int DormNumber { get; set; } //Khabgah
		public bool NewSTMessage { get; set; }
        public List<Course> Courses = new List<Course>();
        public DateTime Ticket { get; set; }
        public bool Registered { get; set; }

        List<SMessage> STMessage = new List<SMessage>();
        public bool NewDumbMessage;
        public void SendMessageToST(string message, Student st)
        {
            STMessage.Insert(0, new SMessage(message, st.FirstName + " " + st.LastName));
            NewSTMessage = true;
            Console.WriteLine("Message Sent Succussfully!");
        }

        public void Inbox_UnRead()
        {
            bool isThereAnyunreadMessage = false;
            for (int i = 0; i < STMessage.Count; i++)
            {
                if (!STMessage[i].Seen)
                {
                    isThereAnyunreadMessage = true;
                    Console.Write($"{(i + 1) + "-",-3} ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"{STMessage[i].Sender + ": ",-10}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{STMessage[i].message}");
                    Console.WriteLine();
                    STMessage[i].Seen = true;
                }
            }
            if (!isThereAnyunreadMessage) Console.WriteLine("Empty!");
        }
        public void Inbox_Read()
        {
            bool isThereAnyreadMessage = false;
            for (int i = 0; i < STMessage.Count; i++)
            {
                if (STMessage[i].Seen)
                {
                    isThereAnyreadMessage = true;
                    Console.Write($"{(i + 1) + "-",-3} ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"{STMessage[i].Sender + ": ",-10}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{STMessage[i].message}");
                    Console.WriteLine();
                }
            }
            if (!isThereAnyreadMessage) Console.WriteLine("Empty!");
        }
        public void Inbox_All()
        {
            for (int i = 0; i < STMessage.Count; i++)
            {
                Console.Write($"{(i + 1) + "-",-3} ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"{STMessage[i].Sender + ": ",-12}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{STMessage[i].message}");
                Console.WriteLine();
            }
        }
        public void Train(Student st)
        {
            DateTime dt1 = st.Ticket.AddMinutes(-15);
            DateTime dt2 = st.Ticket.AddMinutes(5);
            int result1 = DateTime.Compare(dt1, st.Ticket);
            int result2 = DateTime.Compare(st.Ticket,dt2);
            if (result1 > 0) Console.WriteLine("It's too early to get in! Come back later.");//return -1; //too early
            if (result1 <= 0 && result2 <= 0) Console.WriteLine("Welcome to HOGWARTS!");//return 0; //on time
            if (result2 > 0)
            {
                Console.WriteLine("It's too late to get in!");//return 1; //too late
                Console.WriteLine("Wait for Next Train in 1 hour.");
                st.Ticket = st.Ticket.AddHours(1);
            }
            //return 0;
        }
    }
}

