using System.Collections.Generic;
using System.Globalization;
using System.Collections;
using System;
using System.Threading;
using System.Linq;
using System.Text;

namespace Hogwarts
{
    class Program
    {
        public static void Main()
        {
            List<Human> HumanList = new List<Human>();
            using (StreamReader file = new StreamReader("file.tsv"))
            {
                string In;
                while ((In = file.ReadLine()) != null)
                {
                    Human human1 = new Human();
                    string[] data = In.Split("\t").ToArray<string>();

                    human1.FirstName = data[0];
                    human1.LastName = data[1];
                    human1.Birth = data[2];
                    human1.Gender = (EGender)Enum.Parse(typeof(EGender), data[3], true);
                    human1.Father = data[4];
                    human1.Username = data[5];
                    human1.Password = data[6];
                    human1.Blood = (EBlood) Enum.Parse(typeof(EBlood), data[7].Replace(" ",""), true);
                    human1.Role = data[8];
                    HumanList.Add(human1);
                }
                file.Close();
            }
            for (int i=0; i<10;i++)
            {
                HumanList[i].Display();
            }

        }
    }
}