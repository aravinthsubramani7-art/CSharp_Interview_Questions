//----------------------all instance of the class will have same value for x variable----------------------
// namespace ConstructorProject4
// {
//     public class First
//     {
//         public int x = 100;
//     }

//     public class TestClasses
//     {
//         static void Main()
//         {
//             First f1 = new First();
//             First f2 = new First();
//             First f3 = new First();
//             //when we create 3 instances of the class, internally it is going to get the memory separate for each instance we created
//             //and in all 3 instance we will be have a copy of x varaibale
//             //we created 3 instances and all 3 has x varaible with same value, this is the problem
//             //how x get 100, the First class has a implicit constructor and when we create the instance of that class, the implicit constructor is going to get called and it is going to initialize the x variable with 100.
//             Console.WriteLine(f1.x + " " + f2.x + " " + f3.x);
//         }
//     }
// }

//
namespace ConstructorProject4
{
    public class First
    {
        public int x = 100;
    }

    public class Second
    {
        public int x;
        public Second(int x)
        {
            this.x = x;
        }
    }

    public class TestClasses
    {
        static void Main()
        {
            First f1 = new First();
            First f2 = new First();
            First f3 = new First();
            
            Console.WriteLine(f1.x + " " + f2.x + " " + f3.x);

            //i want the x value to be different for each instance.
            Second s1 = new Second(100);
            Second s2 = new Second(200);
            Second s3 = new Second(300);
            //what is the advantage, 3 times we created the instance and 3 times the memory is allocated but internally the value of the x is 100, 200, 300
            Console.WriteLine(s1.x + " " + s2.x + " " + s3.x);
        }
    }
}