using System;
namespace Hogwarts
{
	public class Student : AllowedPerson
	{
		public Student()
		{
		}

		public int PassedUnit { get; set; }
		public int Term { get; set; }
		public int DormNumber { get; set; } //Khabgah

    }
}

