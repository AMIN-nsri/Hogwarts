using System;
namespace Hogwarts
{
	public class Group
	{
		public Group()
		{
		}
		public EGroupType Type { get; set; }
		public int Score { get; set; }
		public List<Student> Members { get; set; }
        public List<Student> QuidditchMembers { get; set; }
    }
}

