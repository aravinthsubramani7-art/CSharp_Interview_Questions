namespace DependencyInjectionProject.Services
{
    public class FoodService : IFoodService
    {
        private readonly Guid _id;
        public FoodService()
        {
            _id = Guid.NewGuid();
        }
        public Guid GiveFood()
        {
            return _id;
        }

        //the purpose of generating the new guid in the constructor is i have register this FoodService in the program.cs file with AddSingleton method
        //whenever you are creating the instance of the class the constructor is called and newguid is generated
        //because this is singleton design pattern we will have only one instance throughout the application irresptive of the request, means how many times i want to hit this class we will have reuse the instance so you will get the same guid everytime
    }
}