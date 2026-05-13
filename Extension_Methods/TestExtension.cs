namespace ExtensionMethodsProject
{
    public class TestExtension
    {
        public static void Main()
        {
            Program p = new Program();
            p.test3();
            //we can access the method of Program class too
            p.test1();
            p.test2();

            //if you remove 'this' keyword in Extension class, the method test3 doesn't belong to Extension Class
            //see the test3 method is defined in Extension static class, but here it is called using instance instead of the name of the class
            //because Extension Methods are defined as static but once they are bound with any class/ structure they turn into non-static.
            Console.ReadLine();

            //not only the class, i can do extension mehods on structure as well
            //for example i am taken integer, and i am going to add the new method into this int structure
            //we don't have source code, permission how it is possible to add a method, but still i can do it with the help of extension methods feature
            int i = 5;
            //i want to find the factorial of 5, to find a factorial f 5 what should i do 5*4*3*2*1, but everytime i should do that on any number assigned in i variable
            //if int provides me a method for finding a factorial it will be very much helpful for me right
            //i. while i type i. it will give me a method avaible under the int, unfortunately we don't have any factorial method 
            //so i am going to add a extension method for finding a factoorial of the number in the Extension class
            //after successfully Factorial method created in Extension class
            long result = i.Factorial();
            Console.WriteLine("Factorial of {0} is: {1}", 1, result);
            //before run the code comment out the above readline call

            //you can do the above scenario(extending Int32) in sealed class also, string is a predefined class and which is a sealed class
            string str = "hEllo How ARe yoU"; //we already has the predefined methods availble to make the string to uppercase or lowercase
            //but i want to make the string to proper case(every words first character is upper case)
            //add a extension method in extension class and come back here
            str = str.toProper();
            Console.WriteLine(str);
        }
    }
}