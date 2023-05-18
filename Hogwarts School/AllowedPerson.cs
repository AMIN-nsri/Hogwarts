using System;
namespace Hogwarts
{
	public class AllowedPerson : Human
	{
		public AllowedPerson(Human human): base(human)
		{

		}

		//public string Schedule { get; set; }
        public EPet Pet { get; set; }
		public Group Group { get; set; } // make it function
		public bool Bag { get; set; }
        //public ERole Role { get; set; }
		public string[] Letter { get; set; } //remove

        // use if statment to sort the 7*5 schedule 8-10,10-12,13-14,14-16,16-18
        //public static string[,] sc = new string[7, 5]
        //{
        //    {"S8","S10","S13","S14","S16" },
        //    {"Su8","Su10","Su13","Su14","Su16" },
        //    {"M8","M10","M13","M14","M16" },
        //    {"T8","T10","T13","S14","S16" },
        //    {"S8","S10","S13","S14","S16" },
        //    {"S8","S10","S13","S14","S16" },
        //    {"S8","S10","S13","S14","S16" },
        //};

        public string[,] Schedule(List<Course> courses)
        {
            string[,] sch = new string[7, 5];
            for (int i=0; i<courses.Count;i++)
            {
                switch (courses[i].DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        switch (courses[i].Hour)
                        {
                            case 8:
                                sch[0, 0] = courses[i].Name;
                                break;
                            case 10:
                                sch[0, 1] = courses[i].Name;
                                break;
                            case 13:
                                sch[0, 2] = courses[i].Name;
                                break;
                            case 14:
                                sch[0, 3] = courses[i].Name;
                                break;
                            case 16:
                                sch[0, 4] = courses[i].Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Sunday:
                        switch (courses[i].Hour)
                        {
                            case 8:
                                sch[1, 0] = courses[i].Name;
                                break;
                            case 10:
                                sch[1, 1] = courses[i].Name;
                                break;
                            case 13:
                                sch[1, 2] = courses[i].Name;
                                break;
                            case 14:
                                sch[1, 3] = courses[i].Name;
                                break;
                            case 16:
                                sch[1, 4] = courses[i].Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Monday:
                        switch (courses[i].Hour)
                        {
                            case 8:
                                sch[2, 0] = courses[i].Name;
                                break;
                            case 10:
                                sch[2, 1] = courses[i].Name;
                                break;
                            case 13:
                                sch[2, 2] = courses[i].Name;
                                break;
                            case 14:
                                sch[2, 3] = courses[i].Name;
                                break;
                            case 16:
                                sch[2, 4] = courses[i].Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        switch (courses[i].Hour)
                        {
                            case 8:
                                sch[3, 0] = courses[i].Name;
                                break;
                            case 10:
                                sch[3, 1] = courses[i].Name;
                                break;
                            case 13:
                                sch[3, 2] = courses[i].Name;
                                break;
                            case 14:
                                sch[3, 3] = courses[i].Name;
                                break;
                            case 16:
                                sch[3, 4] = courses[i].Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        switch (courses[i].Hour)
                        {
                            case 8:
                                sch[4, 0] = courses[i].Name;
                                break;
                            case 10:
                                sch[4, 1] = courses[i].Name;
                                break;
                            case 13:
                                sch[4, 2] = courses[i].Name;
                                break;
                            case 14:
                                sch[4, 3] = courses[i].Name;
                                break;
                            case 16:
                                sch[4, 4] = courses[i].Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Thursday:
                        switch (courses[i].Hour)
                        {
                            case 8:
                                sch[5, 0] = courses[i].Name;
                                break;
                            case 10:
                                sch[5, 1] = courses[i].Name;
                                break;
                            case 13:
                                sch[5, 2] = courses[i].Name;
                                break;
                            case 14:
                                sch[5, 3] = courses[i].Name;
                                break;
                            case 16:
                                sch[5, 4] = courses[i].Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Friday:
                        switch (courses[i].Hour)
                        {
                            case 8:
                                sch[6, 0] = courses[i].Name;
                                break;
                            case 10:
                                sch[6, 1] = courses[i].Name;
                                break;
                            case 13:
                                sch[6, 2] = courses[i].Name;
                                break;
                            case 14:
                                sch[6, 3] = courses[i].Name;
                                break;
                            case 16:
                                sch[6, 4] = courses[i].Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            return sch;
        }

		public void ScheduleTable(string[,] sch)
		{
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{"",-10}  {"    8-10",-12}  {"    10-12",-12}   {"    13-14",-12}   {"    14-16",-12}   {"    16-18",-12}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{"Saturday",-10} ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"|{sch[0, 0],-12} | {sch[0,1],-12} | {sch[0, 2],-12} | {sch[0, 3],-12} | {sch[0, 4],-12} |");
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{"Sunday",-10} ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"|{sch[1, 0],-12} | {sch[1, 1],-12} | {sch[1, 2],-12} | {sch[1, 3],-12} | {sch[1, 4],-12} |");
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{"Monday",-10} ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"|{sch[2, 0],-12} | {sch[2, 1],-12} | {sch[2, 2],-12} | {sch[2, 3],-12} | {sch[2, 4],-12} |");
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{"Tuesday",-10} ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"|{sch[3, 0],-12} | {sch[3, 1],-12} | {sch[3, 2],-12} | {sch[3, 3],-12} | {sch[3, 4],-12} |");
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{"Wednesday",-10} ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"|{sch[4, 0],-12} | {sch[4, 1],-12} | {sch[4, 2],-12} | {sch[4, 3],-12} | {sch[4, 4],-12} |");
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{"Thursday",-10} ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"|{sch[5, 0],-12} | {sch[5, 1],-12} | {sch[5, 2],-12} | {sch[5, 3],-12} | {sch[5, 4],-12} |");
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{"Friday",-10} ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"|{sch[6, 0],-12} | {sch[6, 1],-12} | {sch[6, 2],-12} | {sch[6, 3],-12} | {sch[6, 4],-12} |");
            Console.WriteLine($"{"",-10}  ------------- -------------- -------------- -------------- -------------- ");
        }
    }
}

