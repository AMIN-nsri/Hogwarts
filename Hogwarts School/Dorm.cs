using System;
namespace Hogwarts
{
	public class Dorm
	{
		public EGroupType Group { get; set; }
        public static int HFloor { get; set; } = 1;
        public static int HRoom { get; set; } = 1;
        public static int HBed { get; set; } = 1;
        public static int GFloor { get; set; } = 1;
        public static int GRoom { get; set; } = 1;
        public static int GBed { get; set; } = 1;
        public static int RFloor { get; set; } = 1;
        public static int RRoom { get; set; } = 1;
        public static int RBed { get; set; } = 1;
        public static int SFloor { get; set; } = 1;
        public static int SRoom { get; set; } = 1;
        public static int SBed { get; set; } = 1;
        public EGender Gender { get; set; }
        public Dorm()
		{
            //Dorm.makeDormCode();
        }
        public static void EmptyDorm()
        {
            HFloor = 1;
            HRoom = 1;
            HBed = 1;
            GFloor = 1;
            GRoom = 1;
            GBed = 1;
            RFloor = 1;
            RRoom = 1;
            RBed = 1;
            SFloor = 1;
            SRoom = 1;
            SBed = 1;
        }
        public static string makeHuffDormCode()
        {
            String DormCode = string.Empty;
            if (HBed > 3)
            {
                if (HRoom == 5)
                {
                    HFloor++;
                    HBed = 1;
                    HRoom = 1;
                }
                else
                {
                    HRoom++;
                    HBed = 1;
                }
            }
            DormCode = $"{HFloor}{HRoom}{HBed}";
            HBed++;
            return DormCode;
        }
        public static string makeGryfDormCode()
        {
            String DormCode = string.Empty;
            if (GBed > 3)
            {
                if (GRoom == 5)
                {
                    GFloor++;
                    GBed = 1;
                    GRoom = 1;
                }
                else
                {
                    GRoom++;
                    GBed = 1;
                }
            }
            DormCode = $"{GFloor}{GRoom}{GBed}";
            GBed++;
            return DormCode;
        }
        public static string makeRavenDormCode()
        {
            String DormCode = string.Empty;
            if (RBed > 3)
            {
                if (RRoom == 5)
                {
                    RFloor++;
                    RBed = 1;
                    RRoom = 1;
                }
                else
                {
                    RRoom++;
                    RBed = 1;
                }
            }
            DormCode = $"{RFloor}{RRoom}{RBed}";
            RBed++;
            return DormCode;
        }
        public static string makeSlyDormCode()
        {
            String DormCode = string.Empty;
            if (SBed > 3)
            {
                if (SRoom == 5)
                {
                    SFloor++;
                    SBed = 1;
                    SRoom = 1;
                }
                else
                {
                    SRoom++;
                    SBed = 1;
                }
            }
            DormCode = $"{SFloor}{SRoom}{SBed}";
            SBed++;
            return DormCode;
        }
    }
}

