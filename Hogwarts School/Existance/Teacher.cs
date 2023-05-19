using System;
namespace Hogwarts
{
	public class Teacher:Human
	{
		public Teacher(Human human) : base(human)
        {
		}

		public bool SimultaneousTeaching { get; set; }

    }
}

