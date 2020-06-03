﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T2
{
    public class EventLoop
    {

        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}
