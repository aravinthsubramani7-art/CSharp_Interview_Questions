namespace ExtensionMethodsProject
{
    public class Program
    {
        public void test1()
        {
            Console.WriteLine("Method1");
        }
        public void test2()
        {
            Console.WriteLine("Method2");
        }
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.test1();
            p.test2();

            Console.ReadLine();

            //you need to add test3 method in the Program class
            //Assume you don't have a Program Source code or that is already sent for testing
            //now you are going to create a static class - Extension Class
        }
    }
}