using System;
namespace Hogwarts
{
	public class AllowedPerson : Human
	{
		public AllowedPerson()
		{
		}

		public string Schedule { get; set; }
        public EPet Pet { get; set; }
		public Group Group { get; set; } // make it function
		public bool Bag { get; set; }
        public ERole Role { get; set; }
		public string[] Letter { get; set; }

    }
}

