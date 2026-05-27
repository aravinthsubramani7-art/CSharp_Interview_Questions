namespace GenericCollections
{
    public class Generics1
    {
        // public bool Compare(int a, int b)
        // {
        //     if (a == b)
        //         return true;
        //     else
        //         return false;
        // }

        public bool Compare(object a, object b)
        {
            if (a.Equals(b))
                return true;
            else
                return false;
        }

        public bool Compare<T>(T a, T b)
        {
            if (a.Equals(b))
                return true;
            else
                return false;
        }

        public static void Main(string[] args)
        {
            Generics1 obj = new Generics1();
            bool result = obj.Compare(10, 20);

            Console.WriteLine(result);
            //Console.ReadLine();

            //the Compare Method only compare 2 integer values, if i want to compare 2 string or 2 float, i want to write 2 more methods to compare string and float values.
            //so we can use object instead of int in the input parameter of the Compate method
            Console.WriteLine(obj.Compare(10.45f, 10.45f));
            
            Console.WriteLine(obj.Compare(true, true));

            //because we used object data type in the input parameter, it can take any type of data
            Console.WriteLine(obj.Compare("Hello", 10));
            //DarwBack 1 - so this is not type safe
            //DrawBack 2 - the input parameter type is object the incoming value will be performed boxing and unboxing operation, which can cause performance issues, because when we pass a value type like int or float to the Compare method, it will be boxed into an object, and when we try to compare it with another value type, it will be unboxed back to its original type, which can cause performance issues.
            //to overcome these drawbacks, in c# 2.0, microsoft introduce a concept called Generics
            Console.WriteLine(obj.Compare<float>(12.45f, 23.56f));

            Console.WriteLine(obj.Compare<int>(10, 10));
        }
    }
}