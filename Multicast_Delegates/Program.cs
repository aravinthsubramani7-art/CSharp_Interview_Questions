//Implementation of Multicast Delegates
// namespace DelegateProjects
// {
//     class Rectangle
//     {
//         //Step 1: Define a delegate
//         public delegate void rectDelegate(double width, double height); 
//         public void GetArea(double Width, double Height)
//         {
//             Console.WriteLine("Area of Rectangle: " + Width * Height);
//         }
//         public void GetPerimeter(double Width, double Height)
//         {
//             Console.WriteLine("Perimeter of Rectangle: " + 2 *(Width + Height));
//         }

//         public static void Main()
//         {
//             Rectangle rect = new Rectangle();
//             rect.GetArea(12.34, 56.78);
//             rect.GetPerimeter(12.34, 56.78);

//             //anyway we don't need 2 different delegate to call methods
//             //since both the methods signature is same (same type of parameters & same return type)
//             //and also same values will be passed since it is the methods to calculate the area & perimeter of a same rectangle

//             //Step 2: Instantiation of a delegate
//             rectDelegate rd = new rectDelegate(rect.GetArea);
//             //another way of instantiation
//             //rectDelegate rd = rect.GetArea;

//             //Step 3: call the delegate
//             rd(12.34, 56.78);
//             rd.Invoke(12.34, 56.78);

//             //now i want to call the perimeter method through same delegate
//             rd += rect.GetPerimeter;
//             rd(12.34, 56.78);
//             Console.ReadLine();
//         }
//     }
// }

//---------------------------------------------------------------------------------------------------------------------------------

//Implementation of drawback of multicast delegate
// namespace MulticastDelegateDrawback
// {
//     class MulticastDelegateDrawback
//     {        
//         //return type of the methods are double the value returning
//         public delegate double rectDelegate(double width, double height); 
//         public double GetArea(double Width, double Height)
//         {
//            return Width * Height;
//         }
//         public double GetPerimeter(double Width, double Height)
//         {
//             return 2 *(Width + Height);
//         }

//         public static void Main()
//         {
//             MulticastDelegateDrawback rect = new MulticastDelegateDrawback();
//             rectDelegate rd = new rectDelegate(rect.GetArea);

//             rd += rect.GetPerimeter;

//             double result = rd(12.34, 56.78);
//             Console.WriteLine(result);
//             Console.ReadLine();
//         }
//     }
// }

//---------------------------------------------------------------------------------------------------------------------------------

//Overcome implementation of multicast delegate
namespace OverCome
{
    class MulticastDelegateDrawbackOverCome
    {        
        //return type of the methods are double the value returning
        public delegate double rectDelegate(double width, double height); 
        public double GetArea(double Width, double Height)
        {
           return Width * Height;
        }
        public double GetPerimeter(double Width, double Height)
        {
            return 2 *(Width + Height);
        }

        public static void Main()
        {
            MulticastDelegateDrawbackOverCome rect = new MulticastDelegateDrawbackOverCome();
            rectDelegate rd = new rectDelegate(rect.GetArea);

            rd += rect.GetPerimeter;

           foreach (rectDelegate func in rd.GetInvocationList())
            {
                double result = func(12.34, 56.78);
                Console.WriteLine(result);
            }
            
            Console.ReadLine();
        }
    }
}