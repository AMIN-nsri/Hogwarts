using System;
namespace Hogwarts
{
	public class Student : AllowedPerson
	{
		public Student(Human human):base(human)
		{

		}

		public int PassedUnit { get; set; }
		public int Term { get; set; } = 1;
		public int DormNumber { get; set; } //Khabgah
		public bool NewSTMessage { get; set; }
		public void IfInvited(Human human)
		{

		}
        
    }
}

