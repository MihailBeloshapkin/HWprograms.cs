using System;

namespace HW4T2
{
    class Program
    {
        static void Main(string[] args)
        {
            UniqueList uList = new UniqueList();
            try
            {
                uList.AddToListFront(1);
                uList.AddToListFront(2);
                uList.AddToListFront(3);
                uList.AddToListFront(4);
                uList.AddToListFront(5);
                uList.AddToListBack(5);
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
        }
    }
}
