using System;
namespace Hogwarts
{
	public class Botanical : Course
	{
        public Botanical()
        {
        }
        public Botanical(Course course) : base(course)
		{
		}

        public List<Plant> Term1 = new List<Plant>();
        public List<Plant> Term2 = new List<Plant>();
        public List<Plant> Term3 = new List<Plant>();
        public List<Plant> Term4 = new List<Plant>();

        public void DefaultPlant()
        {
            Plant pl = new Plant();
            pl.Name = "Mandrakes";
            pl.Count = 12;
            Term1.Add(pl);
            Plant pl2 = new Plant();
            pl2.Name = "Gillyweed";
            pl2.Count = 20;
            Term1.Add(pl2);
            Plant pl3 = new Plant();
            pl3.Name = "Devil's Snare";
            pl3.Count = 16;
            Term1.Add(pl3);
            Plant pl4 = new Plant();
            pl4.Name = "Whomping";
            pl4.Count = 22;
            Term1.Add(pl4);
            Plant pl5 = new Plant();
            pl5.Name = "Venomous";
            pl5.Count = 27;
            Term1.Add(pl5);

            Plant pl6 = new Plant();
            pl6.Name = "Croton";
            pl6.Count = 23;
            Term2.Add(pl6);
            Plant pl7 = new Plant();
            pl7.Name = "Branched";
            pl7.Count = 18;
            Term2.Add(pl7);
            Plant pl8 = new Plant();
            pl8.Name = "Wooly Hairs";
            pl8.Count = 24;
            Term2.Add(pl8);
            Plant pl9 = new Plant();
            pl9.Name = "Sandy";
            pl9.Count = 34;
            Term2.Add(pl9);
            Plant pl10 = new Plant();
            pl10.Name = "Rocky";
            pl10.Count = 33;
            Term2.Add(pl10);

            Plant pl11 = new Plant();
            pl11.Name = "Croton";
            pl11.Count = 23;
            Term3.Add(pl11);
            Plant pl12 = new Plant();
            pl12.Name = "Branched";
            pl12.Count = 18;
            Term3.Add(pl12);
            Plant pl13 = new Plant();
            pl13.Name = "Wooly Hairs";
            pl13.Count = 24;
            Term3.Add(pl13);
            Plant pl14 = new Plant();
            pl14.Name = "Sandy";
            pl14.Count = 34;
            Term3.Add(pl14);
            Plant pl15 = new Plant();
            pl15.Name = "Rocky";
            pl15.Count = 33;
            Term3.Add(pl15);

            Plant pl16 = new Plant();
            pl16.Name = "Mandrakes";
            pl16.Count = 12;
            Term4.Add(pl16);
            Plant pl17 = new Plant();
            pl17.Name = "Gillyweed";
            pl17.Count = 20;
            Term4.Add(pl17);
            Plant pl18 = new Plant();
            pl18.Name = "Devil's Snare";
            pl18.Count = 16;
            Term4.Add(pl18);
            Plant pl19 = new Plant();
            pl19.Name = "Whomping";
            pl19.Count = 22;
            Term4.Add(pl19);
            Plant pl20 = new Plant();
            pl20.Name = "Venomous";
            pl20.Count = 27;
            Term4.Add(pl20);
        }
        public void Grow()
        {
            for(int i =0;i<5;i++)
            {
                Term1[i].Count++;
                Term2[i].Count++;
                Term3[i].Count++;
                Term4[i].Count++;
            }
        }
    }
}

