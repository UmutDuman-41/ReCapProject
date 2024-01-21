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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var manager in carManager.GetAll())
            {
                Console.WriteLine(manager.Description);
            }

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var manager1 in carManager1.GetCarsDailyPrice())
            {
                Console.WriteLine(manager1.Description);
            }


        }
    }
}