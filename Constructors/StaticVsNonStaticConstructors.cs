namespace ConstructorDemo
{
    public class StaticVsNonStaticConstructors
    {
        int x;
        static int y;
        static StaticVsNonStaticConstructors() //don't use the access modifers here, it will throw an error
        {
            Console.WriteLine("static constructor is called.");
        }

        public StaticVsNonStaticConstructors()
        {
            Console.WriteLine("non-static constructor is called.");
        }

        public StaticVsNonStaticConstructors(int x) //but if you try to use the parameters in the static constructors will throw an error, static constructors are paramter less
        {
            this.x = x; 
            Console.WriteLine("non-static parameterized constructor is called.");
        }
        static void Main()
        {
            //with the empty main method and if you run this code you will see the static constructor output, implicitly caalled
            Console.WriteLine("Main Method executed"); //it will display after the static constructor displays output and always the Main is the entry point of the program, without Main method we can't run the program

            //non-sttaic constructors are called only after creating the instance of the class, must be explicitly called.
            StaticVsNonStaticConstructors s1 = new StaticVsNonStaticConstructors();
            StaticVsNonStaticConstructors s2 = new StaticVsNonStaticConstructors();
            //after creating the 2 instance the non-static constructors are called 2 times but the static constructor si still called once.

            Console.WriteLine(y); //a static member of the class can be directly accessed in the static block
            Console.WriteLine(s1.x + " " + s2.x); //a non-static member of the class can only be accessed through the instance of the class

            StaticVsNonStaticConstructors s3 = new StaticVsNonStaticConstructors(10);
            StaticVsNonStaticConstructors s4 = new StaticVsNonStaticConstructors(20);

            Console.WriteLine(s3.x + " " + s3.x);
        }
    }
}