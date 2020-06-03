using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T2
{
    /// <summary>
    /// Game.
    /// </summary>
    class Game
    {
        private Map Map;

        private Character Character;

        /// <summary>
        /// Create map and character objects.
        /// </summary>
        /// <param name="fileName"></param>
        public Game(string fileName)
        {
            Map = new Map(fileName);
            Character = new Character(Map.GetCharacterCoordinateX(), Map.GetCharacterCoordinateY());
            SetCursorPosition(Map.GetCharacterCoordinateX(), Map.GetCharacterCoordinateY());
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
            => Motion(0, 1);

        public void MoveDown(object sender, EventArgs args)
            => Motion(0, -1);

        public void Motion(int moveX, int moveY)
        {
            if (Map.IsAbleToMove(moveX, moveY))
            {

            }
        }
    }
}
