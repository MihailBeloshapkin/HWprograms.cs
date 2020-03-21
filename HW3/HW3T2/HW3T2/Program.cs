using System;

namespace HW3T2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash table = new Hash(2, 0);
            table.AddToHashTable("java");
            table.AddToHashTable("stack");
            table.AddToHashTable("tree");
            table.AddToHashTable("exception");
            table.AddToHashTable("graph");
            table.AddToHashTable("Pointer");
            table.AddToHashTable("Error");
            table.AddToHashTable("Warning");
            table.AddToHashTable("Variable");
            table.DisplayHashTable();
            table.DeleteDataFromHashTable("exception");
            table.DeleteDataFromHashTable("Warning");
            Console.WriteLine();
        
            Hash table1 = new Hash(2, 1);
            table1.AddToHashTable("java");
            table1.AddToHashTable("stack");
            table1.AddToHashTable("tree");
            table1.AddToHashTable("exception");
            table1.AddToHashTable("graph");
            table1.AddToHashTable("Pointer");
            table1.AddToHashTable("Error");
            table1.AddToHashTable("Warning");
            table1.AddToHashTable("Variable");
            table1.DisplayHashTable();
            table1.DeleteDataFromHashTable("exception");
            table1.DeleteDataFromHashTable("Warning");
            Console.WriteLine();
        }
    }
}
