using System;

namespace HW4T2
{
    class Program
    {
        static void Main(string[] args)
        {
            var uList = new UniqueList();
            try
            {
                uList.AddToListFront(1);
                uList.AddToListFront(2);
                uList.AddToListFront(3);
                uList.AddToListFront(4);
                uList.AddToListFront(5);
                uList.AddToListPosition(0, 99);
                uList.Display();
            }
            catch (AddDataThatIsAlreadyInTheListException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Message: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (DeleteFromEmptyListException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Message: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (IncorrectInputPositionException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Message: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
