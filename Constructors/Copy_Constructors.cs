namespace ConstructorProjects2
{
    public class CopyConstrutor
    {
        int x;
        public CopyConstrutor(int i) //parameterized constructor
        {
            x = i;
        }

        //copy constructor
        public CopyConstrutor(CopyConstrutor obj)
        {
            x = obj.x;
        }

        //can i define multiple constructor in a same class, yes
        public void Display()
        {
            Console.WriteLine("Value of x: " + x);
        }
        public static void Main()
        {
            CopyConstrutor copyConstrutor = new CopyConstrutor(10);
            copyConstrutor.Display(); //10
            CopyConstrutor copyConstrutor1 = new CopyConstrutor(20); 
            copyConstrutor1.Display(); //20

            //now i want the 2nd instance also to be created with same value 10, tomorrow if we are passing 10 20 parameters, passing all the 20 values everytime is time consuming process
            //to overcome this problem we ca define a copy constructor
            CopyConstrutor copyConstrutor2 = new CopyConstrutor(copyConstrutor); //for a single we generally doesn't use this copy constructor, but tomorrow if we are passing more than 5 parameters, then we can use this copy constructor to create the instance with same value.   
            copyConstrutor2.Display(); //10
            Console.ReadLine();
        }
    }
}