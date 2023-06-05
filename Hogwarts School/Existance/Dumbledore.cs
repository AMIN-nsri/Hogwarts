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
            if (DumbMessage.Count > 0)
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
            else Console.WriteLine("Empty!");
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
                    Console.WriteLine("Added Successfully!");
                    break;
                case "b":
                    cr.Hour.Add(10);
                    Console.WriteLine("Added Successfully!");
                    break;
                case "c":
                    cr.Hour.Add(13);
                    Console.WriteLine("Added Successfully!");
                    break;
                case "d":
                    cr.Hour.Add(14);
                    Console.WriteLine("Added Successfully!");
                    break;
                case "e":
                    cr.Hour.Add(16);
                    Console.WriteLine("Added Successfully!");
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
    
        public void ShowDorm(Student st)
        {
            switch (st.Gender)
            {
                case EGender.Male:
                    switch (st.Group.Type)
                    {
                        case EGroupType.Gryffindor:
                            st.DormNumber = Dorm.makeGryfDormCode();
                            break;
                        case EGroupType.Hufflepuff:
                            st.DormNumber = Dorm.makeHuffDormCode();
                            break;
                        case EGroupType.Ravenclaw:
                            st.DormNumber = Dorm.makeRavenDormCode();
                            break;
                        case EGroupType.Slytherin:
                            st.DormNumber = Dorm.makeSlyDormCode();
                            break;
                        default:
                            break;
                    }
                    break;
                case EGender.Female:
                    switch (st.Group.Type)
                    {
                        case EGroupType.Gryffindor:
                            st.DormNumber = Dorm.makeGryfDormCode();
                            break;
                        case EGroupType.Hufflepuff:
                            st.DormNumber = Dorm.makeHuffDormCode();
                            break;
                        case EGroupType.Ravenclaw:
                            st.DormNumber = Dorm.makeRavenDormCode();
                            break;
                        case EGroupType.Slytherin:
                            st.DormNumber = Dorm.makeSlyDormCode();
                            break;
                        default:
                            break;
                    }
                    break;
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Your Dorm Number is: {st.DormNumber}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public int CourseComparison(Student st, Course teachercourse)
        {
            for (int i = 0; i < st.Courses.Count; i++)
            {
                if (st.Courses[i] == teachercourse)
                {
                    return i;
                }
            }
            return -1;
        }

        //public int StudentCourseIndexFinder(Student st, int CrIndex)
        //{
        //    for (int i = 0; i < st.Courses.Count; i++)
        //    {
        //        if (st.Courses[i] == teacherCr)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        public bool CourseInterrupt(Student st, Course cr)
        {
            for(int i=0; i<st.Courses.Count;i++)
            {
                for(int j=0;j< st.Courses[i].DayOfWeek.Count;j++)
                {
                    for (int k = 0; k < cr.DayOfWeek.Count; k++)
                    {
                        if ((st.Courses[i].DayOfWeek[j] == cr.DayOfWeek[k]) && (st.Courses[i].Hour[j] == cr.Hour[k])) return true;
                    }
                }
            }
            return false;
        }
        public bool CourseInterruptTE(Teacher te, Course cr)
        {
            for (int i = 0; i < te.Courses.Count; i++)
            {
                for (int j = 0; j < te.Courses[i].DayOfWeek.Count; j++)
                {
                    for (int k = 0; k < cr.DayOfWeek.Count; k++)
                    {
                        if ((te.Courses[i].DayOfWeek[j] == cr.DayOfWeek[k]) && (te.Courses[i].Hour[j] == cr.Hour[k])) return true;
                    }
                }
            }
            return false;
        }
        public bool CourseDuplicateTime(Course cr,string Day, string Hour)
        {

            DayOfWeek day = DayOfWeek.Friday;
            int hour = 0;
            switch (Day)
            {
                case "a":
                    day = DayOfWeek.Saturday;
                    break;
                case "b":
                    day = DayOfWeek.Sunday;
                    break;
                case "c":
                    day = DayOfWeek.Monday;
                    break;
                case "d":
                    day = DayOfWeek.Tuesday;
                    break;
                case "e":
                    day = DayOfWeek.Wednesday;
                    break;
                case "f":
                    day = DayOfWeek.Thursday;
                    break;
                case "g":
                    day = DayOfWeek.Friday;
                    break;
                default:
                    break;
            }
            switch (Hour)
            {
                case "a":
                    hour = 8;
                    break;
                case "b":
                    hour = 10;
                    break;
                case "c":
                    hour = 13;
                    break;
                case "d":
                    hour = 14;
                    break;
                case "e":
                    hour = 16;
                    break;
                default:
                    break;
            }
            for (int i=0;i<cr.DayOfWeek.Count;i++)
            {
                if (cr.DayOfWeek[i] == day && cr.Hour[i] == hour) return true;
            }
            return false;
        }
        public int STCourseIndex(Course CourseList, Student st)
        {
            for (int j = 0; j < st.Courses.Count; j++)
            {
                if (CourseList == st.Courses[j]) return j;
            }
            return -1;
        }

        public void ShowCourses(List<Course> CourseList, Student st)
        {
            Console.WriteLine("Select One by index:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"",-2}  {"Course Name",-15} {"Capacity",-9} Time");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < CourseList.Count; i++)
            {
                int STcourseindex = STCourseIndex(CourseList[i], st);
                if (STcourseindex >= 0)
                {
                    int score = 0;
                    switch (st.Courses[STcourseindex].CourseType)
                    {
                        case CourseType.Ch:
                            score = st.Score.Ch;
                            break;
                        case CourseType.Mg:
                            score = st.Score.Mg;
                            break;
                        case CourseType.Sp:
                            score = st.Score.Sp;
                            break;
                        case CourseType.Bot1:
                            score = st.Score.Bt1;
                            break;
                        case CourseType.Bot2:
                            score = st.Score.Bt2;
                            break;
                        case CourseType.Bot3:
                            score = st.Score.Bt3;
                            break;
                        case CourseType.Bot4:
                            score = st.Score.Bt4;
                            break;
                        default:
                            break;
                    }
                    if (score < 10 && score>0)
                    {
                        Console.Write($"{i + 1,-2}- {CourseList[i].Name,-15} {CourseList[i].Registered + "/" + CourseList[i].Capacity,-9} ");
                        for (int j = 0; j < CourseList[i].DayOfWeek.Count; j++)
                        {
                            Console.Write($"({CourseList[i].DayOfWeek[j] + " " + CourseList[i].Hour[j]})");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.Write($"{i + 1,-2}- {CourseList[i].Name,-15} {CourseList[i].Registered + "/" + CourseList[i].Capacity,-9} ");
                    for (int j = 0; j < CourseList[i].DayOfWeek.Count; j++)
                    {
                        Console.Write($"({CourseList[i].DayOfWeek[j] + " " + CourseList[i].Hour[j]})");
                    }
                    Console.WriteLine();
                }
            }
        }
        
    }
}

