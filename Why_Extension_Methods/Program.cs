// Without Extension Method (Problem 1)
// You cannot modify built-in types like String, Int, DateTime, etc

// public class string
// {
//     public bool IsLong()
//     {
//         return this.Length > 5;
//     }
// }

//You cannot inherit from built-in types like String, Int, DateTime, etc(Problem 2)
// class MyString : string
// {
//     public void sayHello(string name)
//     {
//         Console.WriteLine("Hello " + name);
//     }
// }
//by build or run the code will throw error - error CS0509: 'MyString': cannot derive from sealed type 'string'

//Solution - WITH Extension Method
namespace ExtensionMethodSolution
{
    public static class StringExtensions
    {
        public static bool isLong(this string str)
        {
            //"this" keyword attach methd to the type(means "this" binds this method to the string built-in methods)
            return str.Length > 5;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string name1 = "Aravinth";
            string name2 = "San";

            Console.WriteLine(name1.isLong());
            Console.WriteLine(name2.isLong());

            //What compiler actually does
            //StringExtension.isLong(name1);
        }
    }

}