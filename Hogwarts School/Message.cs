﻿using System;
using System.Globalization;

namespace Hogwarts
{
	public class Message
	{
		public Message()
		{
		}
        // Showing Program Topic
        public static void Topic()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("-------------Hogwarts School of Wizards-------------");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("[b]ack");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Showing System Time
        public static void Time()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            DateTime dt = DateTime.Now;
            
            Console.WriteLine($"{dt.Year}/{dt.Month}/{dt.Day}                                   {dt.ToShortTimeString()}");
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
            Console.WriteLine("Inbox(I)");
            //Console.WriteLine("Student(S)");
            Console.WriteLine("Exit(E)");
        }
    }
}

