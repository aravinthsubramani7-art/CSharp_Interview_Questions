namespace GenericCollections
{
    // public class Generics2
    // {

    //     public void Add<T>(T a, T b)
    //     {
    //         dynamic d1 = a;
    //         dynamic d2 = b; 

    //         Console.WriteLine(d1 + d2);
    //     }
    //     public void Subtract<T>(T a, T b)
    //     {
    //         dynamic d1 = a;
    //         dynamic d2 = b;

    //         Console.WriteLine(d1 - d2);
    //     }
    //     public void Multiply<T>(T a, T b)
    //     {
    //         dynamic d1 = a;
    //         dynamic d2 = b;

    //         Console.WriteLine(d1 * d2);
    //     }
    //     public void Divide<T>(T a, T b)
    //     {
    //         dynamic d1 = a;
    //         dynamic d2 = b;

    //         Console.WriteLine(d1 / d2);
    //     }
    //     public static void Main(string[] args)
    //     {
    //         Generics2 obj = new Generics2();
    //         obj.Add<int>(10, 20);
    //         obj.Subtract<int>(20, 10);
    //         obj.Multiply<int>(10, 20);
    //         obj.Divide<int>(20, 10);

    //         //instead of passing the type into the method, we can also pass the type into the class, so that we dont need to specify the type every time we call the method, we can just specify the type once and use it for all the methods in the class
    //         //which is implemented in the below example
    //         Console.ReadLine();
    //     }
    // }

    public class Generics2<T>
    {
        public void Add(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;

            Console.WriteLine(d1 + d2);
        }
        public void Subtract(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;

            Console.WriteLine(d1 - d2);
        }
        public void Multiply(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;

            Console.WriteLine(d1 * d2);
        }
        public void Divide(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;

            Console.WriteLine(d1 / d2);
        }
    }

    public class TestGenerics{
        public static void Main(string[] args)
        {
            Generics2<int> obj = new Generics2<int>();
            obj.Add(10, 20);
            obj.Subtract(20, 10);
            obj.Multiply(10, 20);
            obj.Divide(20, 10);

            Console.ReadLine();
        }
    }
}