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
            //CarManager carManager1 = new CarManager(new EfCarDal());
            //foreach (var manager in carManager1.GetCarsDailyPrice())
            //{
            //    Console.WriteLine(manager.Description);
            //}

            Car car = new Car();
            car.CarId = 1;
            car.CarName = "Test";
            car.BrandId = 1;
            car.ColorId = 1;
            car.ModelYear = "1999";
            car.DailyPrice = 500;
            car.Description = "Test model";


            ReCapContext reCapContext = new ReCapContext();

            reCapContext.Cars.Add(car);
           
            var result = from i in reCapContext.Cars
                         select i;

            foreach (var item in result)
            {
                Console.WriteLine(item.CarName);
            }


            //carManager1.Add(car);
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var manager in carManager1.GetAll())
            //{
            //    Console.WriteLine(manager.Description);
            //}

            //ReCapContext reCapContext = new ReCapContext();
            //reCapContext.Cars.Add(car);
            //foreach (var manager in carManager.GetAll())
            //{

            //}

          



        }
    }
}