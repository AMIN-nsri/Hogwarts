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
            List<Human> HumanList = new List<Human>();
            List<Student> StudentList = new List<Student>();
            List<Teacher> TeacherList = new List<Teacher>();

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

            while(input != "E")
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

                                        //Message.TeacherMenu();
                                        string input2 = Console.ReadLine();
                                        switch (input2)
                                        {

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
                                    if (StudentList[index].NewSTMessage)
                                    {
                                        Message.NewMessage();
                                    }
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
                                                Console.WriteLine("Press any key to turn back");
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