using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{CarId = 1,BrandId = 1,ColorId = 1,ModelYear="2000",DailyPrice=1000,Description="AUDI Kaskolu Araba"},
            new Car{CarId = 2,BrandId = 1,ColorId = 1,ModelYear="2010",DailyPrice=1000,Description="AUDI Kaskolu Araba"},
            new Car{CarId = 3,BrandId = 1,ColorId = 2,ModelYear="2005",DailyPrice=8000,Description="AUDI Sigortalı Araba"},
            new Car{CarId = 4,BrandId = 2,ColorId = 3,ModelYear="2020",DailyPrice=1200,Description="Mercedes Kaskolu Araba"},
            new Car{CarId = 5,BrandId = 2,ColorId = 4,ModelYear="2023",DailyPrice=1300,Description="Mercedes Kaskolu Araba"},
            new Car{CarId = 6,BrandId = 3,ColorId = 5,ModelYear="2022",DailyPrice=1400,Description="BMW Kaskolu Araba"}
            
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int ID)
        {
            return _cars.Where(p => p.CarId == ID).ToList();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(p=> p.CarId == car.CarId);
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
        }
    }
}
