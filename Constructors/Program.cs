using System.Net;

namespace ConstrcutorProjects
{
    // public class Program
    // {
    //     int i;
    //     bool b;
    //     public static void Main(string[] args)
    //     {
    //         Program p = new Program();
    //         Console.WriteLine("value of i: " + p.i); //0 through the implicit constructor the i is initialized with 0   
    //         Console.WriteLine("value of b: " + p.b); //false
    //     }
    // }

    //--------------------------------Explicit constructor--------------------------------
    public class ExplicitContructorDemo
    {
        public ExplicitContructorDemo() //this is the explicit constructor we defined, defining can be implicit or explicit, but calling a constructor should be explicit only
        {
            Console.WriteLine("Constructor is called");
        }

        static void Main()
        {
            ExplicitContructorDemo explicitContructorDemo = new ExplicitContructorDemo();
            ExplicitContructorDemo explicitContructorDemo1 = new ExplicitContructorDemo();
            ExplicitContructorDemo explicitContructorDemo2 = new ExplicitContructorDemo();

            //every time you create a instnace of the class, the constructor will be called.
            Console.ReadLine();
        }
    }
}