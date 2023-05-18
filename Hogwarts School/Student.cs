﻿using System;
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

		public int PassedUnit { get; set; }
		public int Term { get; set; } = 1;
		public int DormNumber { get; set; } //Khabgah
		public bool NewSTMessage { get; set; }
        public List<Course> Courses = new List<Course>();
        //public bool Invited { get; set; }

        List<SMessage> STMessage = new List<SMessage>();

        public bool NewDumbMessage;
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
                Console.Write($"{STMessage[i].Sender + ": ",-10}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{STMessage[i].message}");
                Console.WriteLine();
            }
        }
    }
}

