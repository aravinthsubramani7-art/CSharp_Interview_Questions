using System.Collections;

namespace CollectionProjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            //adding value into the hashtable is similar to ArrayList, we gonna to use same Add method, but we need to provide key and value as parameters
            //the key or value can be any data type
            ht.Add("EmpId", 1001);
            ht.Add("EmpName", "John Doe");
            ht.Add("EmpDept", "IT");
            ht.Add("EmpSalary", 50000);
            ht.Add("EmpEmail", "john.doe@company.com");
            ht.Add("EmpPhone", "123-456-7890");
            
            Console.WriteLine(ht["EmpEmail"]); // to access the value in the hashtable, we need to provide the key as parameter, dont need to worry about the index like ArrayList           

            foreach(object key in ht.Keys)            
                Console.WriteLine(key); //when you see the output the keys are not in sequential order where above in added key values

            //the reason why the keys are not in sequential order is because hashtable uses hashing algorithm to store the key-value pairs, it calculates the hash code of the key and stores the value in the corresponding bucket, so the order of keys is not guaranteed
            //every class by default contains 4 methods - ToString(), GetHashCode(), Equals(), GetType()
            //a getHashcode is a numeric representation of value

            Console.WriteLine("Hello".GetHashCode());
            //so hashtable not only contain key and values but alsocontains the hash code of the key, 
            // so when we try to access the value using the key, it finds the hash code of the key and looks for the corresponding bucket to retrieve the value, 
            // so it is very fast to access the value using the key in hashtable compared to ArrayList

            Console.WriteLine();
            //to only fetch the valuesfrom the hashtable
            foreach (object value in ht.Values)
                Console.WriteLine(value);

            Console.WriteLine();
            foreach (object key in ht.Keys)
                Console.WriteLine(key + " : " + ht[key]); // to print the key and value together, we can use the key to access the value in the hashtable

            Console.ReadLine();
            
        }
    }
}