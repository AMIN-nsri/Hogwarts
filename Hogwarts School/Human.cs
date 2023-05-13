using System;
namespace Hogwarts
{
	public class Human
	{
		public Human()
		{
		}
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birth { get; set; }
		public EGender Gender { get; set; }
        public string Father { get; set; }
        public string Username { get; set; }
		public string Password { get; set; }
		public EBlood Blood { get; set; }
        public ERole Role { get; set; }

		public void Display()
		{
			Console.WriteLine($"{FirstName} {LastName} \t {Birth} \t {Gender} \t {Blood} \t");
		}
    }
}

