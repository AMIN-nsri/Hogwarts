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

        public List<Plant> Term1 = new List<Plant>();
        public List<Plant> Term2 = new List<Plant>();
        public List<Plant> Term3 = new List<Plant>();
        public List<Plant> Term4 = new List<Plant>();


    }
}

