﻿using System;
namespace Hogwarts
{
	public class Group
	{
		public Group()
		{
		}
		public EGroupType Type { get; set; }
		public int Score { get; set; }
		public List<int> Members { get; set; } //by username
        public List<int> QuidditchMembers { get; set; } //by username
    }
}

