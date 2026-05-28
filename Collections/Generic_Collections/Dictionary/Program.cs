using System.Security.Cryptography;

namespace GenericCollections
{
    public class DictionaryCollection
    {
        public static void Main(string[] args)
        {
            Dictionary<string, object> dt = new Dictionary<string, object>();
            dt.Add("EmpId", 1001);
            dt.Add("EmpName", "John Doe");
            dt.Add("EmpDept", "IT");
            dt.Add("EmpSalary", 50000);
            dt.Add("EmpEmail", "john.doe@company.com");
            dt.Add("EmpPhone", "123-456-7890");

            //the same Keys property available for Dictionary collection as well, but the order of keys is in sequential order where we added the key values, unlike hashtable where the order of keys is not guaranteed
            foreach(string key in dt.Keys)
                Console.WriteLine(key);
            
            Console.WriteLine();
            foreach(string key in dt.Keys)
                Console.WriteLine(key + ": " + dt[key]);
        }
    }
}