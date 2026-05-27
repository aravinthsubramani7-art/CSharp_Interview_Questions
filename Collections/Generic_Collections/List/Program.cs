using System.Collections.Generic;
namespace GenericCollections
{
    public class GenericList
    {
        public static void Main(string[] args)
        {
            List<int> li = new List<int>();
            //the behaviour of List is same as ArrayList but the only difference is that List is a generic collection.
            //whatever we did with ArrayList we can do with List

            li.Add(10);
            li.Add(20);
            li.Add(30);
            li.Add(40);
            li.Add(50);
            li.Add(60);

            for (int i = 0; i < li.Count; i++)
            {
                Console.Write(li[i] + " ");
            }

            Console.WriteLine();

            li.Insert(3, 35);
            foreach (int number in li)
                Console.Write(number + " ");

            Console.WriteLine();

            li.RemoveAt(1);
            foreach (int number in li)
                Console.Write(number + " ");
            Console.ReadLine();
        }
    }
}