namespace ContructorProjects3
{
    public class StaticConstructor
    {
        static StaticConstructor()
        {
            Console.WriteLine("Static constructor is called");
        } 

        public static void Main() //if you run this program with empty Main method, you will see the output of static constructor, we did not called the contructor anywhere
        {
            Console.WriteLine("Main method is executed."); //this will prited on console aftet the static constructor executed, then the question may raise that is "is the execution going to start with sttaic constructor ?", the answer is No, execution always starts with Main Method, but what happend is before executing the content of Main Method the constrol jumps into sttaic constructor and return to Main 
        }
    }
}