namespace StructureProject
{
    //Class defining
    // public class MyStruct
    // {
    //     public void Display()
    //     {
    //         Console.WriteLine("Method in a class");
    //     } 

    //     public static void Main()
    //     {
    //         MyStruct myStruct = new MyStruct();
    //         myStruct.Display();
    //     }
    // }

    //Strcuture defining
    //     public struct MyStruct
    //     {
    //         public void Display()
    //         {
    //             Console.WriteLine("Method in a structure");
    //         } 

    //         public static void Main()
    //         {
    //             //check the string(reference type) is implemented as class
    //             //string //right click and go to definition, it is defined as class 
    //             //int //right click and go to definition, it is defined as struct, IL format of int is Int32
    //             //float //right click and go to definition, it is defined as struct, IL format of float is Single
    //             MyStruct myStruct = new MyStruct();
    //             myStruct.Display();
    //         }
    //     }
    // }

    //looks like both class and structure are similar, then the doubt will raise that what is the difference between them
    //The main difference between class and structure is that class is a reference type and structure is a value type.
    //instance of a class is stored in heap memory and instance of a structure is stored in stack memory.

    //IL - Intermediate Language, it is the language in which C# code is compiled. When we compile C# code, it is converted into IL code, which is then executed by the .NET runtime.

    //--------------------------------Initialization and declaration at the same time--------------------------------
    //In class, we can initialize the members at the time of declaration, but in structure, we cannot initialize the members at the time of declaration.
    //     public struct MyStruct
    //     {
    //         int i = 10; //error - A 'struct' with field initializers must include an explicitly declared constructor.
    //         //but if you declare a filed like int i; then it will not give any error because the default constructor will initialize the value of i to 0.
    //         //the solution is to initialize the field inside the void Main() method
    //         public void Display()
    //         {
    //             Console.WriteLine("Method in a structure" + i);
    //         }

    //         public static void Main()
    //         {
    //             //check the string(reference type) is implemented as class
    //             //string //right click and go to definition, it is defined as class 
    //             //int //right click and go to definition, it is defined as struct, IL format of int is Int32
    //             //float //right click and go to definition, it is defined as struct, IL format of float is Single
    //             MyStruct myStruct = new MyStruct();
    //             //solution for the error is to initialize at the time od declaration.
    //             myStruct.i = 10;
    //             myStruct.Display();

    //             //if a strcuture contain any fields and the instance of struct is not created by using new keyword then it will give an error because the default constructor will not initialize the value of i to 0.
    //             //initilization is mandatory for the above case.
    //         }
    //     }
    // }

    //The below problem is only on the lower version of C#, which is C# 9 and below.
    //--------------------------------Parameterized constructor only we can define in structure--------------------------------
    //in class, we can define both parameterized and non-parameterized constructor, but in structure, we can define only parameterized constructor.
    public struct MyStruct
    {
        int i;

        //if i am ceating my own constructor then it will throw an error
        public MyStruct() //error - Structs cannot contain explicit parameterless constructors (except in C# 10 or later)
        {
            i = 100; //but if you initialize the field to some value then it won't reflect in the output, because while creating instance of struct, we haven't used new keyword and default constructor.
        }
        public void Display()
        {
            Console.WriteLine("Method in a structure " + i);
        }

        public static void Main()
        {
            MyStruct myStruct;
            myStruct.i = 10;
            myStruct.Display();
        }
    }
}