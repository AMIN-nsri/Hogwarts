using System.Collections.Generic;
using System.Globalization;
using System.Collections;
using System;
using System.Threading;
using System.Linq;
using System.Text;

namespace Hogwarts
{
    class Program
    {
        public static void Main()
        {
            //***** Singletone Admin Pattern
            Dumbledore dumbledore = new Dumbledore();
            //***** Give Instances
            List<Human> HumanList = new List<Human>();
            List<Student> StudentList = new List<Student>();
            List<Teacher> TeacherList = new List<Teacher>();
            List<Course> CourseList = new List<Course>();
            List<Botanical> BotanicalList = new List<Botanical>();
            List<Chemistry> ChemistryList = new List<Chemistry>();
            List<Magic> MagicList = new List<Magic>();
            List<Sport> SportList = new List<Sport>();

            //***** Reading File
            using (StreamReader file = new StreamReader("file.tsv"))
            {
                string In;
                while ((In = file.ReadLine()) != null)
                {
                    Human human1 = new Human();
                    string[] data = In.Split("\t").ToArray<string>();

                    human1.FirstName = data[0];
                    human1.LastName = data[1];
                    human1.Birth = data[2];
                    human1.Gender = (EGender)Enum.Parse(typeof(EGender), data[3], true);
                    human1.Father = data[4];
                    human1.Username = data[5];
                    human1.Password = data[6];
                    human1.Blood = (EBlood) Enum.Parse(typeof(EBlood), data[7].Replace(" ",""), true);
                    human1.Role = (ERole) Enum.Parse(typeof(ERole), data[8] , true);

                    //*** Check & Add to Student/Teacher List
                    if (ERole.Student == human1.Role) StudentList.Add(new Student(human1));
                    if (ERole.Teacher == human1.Role) TeacherList.Add(new Teacher(human1));
                    
                    HumanList.Add(human1);
                }
                file.Close();
            }

            //*********** TTTTEEEESSSSTTTT*************

            //Botanical botanical = new Botanical();
            //botanical.Capacity = 10;
            //botanical.Name = "botanical3";
            //botanical.Registered = 0;
            //botanical.Term = 1;
            //botanical.DayOfWeek = DayOfWeek.Monday;
            //botanical.Hour = 10;
            //botanical.Term1.Add("hich");
            //botanical.Term2.Add("hich2");
            //botanical.Term3.Add("hich3");
            //botanical.Term4.Add("hich4");
            //Chemistry chemistry = new Chemistry();
            //chemistry.Name = "chem1";
            //chemistry.Capacity = 10;
            //chemistry.Registered = 1;
            //chemistry.Term = 2;
            //chemistry.DayOfWeek = DayOfWeek.Wednesday;
            //chemistry.Hour = 14;

            //Course course1 = new Course();
            //course1.Name = "botanical1";
            //course1.DayOfWeek = DayOfWeek.Monday;
            //course1.Hour = 13;
            //course1.Capacity = 20;
            //course1.Registered = 3;
            //course1.Term = 1;

            //StudentList[0].Courses.Add(chemistry);
            //StudentList[0].Courses.Add(course1);
            //StudentList[0].Courses.Add(botanical);

            //StudentList[0].ScheduleTable(StudentList[0].Schedule(StudentList[0].Courses));
            //Console.WriteLine(StudentList[1].Password + " " + StudentList[1].Username);

            bool FirstLogin = true;
            Message.Program();
            Message.MainMenu();
            String input = Console.ReadLine();
            DateTime FirstRunTime = DateTime.Now;
            while (input != "E")
            {
                switch (input)
                {
                    case "D":
                        //*** Dumbldore Login check
                        Message.Program();
                        Console.WriteLine("Enter your Username and Password below");
                        Console.Write("User Name: ");
                        input = Console.ReadLine();
                        string username = input;
                        Console.Write("Password: ");
                        input = GetPassword();
                        string password = input;
                        while (!dumbledore.LoginCheck(username, password))
                        {
                            Message.Program();
                            Message.Wrong();
                            Console.WriteLine("Enter your Username and Password below");
                            Console.Write("User Name: ");
                            input = Console.ReadLine();
                            if (input == "b")
                            {
                                Wait.ClearLine();
                                Wait.ClearLine();
                                Wait.ClearLine();
                                Wait.ClearLine();
                                break;
                            }
                            username = input;
                            Console.Write("Password: ");
                            input = GetPassword();
                            if (input == "b")
                            {
                                Wait.ClearLine();
                                Wait.ClearLine();
                                Wait.ClearLine();
                                Wait.ClearLine();
                                Wait.ClearLine();
                                break;
                            }
                            password = input;
                        }
                        if (dumbledore.LoginCheck(username, password))
                        {
                            FirstLogin = false;
                            Message.Program();
                            Message.LogedIn();
                            //*** Dumbldore Menu
                            bool DumbledoreMenu = true;
                            while (DumbledoreMenu)
                            {
                                Message.Loading(2);
                                Message.Program();
                                Message.Welcome("Dumbledore");
                                if (dumbledore.NewDumbMessage)
                                {
                                    Message.NewMessage();
                                }
                                Message.DumbledoreMenu();
                                string input2 = Console.ReadLine();
                                switch (input2)
                                {
                                    // Sending Message
                                    case "M":
                                        Message.Program();
                                        Console.WriteLine("Enter Student ID:");
                                        string ID = Console.ReadLine();
                                        int index = dumbledore.SearchSTByID(ID, StudentList);
                                        if (index < 0) Console.WriteLine("User Not Found!");
                                        else
                                        {
                                            Console.WriteLine($"Sending Message to: {StudentList[index].FirstName} {StudentList[index].LastName}");
                                            Console.WriteLine("Enter Your Message:");
                                            string message = Console.ReadLine();
                                            StudentList[index].SendMessageToST(message, StudentList[index]);
                                        }
                                        break;
                                    // Sending Tickets
                                    case "T":
                                        Message.Program();
                                        Console.WriteLine("Enter Student ID:");
                                        string ID2 = Console.ReadLine();
                                        int index2 = dumbledore.SearchSTByID(ID2, StudentList);
                                        if (index2 < 0) Console.WriteLine("User Not Found!");
                                        else
                                        {
                                            Wait.ClearLine();
                                            Wait.ClearLine();
                                            Console.WriteLine($"Sending Ticket to '{StudentList[index2].FirstName} {StudentList[index2].LastName}':");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Wait.Dot("Generating", 4);
                                            Random random = new Random();
                                            DateTime dt2 = DateTime.Now;
                                            DateTime randtime = dt2.AddDays(random.Next(1)).AddHours(random.Next(24)).AddMinutes(random.Next(60));
                                            dumbledore.SendTicket(StudentList[index2], randtime);
                                            Console.WriteLine("Press any key to turn back");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "b":
                                        DumbledoreMenu = false;
                                        break;
                                    // Inbox
                                    case "I":
                                        Message.Program();
                                        bool inbox = true;
                                        while(inbox)
                                        {
                                            dumbledore.NewDumbMessage = false;
                                            Message.Program();
                                            Message.InboxMenu();
                                            string input3 = Console.ReadLine();
                                            switch (input3)
                                            {
                                                case "b":
                                                    inbox = false;
                                                    break;
                                                case "A":
                                                    Message.Program();
                                                    dumbledore.Inbox_All();
                                                    string input4 = Console.ReadLine();
                                                    switch (input4)
                                                    {
                                                        case "b":
                                                            inbox = false;
                                                            break;
                                                        default:
                                                            Message.Default(3);
                                                            break;
                                                    }
                                                    break;
                                                case "U":
                                                    Message.Program();
                                                    dumbledore.Inbox_UnRead();
                                                    string input5 = Console.ReadLine();
                                                    switch (input5)
                                                    {
                                                        case "b":
                                                            inbox = false;
                                                            break;
                                                        default:
                                                            Message.Default(3);
                                                            break;
                                                    }
                                                    break;
                                                case "R":
                                                    Message.Program();
                                                    dumbledore.Inbox_Read();
                                                    input5 = Console.ReadLine();
                                                    switch (input5)
                                                    {
                                                        case "b":
                                                            inbox = false;
                                                            break;
                                                        default:
                                                            Message.Default(3);
                                                            break;
                                                    }
                                                    break;
                                                default:
                                                    Message.Default(3);
                                                    break;
                                            }
                                        }
                                        break;
                                    // Inviting
                                    case "S":
                                        Message.Program();
                                        Console.WriteLine("Enter Human ID:");
                                        string HID = Console.ReadLine();
                                        int index3 = dumbledore.SearchByID(HID, HumanList);
                                        int stindex = dumbledore.SearchSTByID(HID, StudentList);
                                        if (index3 < 0) Console.WriteLine("Human Not Found!");
                                        else
                                        {
                                            dumbledore.Invite(HumanList[index3], StudentList[stindex]);
                                            Console.ReadKey();
                                        }
                                        //Console.WriteLine($"Name.{index3}=> {HumanList[index3].FirstName + " " + HumanList[index3].LastName}");
                                        //Console.WriteLine($"Invited=> {HumanList[index3].invited}");
                                        //Console.WriteLine($"Name.00=> {StudentList[0].FirstName + " " + StudentList[0].LastName}");
                                        //Console.WriteLine($"Invited=> {StudentList[0].invited}");
                                        //Console.ReadKey();
                                        break;
                                    case "E":
                                        System.Environment.Exit(0);
                                        break;
                                    default:
                                        Message.Default(3);
                                        break;
                                }
                            }
                        }
                            break;
                    // ***Teacher Menu
                    case "T":
                        Message.Program();
                        bool TeacherMenu = true;
                        while(TeacherMenu)
                        {
                            if (FirstLogin)
                            {
                                Message.FirstLogin();
                                Thread.Sleep(2000);
                                Message.Loading(1);
                                break;
                            }
                            else
                            {
                                //Login check
                                Message.Program();
                                Console.WriteLine("Enter your Username and Password below");
                                Console.Write("User Name: ");
                                input = Console.ReadLine();
                                string username3 = input;
                                Console.Write("Password: ");
                                input = GetPassword();
                                string password3 = input;
                                while (dumbledore.TELoginCheck(username3, password3, TeacherList) < 0)
                                {
                                    Message.Program();
                                    Message.Wrong();
                                    Console.WriteLine("Enter your Username and Password below");
                                    Console.Write("User Name: ");
                                    input = Console.ReadLine();
                                    if (input == "b")
                                    {
                                        Wait.ClearLine();
                                        Wait.ClearLine();
                                        Wait.ClearLine();
                                        Wait.ClearLine();
                                        break;
                                    }
                                    username3 = input;
                                    Console.Write("Password: ");
                                    input = GetPassword();
                                    if (input == "b")
                                    {
                                        Wait.ClearLine();
                                        Wait.ClearLine();
                                        Wait.ClearLine();
                                        Wait.ClearLine();
                                        Wait.ClearLine();
                                        break;
                                    }
                                    password3 = input;
                                }
                                int index = dumbledore.TELoginCheck(username3, password3, TeacherList);
                                if (index >= 0)
                                {
                                    Message.Program();
                                    Message.LogedIn();
                                    bool TeacherMenu2 = true;
                                    while (TeacherMenu2)
                                    {
                                        Message.Loading(2);
                                        Message.Program();
                                        Message.Welcome(TeacherList[index].FirstName + " " + TeacherList[index].LastName);
                                        TeacherList[index].SimultaneousTeaching = TeacherList[index].Random();
                                        Message.TeacherMenu();
                                        string input2 = Console.ReadLine();
                                        switch (input2)
                                        {
                                            case "L":
                                                Message.Program();
                                                Message.Lessons();
                                                string input4 = Console.ReadLine();
                                                switch (input4)
                                                {
                                                    case "a":
                                                        Botanical bt = new Botanical();
                                                        bt.Teacher = TeacherList[index];
                                                        Message.Program();
                                                        Console.Write("Enter Your Course Topic:");
                                                        bt.Name = Console.ReadLine();
                                                        Console.Write("Term:");
                                                        bt.Term = int.Parse(Console.ReadLine());
                                                        Console.Write("Capacity:");
                                                        bt.Capacity = int.Parse(Console.ReadLine());
                                                        string Day;
                                                        do
                                                        {
                                                            Message.Program();
                                                            Message.WeekDays();
                                                            Day = Console.ReadLine();
                                                            if (Day == "Q") break;
                                                            Message.Program();
                                                            Message.Hours();
                                                            string Hour = Console.ReadLine();
                                                            dumbledore.ChooseDay(Day, bt, Hour);
                                                        } while (Day != "Q");
                                                        CourseList.Add(bt);
                                                        BotanicalList.Add(bt);
                                                        TeacherList[index].Courses.Add(bt);
                                                        break;
                                                    case "b":
                                                        Message.Program();
                                                        Chemistry ch = new Chemistry();
                                                        ch.Teacher = TeacherList[index];
                                                        Console.Write("Enter Your Course Topic:");
                                                        ch.Name = Console.ReadLine();
                                                        Console.Write("Term:");
                                                        ch.Term = int.Parse(Console.ReadLine());
                                                        Console.Write("Capacity:");
                                                        ch.Capacity = int.Parse(Console.ReadLine());
                                                        do
                                                        {
                                                            Message.Program();
                                                            Message.WeekDays();
                                                            Day = Console.ReadLine();
                                                            if (Day == "Q") break;
                                                            Message.Program();
                                                            Message.Hours();
                                                            string Hour = Console.ReadLine();
                                                            dumbledore.ChooseDay(Day, ch, Hour);
                                                        } while (Day != "Q");
                                                        CourseList.Add(ch);
                                                        ChemistryList.Add(ch);
                                                        TeacherList[index].Courses.Add(ch);
                                                        break;
                                                    case "c":
                                                        Message.Program();
                                                        Magic mg = new Magic();
                                                        mg.Teacher = TeacherList[index];
                                                        Console.Write("Enter Your Course Topic:");
                                                        mg.Name = Console.ReadLine();
                                                        Console.Write("Term:");
                                                        mg.Term = int.Parse(Console.ReadLine());
                                                        Console.Write("Capacity:");
                                                        mg.Capacity = int.Parse(Console.ReadLine());
                                                        do
                                                        {
                                                            Message.Program();
                                                            Message.WeekDays();
                                                            Day = Console.ReadLine();
                                                            if (Day == "Q") break;
                                                            Message.Program();
                                                            Message.Hours();
                                                            string Hour = Console.ReadLine();
                                                            dumbledore.ChooseDay(Day, mg, Hour);
                                                        } while (Day != "Q");
                                                        CourseList.Add(mg);
                                                        MagicList.Add(mg);
                                                        TeacherList[index].Courses.Add(mg);
                                                        break;
                                                    case "d":
                                                        Message.Program();
                                                        Sport sp = new Sport();
                                                        sp.Teacher = TeacherList[index];
                                                        Console.Write("Enter Your Course Topic:");
                                                        sp.Name = Console.ReadLine();
                                                        Console.Write("Term:");
                                                        sp.Term = int.Parse(Console.ReadLine());
                                                        Console.Write("Capacity:");
                                                        sp.Capacity = int.Parse(Console.ReadLine());
                                                        do
                                                        {
                                                            Message.Program();
                                                            Message.WeekDays();
                                                            Day = Console.ReadLine();
                                                            if (Day == "Q") break;
                                                            Message.Program();
                                                            Message.Hours();
                                                            string Hour = Console.ReadLine();
                                                            dumbledore.ChooseDay(Day, sp, Hour);
                                                        } while (Day != "Q");
                                                        CourseList.Add(sp);
                                                        SportList.Add(sp);
                                                        TeacherList[index].Courses.Add(sp);
                                                        break;
                                                    default:
                                                        Message.Default(3);
                                                        break;
                                                }
                                                break;
                                            case "T":

                                                break;
                                            case "S":
                                                //Console.WriteLine("Enter Student ID:");
                                                //string StID = Console.ReadLine();
                                                //int STindex = dumbledore.SearchSTByID(StID, StudentList);
                                                //if (STindex < 0) Console.WriteLine("User Not Found!");
                                                //else if(STindex>=0)
                                                //{
                                                //    int CourseSearch = dumbledore.CourseComparison(StudentList[STindex], TeacherList[index]);
                                                //    if (CourseSearch>=0)
                                                //    {
                                                //        Console.WriteLine($"Entering {StudentList[STindex].FirstName} {StudentList[STindex].LastName}'s {StudentList[STindex].Courses[CourseSearch].Name} SCORE:");
                                                //        int score = int.Parse(Console.ReadLine());
                                                //        StudentList[STindex].Courses[CourseSearch].Score = score;
                                                //    }
                                                //    else Console.WriteLine("You Don't Have Any");
                                                //}
                                                Console.WriteLine("Choose Lesson by index:");
                                                for (int i = 0; i < TeacherList[index].Courses.Count; i++)
                                                {
                                                    Console.WriteLine($"{i + 1}- {TeacherList[index].Courses[i].Name}");
                                                    int LessonIndex = int.Parse(Console.ReadLine());
                                                    LessonIndex--;
                                                    bool ShowStudents = true;
                                                    while(ShowStudents)
                                                    {
                                                        Console.WriteLine("Choose Student by index:");
                                                        for(int j=0;j< TeacherList[index].Courses[LessonIndex].Students.Count;j++)
                                                        {
                                                            Console.WriteLine($"{j+1}- {TeacherList[index].Courses[LessonIndex].Students[j]}");
                                                        }
                                                    }
                                                }
                                                break;
                                            case "b":
                                                TeacherMenu2 = false;
                                                break;
                                            case "E":
                                                System.Environment.Exit(0);
                                                break;
                                            default:
                                                Message.Default(3);
                                                break;

                                        }
                                    }
                                }
                            }
                        }
                        
                        break;
                    // *** Student Menu
                    case "S":
                        Message.Program();
                        //bool StudentMenu = true;
                        //while (StudentMenu)
                        //{
                            if (FirstLogin)
                            {
                                Message.FirstLogin();
                                Thread.Sleep(2000);
                                Message.Loading(1);
                                break;
                            }
                            else
                            {
                                //Login check
                                //Message.Program();
                                //Console.WriteLine("Enter your Username and Password below");
                                //Console.Write("User Name: ");
                                //input = Console.ReadLine();
                                //string username2 = input;
                                //Console.Write("Password: ");
                                //input = GetPassword();
                            string password2 = input;
                            string username2 = input;
                            int index = -2;
                            do
                            {
                                Message.Program();
                                if (index == -1)
                                {
                                    Message.Wrong();
                                }
                                Console.WriteLine("Enter your Username and Password below");
                                Console.Write("User Name: ");
                                input = Console.ReadLine();
                                if (input == "b")
                                {
                                    Wait.ClearLine();
                                    Wait.ClearLine();
                                    Wait.ClearLine();
                                    Wait.ClearLine();
                                    break;
                                }
                                username2 = input;
                                Console.Write("Password: ");
                                input = GetPassword();
                                if (input == "b")
                                {
                                    Wait.ClearLine();
                                    Wait.ClearLine();
                                    Wait.ClearLine();
                                    Wait.ClearLine();
                                    Wait.ClearLine();
                                    break;
                                }
                                password2 = input;
                                index = dumbledore.STLoginCheck(username2, password2, StudentList);
                            } while (index<0);
                                
                                    
                            if (index >= 0)
                            {
                                Message.Program();
                                Message.LogedIn();
                                bool StudentMenu2 = true;
                                while (StudentMenu2)
                                {
                                    Message.Program();
                                    Message.Welcome(StudentList[index].FirstName + " " + StudentList[index].LastName);
             
                                    if (!StudentList[index].invited)
                                    {
                                        Console.WriteLine("You Are Not Allowed to Hogwarts!");
                                        Console.WriteLine("Press any key to exit.");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else if (StudentList[index].invited && !StudentList[index].Registered)
                                    {
                                        StudentList[index].Pet = RandomEnumValue<EPet>();
                                        StudentList[index].Group.Type = RandomEnumValue<EGroupType>();
                                        Message.Congrats(StudentList[index]);
                                        Console.WriteLine("Enter (+) if you have bag with you:");
                                        string bag = Console.ReadLine();
                                        if (bag == "+")
                                        {
                                            StudentList[index].Bag = true;
                                        }
                                        Message.Program();
                                        Message.Registered(StudentList[index]);
                                        Console.WriteLine("Press any key to exit");
                                        Console.ReadKey();
                                        Wait.Dot("Directing To Your Panel in 5secs",5);
                                    }
                                    if (StudentList[index].Registered)
                                    {
                                        Message.Program();
                                        Message.Welcome(StudentList[index].FirstName + " " + StudentList[index].LastName);
                                        if () dumbledore.ShowDorm(StudentList[index]);
                                        if (StudentList[index].NewSTMessage)
                                        {
                                            Message.NewMessage();
                                        }
                                        Message.StudentMenu();
                                        string input5 = Console.ReadLine();
                                        switch (input5)
                                        {
                                            case "S":
                                                Message.Program();
                                                StudentList[index].ScheduleTable(StudentList[index].Schedule(StudentList[index].Courses));
                                                Console.WriteLine("Press any key to turn back");
                                                Console.ReadKey();
                                                break;
                                            case "M":
                                                Message.Program();
                                                Console.WriteLine("Enter Your Massage:");
                                                string message = Console.ReadLine();
                                                dumbledore.SendMessageFromST(message, StudentList[index]);
                                                Console.WriteLine("Press any key to turn back");
                                                Console.ReadLine();
                                                break;
                                            case "T":
                                                Message.Program();
                                                StudentList[index].Train(StudentList[index]);
                                                if (StudentList[index].NewTerm)
                                                {
                                                    dumbledore.ShowDorm(StudentList[index]);
                                                    StudentList[index].NewTerm = false;
                                                }
                                                else Console.WriteLine($"Your Dorm Number is: {StudentList[index].DormNumber}");
                                                Console.WriteLine("Press any key to turn back.");
                                                Console.ReadKey();
                                                break;
                                            case "I":
                                                Message.Program();
                                                bool inbox = true;
                                                while (inbox)
                                                {
                                                    StudentList[index].NewSTMessage = false;
                                                    Message.Program();
                                                    Message.InboxMenu();
                                                    string input3 = Console.ReadLine();
                                                    switch (input3)
                                                    {
                                                        case "b":
                                                            inbox = false;
                                                            break;
                                                        case "A":
                                                            Message.Program();
                                                            StudentList[index].Inbox_All();
                                                            string input4 = Console.ReadLine();
                                                            switch (input4)
                                                            {
                                                                case "b":
                                                                    inbox = false;
                                                                    break;
                                                                default:
                                                                    Message.Default(3);
                                                                    break;
                                                            }
                                                            break;
                                                        case "U":
                                                            Message.Program();
                                                            StudentList[index].Inbox_UnRead();
                                                            string input6 = Console.ReadLine();
                                                            switch (input6)
                                                            {
                                                                case "b":
                                                                    inbox = false;
                                                                    break;
                                                                default:
                                                                    Message.Default(3);
                                                                    break;
                                                            }
                                                            break;
                                                        case "R":
                                                            Message.Program();
                                                            StudentList[index].Inbox_Read();
                                                            input5 = Console.ReadLine();
                                                            switch (input5)
                                                            {
                                                                case "b":
                                                                    inbox = false;
                                                                    break;
                                                                default:
                                                                    Message.Default(3);
                                                                    break;
                                                            }
                                                            break;
                                                        default:
                                                            Message.Default(3);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "U":
                                                Message.Program();
                                                bool SelectUnit = true;
                                                while (SelectUnit)
                                                {
                                                    Console.WriteLine("Select One by index:");
                                                    Console.WriteLine($"{"",-2}- {"Course Name",-15} {"Capacity",-9} Time");
                                                    for(int i =0; i<CourseList.Count;i++)
                                                    {
                                                            Console.Write($"{i + 1,-2}- {CourseList[i].Name,-15} {CourseList[i].Registered+"/"+CourseList[i].Capacity,-9} ");
                                                            for(int j=0; j<CourseList[i].DayOfWeek.Count;j++)
                                                            {
                                                                Console.Write($"({CourseList[i].DayOfWeek[j] +" "+CourseList[i].Hour[j]})");
                                                            }
                                                            Console.WriteLine();
                                                    }
                                                    string input10 = Console.ReadLine();
                                                    if (input10 == "b") break;
                                                    int CourseIndex = int.Parse(input10);
                                                    if (CourseList[CourseIndex].Term != StudentList[index].Term) Console.WriteLine("Your Term Doesn't Match!");
                                                    else if (dumbledore.CourseInterrupt(StudentList[index], CourseList[CourseIndex])) Console.WriteLine("Time Interrupts!");
                                                    else if (CourseList[CourseIndex].Registered >= CourseList[CourseIndex].Capacity) Console.WriteLine("Course Capacity is Full!");
                                                    else
                                                    {
                                                        CourseList[CourseIndex].Registered++;
                                                        StudentList[index].Courses.Add(CourseList[CourseIndex]);
                                                        CourseList[CourseIndex].Students.Add(StudentList[index]);
                                                    }
                                                }
                                                break;
                                            case "b":
                                                StudentMenu2 = false;
                                                break;
                                            case "E":
                                                System.Environment.Exit(0);
                                                break;
                                            default:
                                                Message.Default(3);
                                                break;
                                        }
                                    }
                                }
                            }
                            //}
                        }
                        break;
                    default:
                        Message.Default(3);
                        break;
                }
                Message.Program();
                Message.MainMenu();
                input = Console.ReadLine();
                if ((DateTime.Now.Year - FirstRunTime.Year)>1)
                {
                    for(int i =0; i<StudentList.Count;i++)
                    {
                        StudentList[i].Term++;
                        StudentList[i].NewTerm = true;
                    }
                    Dorm.EmptyDorm();
                    FirstRunTime = DateTime.Now;
                }
            }
        }


        // *Password-Hide by '*'
        private static string GetPassword()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.SetCursorPosition(x - 1, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x - 1, y);
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    input.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            return input.ToString();
        }

        public static T RandomEnumValue<T>()
        {
            Random random = new Random();
            Type type = typeof(T);
            Array values = type.GetEnumValues();
            int index = random.Next(values.Length);
            T value = (T)values.GetValue(index);
            return value;
        }
        
    }
}