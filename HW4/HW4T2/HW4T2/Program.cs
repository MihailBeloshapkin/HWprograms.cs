using System;

namespace HW4T2
{
    class Program
    {
        static private void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        static private void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static private void White()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

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
            }
            catch (AddDataThatIsAlreadyInTheListException ex)
            {
                Red();
                Console.Write("Message: ");
                Green();
                Console.Write(ex.Message);
                White();
            }
            uList.Display();
        }
    }
}
