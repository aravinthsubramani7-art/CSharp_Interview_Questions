namespace RecursiveProjects
{
    public class Program
    {
        public static int Factorial(int n)
        {
            if(n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        }
        public static void Main()
        {
            Console.WriteLine("Enter a number to find out Factorial: ");
            int number = int.Parse(Console.ReadLine());
            int result = Factorial(number);
            Console.WriteLine($"Factorial of {number} is: {result}");
            Console.ReadLine();
        }
    }
}