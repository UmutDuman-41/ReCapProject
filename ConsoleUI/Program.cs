using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Car car = new Car();
            //car.CarId = 1;
            //car.CarName = "Test";
            //car.BrandId = 1;
            //car.ColorId = 1;
            //car.ModelYear = "1999";
            //car.DailyPrice = 500;
            //car.Description = "Test model";

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(car);
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.CarName);
            //}

            //Color color = new Color();
            //color.ColorName = "Black";
            //color.ColorId = 1;

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Insert(color);
            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine(item.ColorName);
            //}

            //Brand brand = new Brand();
            //brand.BrandId = 1;
            //brand.BrandName = "VOLVO";

            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Insert(brand);
            //foreach (var item in brandManager.GetAll())
            //{
            //    Console.WriteLine(item.BrandName);
            //}
             //brandManager.Delete(brand);

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/"+ car.ColorName + "/" + car.BrandName);
            }






    



        }

    }
}