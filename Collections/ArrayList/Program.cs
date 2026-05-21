using System.Collections;

namespace CollectionProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            Console.WriteLine("ArrayList Size before adding a value: " + al.Capacity); // Intially size is 0

            al.Add(100);
            Console.WriteLine("ArrayList Size after adding a value: " + al.Capacity); // adding 1st item, size is 4

            al.Add(200); al.Add(300); al.Add(400);
            Console.WriteLine("ArrayList Size after adding 4 values: " + al.Capacity); // adding all 4 items, size is 4

            al.Add(500);
            Console.WriteLine("ArrayList Size after adding 5 values: " + al.Capacity); // adding 5th item, size is 8 // 0, 4, 8, 16, 32, etc (doubling the size when capacity is reached)

            //how to print the values in the ArrayList
            foreach (int number in al)            
                Console.Write(number + " ");    
            Console.WriteLine();        

            //insert a item in a specific index
            al.Insert(3, 350);
            foreach (int number in al)            
                Console.Write(number + " "); 
            Console.WriteLine(); 

            //remove a item 
            al.Remove(200);    
            foreach (int number in al)            
                Console.Write(number + " ");   
            Console.WriteLine(); 

            //remove item at a specific index
            al.RemoveAt(2);        
            foreach (int number in al)            
                Console.Write(number + " ");   
            Console.WriteLine(); 

            ArrayList al2 = new ArrayList(10); // you can also specify the initial size(capacity) of the ArrayList
            Console.WriteLine("ArrayList2 Size: " + al2.Capacity); //once all items are added, size will be doubled to 20

            Console.ReadLine();
        }
    }
}