using System;
namespace Hogwarts
{
	public class Teacher:Human
	{
		public Teacher()
		{

		}
		public Teacher(Human human) : base(human)
        {
		}

		public bool SimultaneousTeaching { get; set; }
		public bool Random()
		{
			Random random = new Random();
			int z = random.Next(0, 1);
			if (z == 0) return true;
			else return false;
		}
    }
}

