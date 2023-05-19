using System;
namespace Hogwarts
{
	public class Botanical : Course
	{
        public Botanical()
        {
        }
        public Botanical(Course course) : base(course)
		{
		}

        public List<string> Term1 = new List<string>();
        public List<string> Term2 = new List<string>();
        public List<string> Term3 = new List<string>();
        public List<string> Term4 = new List<string>();

    }
}

