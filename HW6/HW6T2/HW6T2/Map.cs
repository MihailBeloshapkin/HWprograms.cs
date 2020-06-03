using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HW6T2
{
    class Map
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

            while (mapBuffer[sizeOfRow] != '\n')
            {
                sizeOfRow++;
            }

            sizeOfColumn = mapBuffer.Length / (sizeOfRow + 1);

            map = new char[sizeOfRow, sizeOfColumn];

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
        /// Display map to a console.
        /// </summary>
        public void DisplayMap()
        {
            for (int iter = 0; iter < map.GetLength(0); iter++)
            {
                for (int jiter = 0; jiter < map.GetLength(1); jiter++)
                {
                    Console.Write(map[iter, jiter]);
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
                        PositionOfCharacter = (iter, jiter);
                        map[iter, jiter] = '@';
                        return;
                    }
                }
            }

            throw new NoSpaceException();
        }

        public bool IsAbleToMove(int moveX, int moveY)
        {
            if (PositionOfCharacter.X + moveX > -1 &&
                PositionOfCharacter.X + moveX < map.GetLength(1) &&
                PositionOfCharacter.Y + moveY > -1 &&
                PositionOfCharacter.Y + moveY < map.GetLength(0) &&
                map[PositionOfCharacter.X, PositionOfCharacter.Y] == ' ')
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get symbol from the character position.
        /// </summary>
        /// <returns></returns>
        public char GetSymbol()
            => map[PositionOfCharacter.X, PositionOfCharacter.Y];

        /// <summary>
        /// Set symbol to the character position.
        /// </summary>
        /// <param name="symbol"></param>
        public void SetSymbol(char symbol)
            => map[PositionOfCharacter.X, PositionOfCharacter.Y] = symbol;

    }
}
