using System;
namespace Hogwarts
{
	public class Wait
	{
		public Wait()
		{
		}
        
        //  ****Method For Clearing Last Line
        public static void ClearLine()
        {
            if (Console.CursorTop >= 1)
            {

                Console.SetCursorPosition(0, Console.CursorTop-1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        //  ****Method For Make Pause With Dot Wait Animation
        public static void Dot(string message, int seconds)
        {
            for (int i = 1; i < 5 * seconds; i++)
            {
                switch (i % 5)
                {
                    case 1:
                        Console.WriteLine($"{message}.");
                        Thread.Sleep(300);
                        Wait.ClearLine();
                        break;
                    case 2:
                        Console.WriteLine($"{message}..");
                        Thread.Sleep(240);
                        Wait.ClearLine();
                        break;
                    case 3:
                        Console.WriteLine($"{message}...");
                        Thread.Sleep(190);
                        Wait.ClearLine();
                        break;
                    case 4:
                        Console.WriteLine($"{message}....");
                        Thread.Sleep(150);
                        Wait.ClearLine();
                        break;
                    case 0:
                        Console.WriteLine($"{message}.....");
                        Thread.Sleep(120);
                        Wait.ClearLine();
                        break;
                }
            }
        }
    }
}

