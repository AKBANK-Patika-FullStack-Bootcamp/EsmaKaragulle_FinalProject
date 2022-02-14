using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class ApartmentManager : IApartmentService
    {
        IApartmentDal _apartmentDal;

        public ApartmentManager(IApartmentDal apartmentDal)
        {
            _apartmentDal = apartmentDal;
        }

        public IDataResult<int> ActiveApartmentCount()
        {
            var result = _apartmentDal.GetAll((a => a.IsActive == true)).Count();
            if (result > 0)
            {

                return new SuccessDataResult<int>(result, Messages.ApartmentListed);
            }

            return new ErrorDataResult<int>(result, Messages.ActiveApartmentNotFound);
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IApartmentService.Get")]
     //   [ValidationAspect(typeof(ApartmentValidator))]
        public IResult Add(Apartment apartment)
        {
          
            apartment.IsDeleted = false;
            _apartmentDal.Add(apartment);
            return new SuccessResult(Messages.ApartmentAdded);
        }

        public IDataResult<int> BlankApartmentCount()
        {
            var result = _apartmentDal.GetAll((a => a.IsBlank == true)).Count();
            if (result > 0)
            {

                return new SuccessDataResult<int>(result, Messages.ApartmentListed);
            }

            return new ErrorDataResult<int>(result, Messages.BlankApartmentNotFound);
        }

        [CacheRemoveAspect("IApartmentService.Get")]
        public IResult Delete(Apartment apartment)
        {
            _apartmentDal.Delete(apartment);
            return new SuccessResult(Messages.ApartmentDeleted);
        }

        [CacheAspect]
        public IDataResult<Apartment> Get(int id)
        {
            return new SuccessDataResult<Apartment>(_apartmentDal.Get(a => a.ApartmentId == id));
        }

        //[CacheAspect]
        [CacheRemoveAspect("IAparmentService.GetAll")]
        public IDataResult<List<ApartmentDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<ApartmentDetailDto>>(_apartmentDal.GetApartmentDetails(), Messages.ApartmentListed);
        }

        public IDataResult<List<Apartment>> GetAllByActive()
        {
            var result = _apartmentDal.GetAll().FindAll(a => a.IsActive == true);
            if (result.Any())
            {

                return new SuccessDataResult<List<Apartment>>(result, Messages.ApartmentListed);
            }

            return new ErrorDataResult<List<Apartment>>(result, Messages.ActiveApartmentNotFound);
        }

        public IDataResult<List<Apartment>> GetAllByBlank()
        {
            var result = _apartmentDal.GetAll(a => a.IsBlank == true);
            if (result.Any())
            {

                return new SuccessDataResult<List<Apartment>>(result, Messages.ApartmentListed);
            }

            return new ErrorDataResult<List<Apartment>>(result, Messages.BlankApartmentNotFound);
        }

        public IDataResult<List<Apartment>> GetAllByBlankAndActive()
        {
            var result = _apartmentDal.GetAll(a => a.IsBlank == true && a.IsActive == true);
            if (result.Any())
            {

                return new SuccessDataResult<List<Apartment>>(result, Messages.ApartmentListed);
            }

            return new ErrorDataResult<List<Apartment>>(result, Messages.BlankAndActiveApartmentNotFound);
        }

        public IDataResult<List<Apartment>> GetAllByBlockName(string blockNo)
        {
            return new SuccessDataResult<List<Apartment>>(_apartmentDal.GetAll(a=>a.BlockNo==blockNo), Messages.ApartmentListed);
        }

        public IResult Update(Apartment apartment)
        {
            var result = _apartmentDal.Get(a => a.ApartmentId == apartment.ApartmentId);

            _apartmentDal.Update(apartment);
            return new SuccessResult(Messages.ApartmentUpdated);
        }
    }
}
