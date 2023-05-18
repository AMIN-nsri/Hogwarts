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

        public List<string> Term1 { get; set; }
        public List<string> Term2 { get; set; }
        public List<string> Term3 { get; set; }
        public List<string> Term4 { get; set; }

    }
}

