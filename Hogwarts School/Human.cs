using System;
namespace Hogwarts
{
	public class Human
	{
		public Human()
		{
		}
        public Human(Human h2)
        {
			this.FirstName = h2.FirstName;
			this.LastName = h2.LastName;
			this.Birth = h2.Birth;
			this.Gender = h2.Gender;
			this.Father = h2.Father;
			this.Username = h2.Username;
			this.Password = h2.Password;
			this.Role = h2.Role;
			this.Blood = h2.Blood;

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

		public bool invited;

		
		//public void Display()
		//{
		//	Console.WriteLine($"{FirstName} {LastName} \t {Birth} \t {Gender} \t {Blood} \t");
		//}
    }
}

