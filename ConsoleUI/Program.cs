using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach(var manager in carManager.GetAll())
            //{
            //    Console.WriteLine(manager.Description);
            //}

            CarManager carManager1 = new CarManager(new EfCarDal());
            //foreach (var manager in carManager1.GetCarsDailyPrice())
            //{
            //    Console.WriteLine(manager.Description);
            //}

            Car car = new Car();
            car.CarId = 1;
            car.CarName= "Test";
            car.BrandId = 1;
            car.ColorId = 1;
            car.ModelYear = "1999";
            car.DailyPrice = 500;
            car.Description = "Test model";

            carManager1.Add(car);


        }
    }
}