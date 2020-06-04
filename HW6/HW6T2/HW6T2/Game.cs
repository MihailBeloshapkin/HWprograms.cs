using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T2
{
    /// <summary>
    /// Game.
    /// </summary>
    public class Game
    {
        private Map Map;

        /// <summary>
        /// Create map and character objects.
        /// </summary>
        /// <param name="fileName"></param>
        public Game(string fileName)
        {
            Map = new Map(fileName);
            Map.DisplayMap();
        }

        /// <summary>
        /// Set position of cursor.
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        private void SetCursorPosition(int coordinateX, int coordinateY)
        {
            Console.CursorLeft = coordinateX;
            Console.CursorTop = coordinateY;
            Console.CursorVisible = false;
        }

        public void MoveLeft(object sender, EventArgs args)
            => Motion(-1, 0);

        public void MoveRight(object sender, EventArgs args)
            => Motion(1, 0);

        public void MoveUp(object sender, EventArgs args)
            => Motion(0, -1);

        public void MoveDown(object sender, EventArgs args)
            => Motion(0, 1);


        /// <summary>
        /// Change map cofiguration dependiong on player's decigions.
        /// </summary>
        /// <param name="moveX"></param>
        /// <param name="moveY"></param>
        public void Motion(int moveX, int moveY)
        {
            if (Map.IsAbleToMove(moveX, moveY))
            {
                SetCursorPosition(Map.GetCharacterCoordinateX(), Map.GetCharacterCoordinateY());
                Console.Write(' ');
                Map.MoveTheCharacter(moveX, moveY);
                SetCursorPosition(Map.GetCharacterCoordinateX(), Map.GetCharacterCoordinateY());
                Console.Write('@');
                SetCursorPosition(Map.GetCharacterCoordinateX(), Map.GetCharacterCoordinateY());
            }
        }
    }
}
