// namespace CollectionProject
// {
//     public class Employee
//     {
//         public int Id {get; set;}
//         public string Name {get; set;}
//         public string Job {get; set;}
//         public double Salary {get; set;}
//     }

//     public class TestEmployee
//     {
//         public static void Main()
//         {
//             List<Employee> employees = new List<Employee>();
//             employees.Add(new Employee { Id = 1001, Name = "John Doe", Job = "Software Engineer", Salary = 50000 });
//             employees.Add(new Employee { Id = 1002, Name = "Jane Smith", Job = "Project Manager", Salary = 70000 });
//             employees.Add(new Employee { Id = 1003, Name = "Bob Johnson", Job = "QA Engineer", Salary = 40000 });
//             employees.Add(new Employee { Id = 1004, Name = "Alice Williams", Job = "Business Analyst", Salary = 60000 }); 
//             employees.Add(new Employee { Id = 1005, Name = "Tom Brown", Job = "DevOps Engineer", Salary = 55000 });

//             foreach(Employee emp in employees)
//                 Console.WriteLine(emp.Id + " " + emp.Name + " " + emp.Job + " " + emp.Salary);

//             Console.ReadLine();
//         }
//     }
// }

//---------------------Proving the foreach loop is working because of IEnumerable interface(GetEnumerator())-------------------------------------------------

using System.Collections;
namespace CollectionProject
{
    public class Employee
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Job {get; set;}
        public double Salary {get; set;}
    }

    // public class Organization
    // {
    //     List<Employee> emps = new List<Employee>();
    //     public void Add(Employee emp)
    //     {
    //         emps.Add(emp);
    //     }
    // }

    //------------------------------------solution for the error - foreach statement cannot operate on variables of type 'Organization' because 'Organization' does not contain a public instance or extension definition for 'GetEnumerator'------------------------------
    public class Organization : IEnumerable
    {
        List<Employee> emps = new List<Employee>();
        public void Add(Employee emp)
        {
            emps.Add(emp);
        }

        //we are adding the count property to know the no of items in the collection, because we need to use this count property in the MoveNext() method of the OrganizationEnumerator class to check if there is a next element in the collection or not.
        public int Count
        {
            get
            {
                return emps.Count;
            }
        }

        //we are adding the indexer to access the elements of the collection using the index, because we need to use this indexer in the MoveNext() method of the OrganizationEnumerator class to access the current element of the collection.
        public Employee this[int index]
        {
            get
            {
                return emps[index];
            }
        }

        //right click on IEnumerable and click on quick actions and refactorings and click on implement inerface - if you are using VS, but it is VS code we have to mannually create it
        public IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException(); //only with this if you run the program, the foreach still won't work
            //return emps.GetEnumerator(); //you don't want to go with this simple, watch the below implementation
            //when you want to return IEnumerator interface as return type, we can never create an instance of an interface, first define a class and that class should implement IEnumerator and that class should used as a return type

            //after you ceated OrganizationEnumerator which is in below, return that.
            return new OrganizationEnumerator(this); //this represents the current class which is Organization class.
        }
    }

    //i am implementing my own IEnumerator interface
    public class OrganizationEnumerator : IEnumerator
    {
        //right click on IEnumerator and click on quick actions and refactorings and click on implement inerface - if you are using VS, but it is VS code we have to mannually create it
        
        Organization OrgColl; //we need the Organization collection here 
        int CurrentIndex;
        Employee CurrentEmployee;
        //constructor
        public OrganizationEnumerator(Organization org)
        {
            OrgColl = org;
            CurrentIndex = -1; //initially the pointer is before the first element of the collection
        }

        public object Current
        {
            get
            {
                //throw new NotImplementedException();
                return CurrentEmployee;
            }
        }

        public bool MoveNext()
        {
            //throw new NotImplementedException();
            if(++CurrentIndex >= OrgColl.Count) //we have a count property to know the no of items in the collection, Organisation class doesn't contain any count property, so implement the count property in the Organization class
                return false;
            else
                CurrentEmployee = OrgColl[CurrentIndex]; //this will throw an error - Cannot apply indexing with [] to an expression of type 'Organization', because Organization is not an array or a list, so we need to implement the indexer in the Organization class to access the elements of the collection using the index.
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    //explanation - see you have 6 employee objects in the emps list
    //=>before first - initially the pointer is before the first element of the collection, so it is pointing to a position before emp1
    //emp1 - if you call MoveNext() method it will move the pointer to the next element of the collection and return true if there is a next element, so it will move the pointer to emp1 and return true
    //emp2
    //emp3
    //emp4 
    //emp5
    //emp6 - if you call MoveNext() method it will move the pointer to the after last, so it will return false because there is no next element in the collection
    //after last

    //the Reset method is used to reset the pointer to the initial position, so if you call Reset() method it will move the pointer to the before first position, so it will be pointing to a position before emp1
    //but here we are not going to implement Reset() method because Reseting is not possible in our collection, it was defined for common interoperability but in our collection we don't use this.

    //Current - current is used to access the current element of the collection, so if you call Current property it will return the current element of the collection, so if the pointer is pointing to emp1 then it will return emp1, if the pointer is pointing to emp2 then it will return emp2 and so on.

    //first MoveNext() method will call and then Current property will call, MoveNext() Current MoveNext() Current...

    public class TestEmployee
    {
        public static void Main()
        {
            //List<Employee> employees = new List<Employee>();
            Organization employees = new Organization();
            employees.Add(new Employee { Id = 1001, Name = "John Doe", Job = "Software Engineer", Salary = 50000 });
            employees.Add(new Employee { Id = 1002, Name = "Jane Smith", Job = "Project Manager", Salary = 70000 });
            employees.Add(new Employee { Id = 1003, Name = "Bob Johnson", Job = "QA Engineer", Salary = 40000 });
            employees.Add(new Employee { Id = 1004, Name = "Alice Williams", Job = "Business Analyst", Salary = 60000 }); 
            employees.Add(new Employee { Id = 1005, Name = "Tom Brown", Job = "DevOps Engineer", Salary = 55000 });

            foreach(Employee emp in employees)
                Console.WriteLine(emp.Id + " " + emp.Name + " " + emp.Job + " " + emp.Salary);

            //if you run the program it will throw an error 
            //Error - foreach statement cannot operate on variables of type 'Organization' because 'Organization' does not contain a public instance or extension definition for 'GetEnumerator'
            //for the emps object we can use the foreach loop because it is a List collection which implements the IEnumerable interface, but for the employees object we cannot use the foreach loop because it is a custom class which does not implement the IEnumerable interface, so to make the foreach loop work for the employees object we need to implement the IEnumerable interface in the Organization class and implement the GetEnumerator() method which returns an IEnumerator object which is used by the foreach loop to iterate through the collection.
            //after error throws comment out the Organization class and do write a solution under that class
            Console.ReadLine();
        }
    }
}

//this above implementation is for to prove because of GetEnumerator() method of the IEnumerable interface, the foreach loop is working
//we defined 4 classes - Employee, Organization, OrganizationEnumerator and TestEmployee
//Employee class is a simple class with 4 properties - Id, Name, Job and Salary
//Organization class is a custom collection class which is work like a collection, because we designed it work like a collection, we defined Add() method for adding an item, a Count property to know the no of items in the collection, an indexer to access the elements of the collection using the index and the GetEnumerator() method is for the foreach loop work
//the GetEnumerator() method is returing an IEnumerator, and you defined a class that implementing the IEnumerator interface is OrganizationEnumerator class and we  implemented the property called Current, MoveNext() method
//finally a TestEmployee class we were create an instance of Organization class named it is employees and added 5 employee objects and then used a foreach loop
