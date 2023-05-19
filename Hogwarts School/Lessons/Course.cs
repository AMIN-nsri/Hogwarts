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
        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int Registered { get; set; }
        public int Capacity { get; set; }
        public int Term { get; set; }
    }
}

