using System;
namespace Hogwarts
{
	public class Dorm
	{
		public EGroupType Group { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Bed { get; set; }
		public EGender Gender { get; set; }
        public Dorm(int Code)
		{
			Floor = Code / 100;
            Room = (Code / 10) % 10;
            Bed = Code % 10;
        }


    }
}

