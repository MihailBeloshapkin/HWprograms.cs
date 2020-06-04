using System;

namespace HW6T2
{
    class Program
    {
        public static void Main()
        {
            try 
            {
                var Game = new Game("../../../map.txt");
                var eventLoop = new EventLoop();


                eventLoop.RightHandler += Game.MoveRight;
                eventLoop.LeftHandler += Game.MoveLeft;
                eventLoop.UpHandler += Game.MoveUp;
                eventLoop.DownHandler += Game.MoveDown;

                eventLoop.Run();
            }
            catch (NoSpaceException)
            {
                Console.WriteLine("Incorret map");
            }
        }
    }
}
