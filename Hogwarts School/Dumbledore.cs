using System;
namespace Hogwarts
{
    public class DMessage
    {
        public DMessage(string message)
        {
            this.message = message;
        }
        public string message { get; set; }
        public bool Seen { get; set; }
    }
	public class Dumbledore
	{
		public Dumbledore()
		{
            DumbMessage.Insert(0,new DMessage("hello"));
            DumbMessage.Insert(0, new DMessage("hello2"));
            DumbMessage.Insert(0, new DMessage("hello3"));
            DumbMessage.Insert(0, new DMessage("hello4"));

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
        public int TELoginCheck(string username, string password, List<Teacher> teacherlist)
        {
            for (int i = 0; i < teacherlist.Count; i++)
            {
                if (username == teacherlist[i].Username && password == teacherlist[i].Password) return i;
            }
            return -1;
        }
        List<DMessage> DumbMessage = new List<DMessage>();
        
        public bool NewDumbMessage;
        public void Inbox_UnRead()
        {
            //if (DumbMessage.Count != 0)
            //{
                bool isThereAnyunreadMessage = false;
                for (int i = 0; i < DumbMessage.Count; i++)
                {
                    if (!DumbMessage[i].Seen)
                    {
                        isThereAnyunreadMessage = true;
                        Console.WriteLine((i + 1) + "- " + DumbMessage[i].message);
                        DumbMessage[i].Seen = true;

                    }
                }
            if (!isThereAnyunreadMessage) Console.WriteLine("Empty!");
            //}
            //else Console.WriteLine("Empty!");
        }
        public void Inbox_Read()
        {
            //if (DumbMessage.Count != 0)
            //{
            bool isThereAnyreadMessage = false;
                for (int i = 0; i < DumbMessage.Count; i++)
                {
                    if (DumbMessage[i].Seen)
                    {
                    isThereAnyreadMessage = true;
                    Console.WriteLine((i + 1) + "- " + DumbMessage[i].message);
                    }
                }
            if (!isThereAnyreadMessage) Console.WriteLine("Empty!");

            //}
            //else Console.WriteLine("Empty!");
        }
        public void Inbox_All()
        {
            for (int i = 0; i < DumbMessage.Count; i++)
            {
                Console.WriteLine((i + 1) + "- " + DumbMessage[i].message);
            }
        }
        public void Invite(Human human)
        {
            if(human.Role== ERole.Teacher)
            {
                Console.WriteLine("You Cannot Invite Teachers!");
            }
            else if (human.Role==ERole.Student)
            {
                human.invited = true;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Student Invited Successfully!");
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("They Will Be Registered Once They Accept the Invitation.");
            }
        }
    }
}

