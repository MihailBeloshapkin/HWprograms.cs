using System;

namespace HW2T2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash table = new Hash(2);
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
        }
    }
}
