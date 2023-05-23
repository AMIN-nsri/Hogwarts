using System;
namespace Hogwarts
{
	public class Course
	{
		public Course()
		{
            
		}
        public Course(Course course)
        {
            this.Capacity = course.Capacity;
            this.DayOfWeek = course.DayOfWeek;
            this.Hour = course.Hour;
            this.Name = course.Name;
            this.Registered = course.Registered;
            this.Term = course.Term;
        }
        public string Name { get; set; }
        public List<DayOfWeek> DayOfWeek { get; set; } = new List<DayOfWeek>();
        public List<int> Hour { get; set; } = new List<int>();
        public int Registered { get; set; } = 0;
        public int Capacity { get; set; }
        public int Term { get; set; }
        public Teacher Teacher { get; set; } = new Teacher();
        public List<Student> Students { get; set; } = new List<Student>();
        public int Score { get; set; }

    }
}

