using System;

namespace HW2T1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            List list = new List();

            while (run)
            {
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - add data to list by position");
                Console.WriteLine("2 - delete data from list by position");
                Console.WriteLine("3 - get data by position");
                Console.WriteLine("4 - set data by position");
                Console.WriteLine("5 - get size");
                Console.WriteLine("6 - check that empty");
                Console.WriteLine("7 - display");

                var inputString = Console.ReadLine();
                int choice = int.Parse(inputString);

                switch (choice)
                {
                    case 0:
                        run = false;
                        break;
                    case 1:
                        {
                            Console.WriteLine("Input data:");
                            var input1 = Console.ReadLine();
                            int newData = int.Parse(input1);
                            Console.WriteLine("Input position:");
                            var input2 = Console.ReadLine();
                            int newPosition = int.Parse(input2);
                            list.AddToListPosition(newPosition, newData);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Input position:");
                            var input1 = Console.ReadLine();
                            int position = int.Parse(input1);
                            list.DeleteFromListPosition(position);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Input position:");
                            var input1 = Console.ReadLine();
                            int position = int.Parse(input1);
                            Console.WriteLine($"Data: {list.GetDataByPosition(position)}");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Input data:");
                            var input1 = Console.ReadLine();
                            int newData = int.Parse(input1);
                            Console.WriteLine("Input position:");
                            var input2 = Console.ReadLine();
                            int newPosition = int.Parse(input2);
                            list.SetDataByPosition(newPosition, newData);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"Size of list: {list.GetSize()}");
                            break;
                        }
                    case 6:
                        {
                            if (list.isEmpty())
                            {
                                Console.WriteLine("Is empty");
                            }
                            else
                            {
                                Console.WriteLine("Is not empty");
                            }
                            break;
                        }
                    case 7:
                        {
                            list.DisplayList();
                            Console.WriteLine();
                            break;
                        }
                }


            }
        }
    }
}
