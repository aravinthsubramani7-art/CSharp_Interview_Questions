// namespace GenericCollection2
// {
//     public class Student : IComparable<Student> //here i have inherited the IComparable interface of Student type, if you run the program only with this(only with the inherited IComparable) will throw an error - 'Student' does not implement interface member 'IComparable<Student>.CompareTo(Student?)'
//     {
//         public int Sid { get; set; }
//         public string Name { get; set; }
//         public int Class { get; set; }
//         public float Marks { get; set; }

//         //since it is a VSCode we don't have some features available in VS, so to overcome the error('Student' does not implement interface member 'IComparable<Student>.CompareTo(Student?)'), in VS right click on the IComparable and click on Quick Actions and Refactorings, then click on Implement Interface, then it will generate the CompareTo method for you, but in VSCode we don't have this feature, so we need to implement the CompareTo method manually.
//         public int CompareTo(Student other)
//         {
//             //throw new NotImplementedException();
//             //below is the mplementation
//             if(this.Sid > other.Sid) //here other means the current object which is being compared with the other object, so if the current object's Sid is greater than the other object's Sid, then it will return 1, which means the current object is greater than the other object, so it will be placed after the other object in the sorted order
//                 return 1;  //if you want the sorting should be performed in the descending order, simply change the return value from 1 to -1
//             else if(this.Sid < other.Sid)
//                 return -1; //if you want the sorting should be performed in the descending order, simply change the return value from -1 to 1
//             else
//                 return 0;
//         }

//     }

//     class CompareStudents : IComparer<Student>
//     {
//         //same what we did in ICOmparable interface that quick action and refactoring same do it here
//         public int Compare(Student x, Student y)
//         {
//             //throw new NotImplementedExcpetion();
//             if(x.Marks > y.Marks)
//                 return 1;
//             else if(x.Marks < y.Marks)
//                 return -1;
//             else
//                 return 0;

//         }
//     }

//     public class TestStudent
//     {
//         public static void Main()
//         {
//             Student s1 = new Student { Sid = 1003, Name = "John Doe", Class = 10, Marks = 85.5f };
//             Student s2 = new Student { Sid = 1006, Name = "Jane Smith", Class = 10, Marks = 90.0f };
//             Student s3 = new Student { Sid = 1004, Name = "Bob Johnson", Class = 10, Marks = 80.0f };   
//             Student s4 = new Student { Sid = 1002, Name = "Alice Williams", Class = 10, Marks = 95.0f };
//             Student s5 = new Student { Sid = 1001, Name = "Tom Brown", Class = 10, Marks = 75.0f };
//             Student s6 = new Student { Sid = 1005, Name = "Emily Davis", Class = 10, Marks = 88.0f };

//             List<Student> students = new List<Student>() { s1, s2, s3, s4, s5, s6 }; //collection initializers
                    
//             CompareStudents cs = new CompareStudents();

//             //if i want to sort the remaining values rather the first & last value in the list
//             students.Sort(1, 4, cs); //index, count, IComparer object
//             foreach(Student obj in students)
//                 Console.WriteLine(obj.Sid + " " + obj.Name + " " + obj.Class + " " + obj.Marks);
//         }
//     } 
// }

//-----------------------------------------Comparison delegate-------------------------------------------------

namespace GenericCollection2
{
    public class Student : IComparable<Student> 
    {
        public int Sid { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public float Marks { get; set; }
        
        public int CompareTo(Student other)
        {        
            if(this.Sid > other.Sid) 
                return 1;  
            else if(this.Sid < other.Sid)
                return -1; 
            else
                return 0;
        }

    }

    class CompareStudents : IComparer<Student>
    {        
        public int Compare(Student x, Student y)
        {            
            if(x.Marks > y.Marks)
                return 1;
            else if(x.Marks < y.Marks)
                return -1;
            else
                return 0;

        }
    }

    public class TestStudent
    {
        // public static int CompareNames(Student S1, Student S2)
        // {
        //     //for string the CompateTo is already been implemented(inbuilt)
        //     return S1.Name.CompareTo(S2.Name);

        // }
        public static void Main()
        {
            Student s1 = new Student { Sid = 1003, Name = "John Doe", Class = 10, Marks = 85.5f };
            Student s2 = new Student { Sid = 1006, Name = "Jane Smith", Class = 10, Marks = 90.0f };
            Student s3 = new Student { Sid = 1004, Name = "Bob Johnson", Class = 10, Marks = 80.0f };   
            Student s4 = new Student { Sid = 1002, Name = "Alice Williams", Class = 10, Marks = 95.0f };
            Student s5 = new Student { Sid = 1001, Name = "Tom Brown", Class = 10, Marks = 75.0f };
            Student s6 = new Student { Sid = 1005, Name = "Emily Davis", Class = 10, Marks = 88.0f };

            List<Student> students = new List<Student>() { s1, s2, s3, s4, s5, s6 }; //collection initializers
                    
            //CompareStudents cs = new CompareStudents();

            //Comparision --> delegate, we just created a object for the delegate and passed the method name as a parameter.
            Console.WriteLine("-------Comparison Delegate-------");
            //Comparison<Student> obj = new Comparison<Student>(CompareNames);   //commented because the CompareNames commented
            
            //students.Sort(obj);  //commented because the CompareNames commented
            //what should happend now, the sort method calls the delegate, the delegate calls the method CompsreNames, and the CompareNames method compares the Name property of the Student objects and returns the result, based on the result the Sort method sorts the objects in the ascending order based on the Name property.           
            foreach(Student s in students)
                Console.WriteLine(s.Sid + " " + s.Name + " " + s.Class + " " + s.Marks);

            //see why we used delegate here is, we need to pass the CompareNames method in the Sort Method, but a method cannot be passed as a parameter to another method
            //a method is not a type, but parameter should be type like a class, delegate, interface, structure
            //for this reason only we used the delegate as a parameter to the Sort Method, first what we did is link a method with delegate and that delegate is passed aa a parameter

            Console.WriteLine("-------Directly Passing Method Name-------");
            //students.Sort(CompareNames);  //commented because the CompareNames commented
            foreach(Student s in students)
                Console.WriteLine(s.Sid + " " + s.Name + " " + s.Class + " " + s.Marks);
            //but still you can pass the method name directly to the Sort Method.
            //because it has a overload which takes Comparison delegate as a parameter, Comparison delegate signature is matching with CompareNames
            //if you directly pass the method name, internally it will create a instance of a Comparison delegate and uses there.

            Console.WriteLine("-------Anonymous Method-------");
            //and you can still simplify this with the anyonymous method.
            //comment CompareNames method
            //so that you are commenting CompareNames methods, the usage places also you have to comment it out
            students.Sort(delegate(Student S1, Student S2) { return S1.Name.CompareTo(S2.Name); });
            foreach(Student s in students)
                Console.WriteLine(s.Sid + " " + s.Name + " " + s.Class + " " + s.Marks);

            Console.WriteLine("-------Lambda Expression-------");
            //and you can still simplify this with the lambda expression.
            students.Sort((S1, S2) => S1.Name.CompareTo(S2.Name));
            foreach(Student s in students)
                Console.WriteLine(s.Sid + " " + s.Name + " " + s.Class + " " + s.Marks);
        }
    } 
}
