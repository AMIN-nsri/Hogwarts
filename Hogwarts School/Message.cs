using System;
using System.Globalization;

namespace Hogwarts
{
	public class Message:Dumbledore
	{
		public Message()
		{
		}
        // Showing Program Topic
        public static void Topic()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("-------------------------Hogwarts School of Wizards-------------------------");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("[b]ack");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Showing System Time
        public static void Time()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            DateTime dt = DateTime.Now;
            
            Console.WriteLine($"{dt.Year}/{dt.Month}/{dt.Day}                                                           {dt.ToShortTimeString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Loading Please Wait
        public static void Loading(int pausetime)
        {
            Wait.Dot("Loading Please Wait", pausetime);
        }
        // Program Menu
        public static void Program()
        {
            Console.Clear();
            Message.Time();
            Message.Topic();
            Message.Loading(1);
        }
        // Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("Choose one to start(type key letter):");
            Console.WriteLine("Dumbledore(D)");
            Console.WriteLine("Teacher(T)");
            Console.WriteLine("Student(S)");
            Console.WriteLine("Exit(E)");
        }
        // Default Switch Case
        public static void Default(int pausetime)
        {
            Message.Program();
            Console.WriteLine("Please Enter Valid Value!");
            Wait.Dot("", pausetime);
        }
        // First Login
        public static void FirstLogin()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It's your First Login!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please Use Dumbledore Menu.");
        }
        // Wrong Username or Password
        public static void Wrong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong Username or Password!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please try again or Enter 'b' to turn back.");
        }
        public static void LogedIn()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Logged in successfully.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // *Welcome admin
        public static void Welcome(string admin)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Welcome Dear {admin}!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Dumbledore Menu
        public static void DumbledoreMenu()
        {
            
            Console.WriteLine("Choose one (type key letter):");
            Console.WriteLine("Send Invitation(S)");
            Console.WriteLine("Send Ticket(T)");
            Console.WriteLine("Inbox(I)");
            Console.WriteLine("Send Message(M)");
            //Console.WriteLine("Student(S)");
            Console.WriteLine("Exit(E)");
        }
        public static void NewMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You have new Message!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void InboxMenu()
        {
            Console.WriteLine("Unread Messages(U)");
            Console.WriteLine("Read Messages(R)");
            Console.WriteLine("All Messages(A)");
        }
        public static void Congrats(Student st)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if(st.Gender==EGender.Female)
            {
                Console.WriteLine($"Congratulations Ms. {st.LastName}!");
            }
            else Console.WriteLine($"Congratulations Mr. {st.LastName}!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You've been Invited to Hogwarts!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Registered(Student st)
        {
            Random randomnum = new Random();
            int Seat = randomnum.Next(1,20);
            int Wagon = randomnum.Next(1,11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Registration Completed Successfully!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Here's Your Ticket:");
            Console.WriteLine($"WAGON: {Wagon}      SEAT: {Seat}");
            Console.WriteLine($"TIME: {st.Ticket:f}");
            if (st.Bag) Console.WriteLine($"BAG: YES");
            else Console.WriteLine($"BAG: NO");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please Be at the Station 15 Minutes Earlier!");
            Console.ForegroundColor = ConsoleColor.White;
            //st.invited = false;
            st.Registered = true;
        }
        public static void StudentMenu()
        {
            Console.WriteLine("Choose one (type key letter):");
            Console.WriteLine("Inbox(I)"); //
            Console.WriteLine("Go to Jungle(J)");
            Console.WriteLine("See Final Scores(F)"); //
            Console.WriteLine("Weekly Schedule(S)"); //
            Console.WriteLine("Select Units(U)"); //
            Console.WriteLine("Send Message to Dumbledore(M)"); //
            Console.WriteLine("Enter Train(T)"); //
            Console.WriteLine("Exit(E)"); //
        }
        public static void TeacherMenu()
        {
            Console.WriteLine("Choose one (type key letter):");
            Console.WriteLine("Present a Lesson(L)"); //
            Console.WriteLine("Define a Exercise(DE)");
            Console.WriteLine("Enter Final Score(S)"); //
            Console.WriteLine("Exit(E)"); //
        }
        public static void Lessons()
        {
            Console.WriteLine("Choose Lesson:");
            Console.WriteLine("(a) Botanical");
            Console.WriteLine("(b) Chemistry");
            Console.WriteLine("(c) Magic Knowledge");
            Console.WriteLine("(d) Sport");
        }
        public static void WeekDays()
        {
            Console.WriteLine("Choose Day:");
            Console.WriteLine("(a) Saturday");
            Console.WriteLine("(b) Sunday");
            Console.WriteLine("(c) Monday");
            Console.WriteLine("(d) Tuesday");
            Console.WriteLine("(e) Wednesday");
            Console.WriteLine("(f) Thursday");
            Console.WriteLine("(g) Friday");
            Console.WriteLine("(Q) Done");
        }
        public static void Hours()
        {
            Console.WriteLine("Choose Hour:");
            Console.WriteLine("(a) 8-10");
            Console.WriteLine("(b) 10-12");
            Console.WriteLine("(c) 13-14");
            Console.WriteLine("(d) 14-16");
            Console.WriteLine("(e) 16-18");
        }
    }
}

