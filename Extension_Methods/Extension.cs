using System;

namespace ExtensionMethodsProject
{
    //Step 1: created a new static class 
    public static class Extension
    {
        //every members under the static class must be static
        // public static void test3()
        // {
        //     Console.WriteLine("Method3");
        // }
        //this test3() Method belongs to Extension Class, but we want to bind this test3 method with Program Class
        //how to bind with Program Class
        //let's take the below example
        //public static void test3(int x) --> this means this method require integer parameter value to run
        //public static void test3(string name) --> this means this method require string parameter value to run
        //int, string are what those are also type(data type)
        //same like above 2 methods, public static void test3(Program p) --> this means this method require Program type parameter value to run
        //finally we have to introduce this keyword will change the meaning
        public static void test3(this Program p)  //--> now the method test3 belongs to Program Class
        {
            Console.WriteLine("Method3");
        }
        //after adding the test3 method, go and verify, now program class contain 3 methods, but i am not opening the program class
        //because i don't have source code or i don't have permission, instead i am going to create a class names TestExtension

        //if you change the name of the method from test3 to test2(same method name in Program class), while run from TestExtension, it will call the Program class method not this Extension class method 

        //you can define the test3 with parameters accepting like below
        public static void test3(this Program p, int i)  //--> now the method test3 belongs to Program Class
        {
            Console.WriteLine("Method3");
        }

        //extension method for finding a factorial of the number <-- before look into the below code go and read the scenario i mentioned in the TestExtension after Console.ReadLine();
        public static long Factorial(this Int32 x)  //--> now the method factorial bound to Int32(means int) and we don't want the additional parameter to catch the integer to find the factorial, x will catch the interger value
        {
            if(x == 1)
                return 1;
            if(x == 2)
                return 2;
            else
                return x * Factorial(x - 1); //recursive function
        }
        //how the method works
        //lets take number 5 is passed to this method
        //5 --> first 2 conditions false, going to else part 
        //5 * Factorial(4)
        //5 * 4 * Factorial(3)
        //5 * 4 * 3 * Factorial(2)
        //5  * 4 * 3 * 2 ==> 120 resiult
        //now again go to TestExtension class 

        //before look into the code first check the scenario after the 29th line of testextension class
        public static string toProper(this string oldStr)
        {
            if(oldStr.Trim().Length > 0) //we can aslo do string.IsNullOrEmpty(olsStr)
            {
                string newStr = null;
                //logic
                //hEllo How ARe yoU --> first convert all to lowe case using the predefined string method, after this identify the words and convert the first letter to upper case
                oldStr = oldStr.ToLower();
                //want to find out the word of a string
                string[] sarr = oldStr.Split(' ');
                //loop over the string array
                foreach(string str in sarr)
                {
                    //i want to convert the string into char array contain characters of string
                    char[] carr = str.ToCharArray();
                    //to convert the first character into upper case, index 0 of carr to upper case
                    carr[0] = Char.ToUpper(carr[0]);
                    //again we convert this back into a string from character array
                    //for that we have a constructor under string class
                    if(newStr == null)
                        newStr = new string(carr);
                    else
                        newStr = newStr + " " + new string(carr); 
                }
                return newStr;
            }            
            return oldStr;
        }
    }
}