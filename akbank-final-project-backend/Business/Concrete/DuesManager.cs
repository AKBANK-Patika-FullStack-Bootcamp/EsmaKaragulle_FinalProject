using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class DuesManager : IDuesService
    {
        IDuesDal _duesDal;
        public DuesManager(IDuesDal duesDal)
        {
            _duesDal = duesDal;
        }

        [ValidationAspect(typeof(DuesValidator))]
        public IResult Add(Dues dues)
        {
           
            _duesDal.Add(dues);
            return new SuccessResult(Messages.DuesAdded);
        }

        public IResult Delete(Dues dues)
        {
        
            _duesDal.Delete(dues);
            return new SuccessResult(Messages.DuesDeleted);
        }

        public IDataResult<Dues> Get(int id)
        {
            return new SuccessDataResult<Dues>(_duesDal.Get(d => d.Id == id));
        }

        public IDataResult<List<Dues>> GetAll()
        {
            return new SuccessDataResult<List<Dues>>(_duesDal.GetAll(), Messages.DuesListed);
        }

        public IResult Update(Dues dues)
        {
            _duesDal.Update(dues);
            return new SuccessResult(Messages.DuesUpdated);
        }
    }
}
