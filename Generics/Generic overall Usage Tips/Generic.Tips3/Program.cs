using System;
using System.Collections.Generic;

namespace Generic.Tips3
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Item<int>();
            var b = new Item<int>();
            var c = new Item<string>();

            Console.WriteLine(Item.InstanceCount);
            Console.WriteLine(Item.InstanceCount);
            Console.ReadLine();
        }
    }
    
    public class Item<T>: Item
    {
        
    }
    public class Item
    {
        public Item()
        {
            InstanceCount += 1;
        }
        public static int InstanceCount;
    }
}
