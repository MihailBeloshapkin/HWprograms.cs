using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HW6T2
{
    /// <summary>
    /// This class contains map and its elements.
    /// </summary>
    public class Map
    {
        private char[,] map;

        private (int X, int Y) PositionOfCharacter;

        public Map(string fileName)
        {
            LoadAndCreateTheMap(fileName);
            SetPositionOfCharacter();               
        }

        /// <summary>
        /// Get character coordinate X.
        /// </summary>
        /// <returns>Position of character X</returns>
        public int GetCharacterCoordinateX()
            => PositionOfCharacter.X;

        /// <summary>
        /// Get character coordinate Y
        /// </summary>
        /// <returns>Position of character Y</returns>
        public int GetCharacterCoordinateY()
            => PositionOfCharacter.Y;

        /// <summary>
        /// Load data from file and parse it to two-dimensional array.
        /// </summary>
        /// <param name="fileName">Input file name.</param>
        public void LoadAndCreateTheMap(string fileName)
        {
            string mapBuffer;

            using (var sr = new StreamReader(fileName))
            {
                mapBuffer = sr.ReadToEnd();
            }

            int sizeOfRow = 0;
            int sizeOfColumn = 0;

            while (mapBuffer[sizeOfRow] != '\r')
            {
                sizeOfRow++;
            }

            for (int iter = 0; iter < mapBuffer.Length; iter++)
            {
                if (mapBuffer[iter] == '\n')
                {
                    sizeOfColumn++;
                }
            }

            sizeOfColumn++;

            map = new char[sizeOfColumn, sizeOfRow];

            int rowIndex = 0;
            int columnIndex = 0;

            for (int iter = 0; iter < mapBuffer.Length; iter++)
            {
                if (mapBuffer[iter] == '\n' || mapBuffer[iter] == '\r')
                {
                    rowIndex++;
                    columnIndex = 0;
                    iter++;
                }
                else
                {
                    map[rowIndex, columnIndex] = mapBuffer[iter];
                    columnIndex++;
                }
            }
        }

        /// <summary>
        /// Change character ccordinates.
        /// </summary>
        /// <param name="moveX">Move by X direction.</param>
        /// <param name="moveY">Move by Y firection.</param>
        public void MoveTheCharacter(int moveX, int moveY)
        {
            if (this.IsAbleToMove(moveX, moveY))
            {
                PositionOfCharacter.X += moveX;
                PositionOfCharacter.Y += moveY;
            }
        }

        /// <summary>
        /// Display map to a console.
        /// </summary>
        public void DisplayMap()
        {
            for (int iter = 0; iter < map.GetLength(0); iter++)
            {
                for (int jiter = 0; jiter < map.GetLength(1); jiter++)
                {
                    if (iter == PositionOfCharacter.Y && jiter == PositionOfCharacter.X)
                    {
                        Console.Write('@');
                    }
                    else
                    {
                        Console.Write(map[iter, jiter]);
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Set position of character in loaded map.
        /// </summary>
        public void SetPositionOfCharacter()
        {
            for (int iter = 0; iter < map.GetLength(0); iter++)
            {
                for (int jiter = 0; jiter < map.GetLength(1); jiter++)
                {
                    if (map[iter, jiter] == ' ')
                    {
                        PositionOfCharacter = (jiter, iter);
                        return;
                    }
                }
            }

            throw new NoSpaceException();
        }

        /// <summary>
        /// Checks that it is able to move character.
        /// </summary>
        /// <param name="moveX">Move by X direction.</param>
        /// <param name="moveY">Move by Y direction.</param>
        /// <returns></returns>
        public bool IsAbleToMove(int moveX, int moveY)
        {
            if (PositionOfCharacter.X + moveX > -1 &&
                PositionOfCharacter.X + moveX < map.GetLength(1) &&
                PositionOfCharacter.Y + moveY > -1 &&
                PositionOfCharacter.Y + moveY < map.GetLength(0) &&
                map[PositionOfCharacter.Y + moveY, PositionOfCharacter.X + moveX] == ' ')
            {
                return true;
            }

            return false;
        }
    }
}
