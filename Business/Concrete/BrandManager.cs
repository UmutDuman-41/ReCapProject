using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult <Brand> GetById(int id)
        {
            IResult result = BusinessRules.Run(CheckBrandExist(id));
            if (result.Success)
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
            }
            return new ErrorDataResult<Brand>();
            
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckBrandNameExist(brand.BrandName));
            if (result.Success)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult();
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckBrandExist(int BrandId)
        {
            var result = _brandDal.GetAll(b => b.BrandId == BrandId).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Marka Bulunamadı.");
        }

        private IResult CheckBrandNameExist(string BrandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == BrandName).Any();
            if (!result)
            {
                return new ErrorResult("Aynı Mara Mevcuttur.");
            }
            return new SuccessResult();
        }
    }
}
