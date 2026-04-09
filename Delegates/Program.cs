namespace DelegatesProject
{
    class Program
    {
        //Step 1: Defining a Delegate
        public delegate void AddDelegate(int a, int b);
        public delegate string SayDelegate(string name);

        public void AddNums(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public static string SayHello(string name)
        {
            return "Hello " + name;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.AddNums(100, 50);            
            string str = Program.SayHello("Aravinth");
            Console.WriteLine(str);

            //Step 2: instantiating a delegate
            //AddDelegate ad = new AddDelegate(AddNums); //--> intellisence not showing the method 
            //why the method is not showing here or throw console error
            //your method is a non-static method and right now you are creating instance of a delegate in a static block
            //a non-static member of a class can never be accessed from a static block directly, you can access only by the instance of class
            AddDelegate ad = new AddDelegate(p.AddNums);
            //from above instantiation --> the address of the method is given to the ad delegate, why, deletgate holds the address/reference of a method or 
            SayDelegate sd = new SayDelegate(SayHello);

            //step 3: call the delegate
            ad(100, 50);
            ad.Invoke(100, 50);
            string str1 = sd("Aravinth");
            string str3 = sd.Invoke("Aravinth");
            Console.WriteLine(str1);
            Console.WriteLine(str3);
            //actually whenever you call the delegate, internally the method get executed not the delegate, delegate doesn't has a body and delegate is a pointer to a method
            Console.ReadLine();
        }
    }
}