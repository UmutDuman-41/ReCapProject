using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarServise
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Başarıyla eklendi.");
            }
            else if(car.CarName.Length <= 2)
            {
                Console.WriteLine("Araba ismi 2 karakterden fazla olmalıdır.");
            }
            else if (car.DailyPrice<=0)
            {
                Console.WriteLine("Günlük ücret 0'dan büyük olmalıdır.");
            }
            else { Console.WriteLine("Araba ismi 2 karakterden büyük ve günlük ücreti 0'dan büyük olmalıdır."); }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetCarsDailyPrice()
        {
            return _carDal.GetAll(p=> p.DailyPrice>0);
        }

        public List<Car> GetCarsNameLength()
        {
            return _carDal.GetAll(P => P.Description.Length > 2);
        }
    }
}
