namespace CollectionProject
{
    public class Customer
    {
        public int cusId { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public double balance { get; set; }
    }

    public class TestCustomer
    {
        public static void Main(string[] args)
        {
            List<Customer> customer = new List<Customer>();
            Customer c1 = new Customer { cusId = 1001, name = "John Doe", city = "New York", balance = 5000 };
            Customer c2 = new Customer { cusId = 1002, name = "Jane Smith", city = "Los Angeles", balance = 3000 };
            Customer c3 = new Customer { cusId = 1003, name = "Bob Johnson", city = "Chicago", balance = 7000 };   
            Customer c4 = new Customer { cusId = 1004, name = "Alice Williams", city = "Houston", balance = 2000 };

            customer.Add(c1);
            customer.Add(c2);
            customer.Add(c3);  
            customer.Add(c4);

            //instead of adding customer object into the List cllection, we have a way to add the objects at a time --> AddRange() method, which is used to add a collection of objects into the List collection, we can pass the List collection as a parameter to the AddRange() method, and it will add all the objects in the List collection into the List collection

            foreach(Customer obj in customer)
                Console.WriteLine(obj.cusId + " " + obj.name + " " + obj.city + " " + obj.balance);

            Console.ReadLine();
        }
    }
}