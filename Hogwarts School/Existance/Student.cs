using System;
using System.Reflection;

namespace Hogwarts
{
    public struct Score { public int Sp; public int Mg; public int Ch; public int Bt1; public int Bt2; public int Bt3; public int Bt4; }

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
		public string DormNumber { get; set; } 
		public bool NewSTMessage { get; set; }
        public List<Course> Courses = new List<Course>();
        public DateTime Ticket { get; set; }
        public bool Registered { get; set; }
        public bool NewTerm { get; set; } = true;
        List<SMessage> STMessage = new List<SMessage>();
        public bool NewDumbMessage;
        public void SendMessageToST(string message, Student st)
        {
            STMessage.Insert(0, new SMessage(message, st.FirstName + " " + st.LastName));
            NewSTMessage = true;
            Console.WriteLine("Message Sent Succussfully!");
        }
        public Score Score = new Score();
        public void ScoreCollector(int Score, Course Cr)
        {
            switch (Cr.CourseType)
            {
                case CourseType.Ch:
                    this.Score.Ch = Score;
                    break;
                case CourseType.Mg:
                    this.Score.Mg = Score;
                    break;
                case CourseType.Sp:
                    this.Score.Sp = Score;
                    break;
                case CourseType.Bot1:
                    this.Score.Bt1 = Score;
                    break;
                case CourseType.Bot2:
                    this.Score.Bt2 = Score;
                    break;
                case CourseType.Bot3:
                    this.Score.Bt3 = Score;
                    break;
                case CourseType.Bot4:
                    this.Score.Bt4 = Score;
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowScore()
        {
            if(this.Score.Ch!=0)
            {
                Console.WriteLine($"Chemistry: {this.Score.Ch}");
            }
            if (this.Score.Mg != 0)
            {
                Console.WriteLine($"Magic Knowledge: {this.Score.Mg}");
            }
            if (this.Score.Sp != 0)
            {
                Console.WriteLine($"Sport: {this.Score.Sp}");
            }
            if (this.Score.Bt1 != 0)
            {
                Console.WriteLine($"Botanical1: {this.Score.Bt1}");
            }
            if (this.Score.Bt2 != 0)
            {
                Console.WriteLine($"Botanical2: {this.Score.Ch}");
            }
            if (this.Score.Bt3 != 0)
            {
                Console.WriteLine($"Botanical3: {this.Score.Ch}");
            }
            if (this.Score.Bt4 != 0)
            {
                Console.WriteLine($"Botanical4: {this.Score.Ch}");
            }
        }
        public void Inbox_UnRead()
        {
            bool isThereAnyunreadMessage = false;
            for (int i = 0; i < STMessage.Count; i++)
            {
                if (!STMessage[i].Seen)
                {
                    isThereAnyunreadMessage = true;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"{(i + 1) + "-",-3} ");
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
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"{(i + 1) + "-",-3} ");
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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"{(i + 1) + "-",-3} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{STMessage[i].message}");
                Console.WriteLine();
            }
        }
        public void Train(Student st)
        {
            DateTime dt1 = st.Ticket.AddMinutes(-15);
            DateTime dt2 = st.Ticket.AddMinutes(5);
            //Console.WriteLine(dt1.ToLongDateString());
            //Console.WriteLine(dt2.ToLongDateString());

            int result1 = DateTime.Compare(dt1, DateTime.Now);
            int result2 = DateTime.Compare(DateTime.Now ,dt2);
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
        public void ShowExercise()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Here's Your Exercise:");
            Console.ForegroundColor = ConsoleColor.White;
            for(int i=0; i<this.Courses.Count;i++)
            {
                if (this.Courses[i].Exercise != null)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Courses[i].Name + ": ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Courses[i].Exercise);
                    Console.WriteLine();
                }
            }
        }
        public void Jungle(Botanical bt)
        {
            switch (this.Term)
            {
                case 1:
                    GraphicalPlant1(bt.Term1[0]);
                    GraphicalPlant2(bt.Term1[1]);
                    GraphicalPlant3(bt.Term1[2]);
                    GraphicalPlant4(bt.Term1[3]);
                    GraphicalPlant5(bt.Term1[4]);
                    break;
                case 2:
                    GraphicalPlant1(bt.Term2[0]);
                    GraphicalPlant2(bt.Term2[1]);
                    GraphicalPlant3(bt.Term2[2]);
                    GraphicalPlant4(bt.Term2[3]);
                    GraphicalPlant5(bt.Term2[4]);
                    break;
                case 3:
                    GraphicalPlant1(bt.Term3[0]);
                    GraphicalPlant2(bt.Term3[1]);
                    GraphicalPlant3(bt.Term3[2]);
                    GraphicalPlant4(bt.Term3[3]);
                    GraphicalPlant5(bt.Term3[4]);
                    break;
                case 4:
                    GraphicalPlant1(bt.Term4[0]);
                    GraphicalPlant2(bt.Term4[1]);
                    GraphicalPlant3(bt.Term4[2]);
                    GraphicalPlant4(bt.Term4[3]);
                    GraphicalPlant5(bt.Term4[4]);
                    break;
                default:
                    break;
            }
        }


        public void GraphicalPlant1(Plant plant)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("|\\\\|///|", 5, 3);
            WriteAt($" ------({plant.Count})", 5, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt($"1.{plant.Name,-7}", 3, 5);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GraphicalPlant2(Plant plant)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("|\\\\|///|", 21, 4);
            WriteAt($" ------({plant.Count})", 21, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt($"2.{plant.Name,-7}", 19, 6);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GraphicalPlant3(Plant plant)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("|\\\\|///|", 3, 7);
            WriteAt($" ------({plant.Count})", 3, 8);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt($"3.{plant.Name,-7}", 1, 9);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GraphicalPlant4(Plant plant)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("|\\\\|///|", 17, 9);
            WriteAt($" ------({plant.Count})", 17, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt($"4.{plant.Name,-7}", 15, 11);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GraphicalPlant5(Plant plant)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("|\\\\|///|", 33, 8);
            WriteAt($" ------({plant.Count})", 33, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt($"5.{plant.Name,-7}", 31, 10);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static int origRow;
        public static int origCol;
        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}

