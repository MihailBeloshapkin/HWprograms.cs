using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T2
{
    /// <summary>
    /// This class contains game components(text map and motion methods).
    /// </summary>
    public class Game
    {
        private Map Map;

        /// <summary>
        /// Create map objects.
        /// </summary>
        public Game(string fileName)
        {
            Map = new Map(fileName);
            Map.DisplayMap();
        }

        /// <summary>
        /// Set position of the cursor.
        /// </summary>
        /// <param name="coordinateX">Set coordinate X</param>
        /// <param name="coordinateY">Set coordinate Y</param>
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
        /// Change map configuration dependiong on players decisions.
        /// </summary>
        /// <param name="moveX">Change X direction.</param>
        /// <param name="moveY">Change Y direction.</param>
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
