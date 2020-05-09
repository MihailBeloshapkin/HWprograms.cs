using System;

namespace HW3T2
{
    class Program
    {
        static void Main(string[] args)
        {
            IHashFunction HashFunction1 = new HashFunction1();
            HashTable table = new HashTable(HashFunction1);
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
            Console.WriteLine();
            table.DeleteDataFromHashTable("exception");
            table.DeleteDataFromHashTable("stack");
            table.DisplayHashTable();
            Console.WriteLine();

            IHashFunction HashFunction2 = new HashFunction2();
            HashTable table1 = new HashTable(HashFunction2);
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