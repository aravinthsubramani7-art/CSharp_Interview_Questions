namespace ConstructorProject
{
    // public class ParameterizedConstructor
    // {
    //     public ParameterizedConstructor(int i)
    //     {
    //         Console.WriteLine("Paramerized constructor is called: " + i);
    //     }

    //     public static void Main()
    //     {
    //         ParameterizedConstructor parameterizedConstructor = new ParameterizedConstructor(10); //if you are not passing the value, it will throw an build error

    //         Console.ReadLine();
    //     }
    // }

//---------------------------------Parameterized constructor 2-------------------------------
    public class ParameterizedConstructor
    {
        int x;
        public ParameterizedConstructor(int i)
        {
            x = i;
            Console.WriteLine("Paramerized constructor is called: " + i);
        }

        public void Display()
        {
            Console.WriteLine("Value of x: " + x);
        }

        public static void Main()
        {
            ParameterizedConstructor parameterizedConstructor = new ParameterizedConstructor(10); //if you are not passing the value, it will throw an build error
            ParameterizedConstructor parameterizedConstructor1 = new ParameterizedConstructor(20);

            parameterizedConstructor.Display();
            parameterizedConstructor1.Display();
            Console.ReadLine();
        }
    }
}