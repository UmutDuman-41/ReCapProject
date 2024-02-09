using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
            else if (car.CarName.Length <= 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            else if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.ProductsDailyPrice);
            }
            else { return new ErrorResult(Messages.ProductNameInvalid); }
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsDailyPrice()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice > 0));
        }

        public IDataResult<List<Car>> GetCarsNameLength()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(P => P.Description.Length > 2));
        }
    }
}
