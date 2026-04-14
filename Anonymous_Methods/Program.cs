namespace DelegatesProject
{
    public delegate string greetDelegate(string name);
    class AnonymousMethods
    {
        // public static string greetings(string name)
        // {
        //     return "Hello " + name + " a very good morning";
        // }

        public static void Main()
        {
            //usual way to call the delegate 
            // greetDelegate gd = new greetDelegate(greetings);
            // string result = gd("Aravinth");
            // Console.WriteLine(result);

            //what we did upto now is we wrote a method and bind the name of the method to the delegate, we can simplify this process

            greetDelegate gd2 = delegate(string name)
            {
                //directly put the logic here
                return "Hello " + name + " a very good morning";
                //after this we don't need a sparate method greetings, you can delete the method
            };
            //the above code is called as a anonymous method, a method without a name, only contain a body
            //method is defined by using the delegate keyword

            string result2 = gd2("Aravinth");
            Console.WriteLine(result2);

            Console.ReadLine();
        }
    }
}