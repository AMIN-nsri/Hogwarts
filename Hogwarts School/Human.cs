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
        public int BirthYear { get; set; }
		public EGender Gender { get; set; }
        public string Father { get; set; }
        public int Username { get; set; }
		public string Password { get; set; }
		public EBlood Blood { get; set; }
    }
}

