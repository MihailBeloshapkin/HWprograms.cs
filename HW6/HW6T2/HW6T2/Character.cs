using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T2
{
    class Character
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// Create character by setting the coordinates.
        /// </summary>
        /// <param name="X">Coordinate X</param>
        /// <param name="Y">Coordinate Y</param>
        public Character(int X, int Y)  
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Change character coordinates during the movement.
        /// </summary>
        /// <param name="moveX"></param>
        /// <param name="moveY"></param>
        public void Motion(int moveX, int moveY)
        {
            this.X += moveX;
            this.Y += moveY;
        }
    }
}
