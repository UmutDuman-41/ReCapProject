using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        [PerformanceAspect(15)]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExist(car.CarName),CheckIfBrandIdCountControl(car.BrandId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin,Car.Delete")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }


        [SecuredOperation("admin,Car.Update")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }



        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


        [CacheAspect]
        [PerformanceAspect(5)]
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


        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.Error);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandIdCountControl(int BrandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == BrandId).Count;
            if (result > 2)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }



        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 15)
            {
                throw new Exception(""); 
            }

            Add(car);

            return null;
        }
    }
}
