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
            List<Human> HumanList = new List<Human>();
            List<Teacher> TeacherList = new List<Teacher>();
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
                    HumanList.Add(human1);
                    //if (human1.Role == ERole.Teacher) TeacherList.Add(human1); 
                }
                file.Close();
            }

            Dumbledore dumbledore = new Dumbledore();
            bool FirstLogin = true;
            Message.Program();
            Message.MainMenu();

            String input = Console.ReadLine();

            while(input != "E")
            {
                switch (input)
                {
                    case "D":
                        //Login check
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
                                    case "S":

                                        break;
                                    case "I":
                                        Message.Program();
                                        bool inbox = true;
                                        while(inbox)
                                        {
                                            dumbledore.Inbox();
                                            string input3 = Console.ReadLine();
                                            switch (input3)
                                            {
                                                case "b":
                                                    inbox = false;
                                                    break;
                                                case "F":
                                                    dumbledore.FullInbox();
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
                                                default:
                                                    Message.Default(3);
                                                    break;
                                            }

                                        }
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

                            }
                        }
                        
                        break;
                    case "S":
                        Message.Program();
                        bool StudentMenu = true;
                        while (StudentMenu)
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

                            }
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
    }
}