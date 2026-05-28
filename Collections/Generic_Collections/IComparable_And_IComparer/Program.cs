// namespace GenericCollections
// {
//     public class Student
//     {
//         public int Sid { get; set; }
//         public string Name { get; set; }
//         public int Class { get; set; }
//         public float Marks { get; set; }
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
            
//             foreach(Student obj in students)
//                 Console.WriteLine(obj.Sid + " " + obj.Name + " " + obj.Class + " " + obj.Marks);
            
//             //if you see the result, the values are printed in the order how they are added into the List
//             //but i want to print it in the sorted order based on the Sidproperty, so we can use the Sort() method of the List collection, but before that we need to implement the IComparable interface in the Student class, which is used to compare the objects of the Student class based on the Sid property, and then we can use the Sort() method to sort the objects in the List collection based on the Sid property

//             students.Sort();

//             foreach(Student obj in students)
//                 Console.WriteLine(obj.Sid + " " + obj.Name + " " + obj.Class + " " + obj.Marks);
            
//             //the above foreach metthod will throw an exception called InvalidOperationException
//             //If you try to use the same Sort Method on the Generic collection(List) of primitive types(Int, String, Float, Char), it will work without throws any exception, but here we used User defined type(class) as a type which is a complex type contain multiple values in it, so that it is struggling to sort(compiler confusing based on what property should I perform the sorting operation)
//             //the solution is provided in the below example
//         }
//     } 
// }

//----------------------------------------------------Solution for the above problem----------------------------------------------------

// namespace GenericCollections
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
            
//             //after implementing CompareTo method, now you can use the Sort() method to sort the objects based on the Sid property, and it will work without throwing any exception, because now the compiler knows how to compare the objects of the Student class based on the Sid property, so it can perform the sorting operation based on the Sid property.
//             students.Sort();

//             //if you don't want to change the logic of the CompareTo method, which is used to sort the objects in the ascending order based on the Sid property, but you want to sort the objects in the descending order based on the Sid property, then you can simply reverse the sorted order using the Reverse() method of the List collection, because the Sort() method will sort the objects in the ascending order by default, so if you want to sort the objects in the descending order, you can simply reverse the sorted order using the Reverse() method.
//             students.Reverse(); //if you want to sort the objects in the descending order, you can use the Reverse() method after sorting the objects in the ascending order, because the Sort() method will sort the objects in the ascending order by default, so if you want to sort the objects in the descending order, you can simply reverse the sorted order using the Reverse() method.
//             foreach(Student obj in students)
//                 Console.WriteLine(obj.Sid + " " + obj.Name + " " + obj.Class + " " + obj.Marks);

//             //if this Student class someone defined it and given to me and i am consuming this class and right now sorting to be performed based on the marks
//             //i can't because the logic has been already implemented by someone and that logic is based on what based on Sid, i cannot chnage the logic because that is not my class and i don't have the source code
//             //in such scenario, the solution is available in below example
//         }
//     } 
// }

//----------------------------------------------------Solution for the above problem using IComparer interface----------------------------------------------------

namespace GenericCollections
{
    public class Student : IComparable<Student> //here i have inherited the IComparable interface of Student type, if you run the program only with this(only with the inherited IComparable) will throw an error - 'Student' does not implement interface member 'IComparable<Student>.CompareTo(Student?)'
    {
        public int Sid { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public float Marks { get; set; }

        //since it is a VSCode we don't have some features available in VS, so to overcome the error('Student' does not implement interface member 'IComparable<Student>.CompareTo(Student?)'), in VS right click on the IComparable and click on Quick Actions and Refactorings, then click on Implement Interface, then it will generate the CompareTo method for you, but in VSCode we don't have this feature, so we need to implement the CompareTo method manually.
        public int CompareTo(Student other)
        {
            //throw new NotImplementedException();
            //below is the mplementation
            if(this.Sid > other.Sid) //here other means the current object which is being compared with the other object, so if the current object's Sid is greater than the other object's Sid, then it will return 1, which means the current object is greater than the other object, so it will be placed after the other object in the sorted order
                return 1;  //if you want the sorting should be performed in the descending order, simply change the return value from 1 to -1
            else if(this.Sid < other.Sid)
                return -1; //if you want the sorting should be performed in the descending order, simply change the return value from -1 to 1
            else
                return 0;
        }

    }

    class CompareStudents : IComparer<Student>
    {
        //same what we did in ICOmparable interface that quick action and refactoring same do it here
        public int Compare(Student x, Student y)
        {
            //throw new NotImplementedExcpetion();
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
        public static void Main()
        {
            Student s1 = new Student { Sid = 1003, Name = "John Doe", Class = 10, Marks = 85.5f };
            Student s2 = new Student { Sid = 1006, Name = "Jane Smith", Class = 10, Marks = 90.0f };
            Student s3 = new Student { Sid = 1004, Name = "Bob Johnson", Class = 10, Marks = 80.0f };   
            Student s4 = new Student { Sid = 1002, Name = "Alice Williams", Class = 10, Marks = 95.0f };
            Student s5 = new Student { Sid = 1001, Name = "Tom Brown", Class = 10, Marks = 75.0f };
            Student s6 = new Student { Sid = 1005, Name = "Emily Davis", Class = 10, Marks = 88.0f };

            List<Student> students = new List<Student>() { s1, s2, s3, s4, s5, s6 }; //collection initializers
            
            //after implementing CompareTo method, now you can use the Sort() method to sort the objects based on the Sid property, and it will work without throwing any exception, because now the compiler knows how to compare the objects of the Student class based on the Sid property, so it can perform the sorting operation based on the Sid property.
            students.Sort();

            //if you don't want to change the logic of the CompareTo method, which is used to sort the objects in the ascending order based on the Sid property, but you want to sort the objects in the descending order based on the Sid property, then you can simply reverse the sorted order using the Reverse() method of the List collection, because the Sort() method will sort the objects in the ascending order by default, so if you want to sort the objects in the descending order, you can simply reverse the sorted order using the Reverse() method.
            students.Reverse(); //if you want to sort the objects in the descending order, you can use the Reverse() method after sorting the objects in the ascending order, because the Sort() method will sort the objects in the ascending order by default, so if you want to sort the objects in the descending order, you can simply reverse the sorted order using the Reverse() method.
            foreach(Student obj in students)
                Console.WriteLine(obj.Sid + " " + obj.Name + " " + obj.Class + " " + obj.Marks);

            Console.WriteLine();
            //define a object for new class
            CompareStudents cs = new CompareStudents();
            //one of Sort method's overload takes IComparer interface as a parameter, so we can pass the object of the CompareStudents class to the Sort method, and it will sort the objects based on the logic defined in the Compare method of the CompareStudents class, which is based on the Marks property, so it will sort the objects in the ascending order based on the Marks property.
            students.Sort(cs); 
            foreach(Student obj in students)
                Console.WriteLine(obj.Sid + " " + obj.Name + " " + obj.Class + " " + obj.Marks);
        }
    } 
}