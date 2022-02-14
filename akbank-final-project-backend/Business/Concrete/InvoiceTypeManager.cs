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
    public class InvoiceTypeManager : IInvoiceTypeService
    {
        IInvoiceTypeDal _invoiceTypeDal;

        public InvoiceTypeManager(IInvoiceTypeDal invoiceTypeDal)
        {
            _invoiceTypeDal = invoiceTypeDal;

        }
        [ValidationAspect(typeof(InvoiceTypeValidator))]
        public IResult Add(InvoiceType invoiceType)
        {
           
            _invoiceTypeDal.Add(invoiceType);
            return new SuccessResult(Messages.InvoiceTypeAdded);
        }

        public IResult Delete(InvoiceType invoiceType)
        {
           
            _invoiceTypeDal.Delete(invoiceType);
            return new SuccessResult(Messages.InvoiceTypeDeleted);
        }

        public IDataResult<InvoiceType> Get(int id)
        {
            return new SuccessDataResult<InvoiceType>(_invoiceTypeDal.Get(i => i.InvoiceTypeId == id));
        }

        public IDataResult<List<InvoiceType>> GetAll()
        {
            return new SuccessDataResult<List<InvoiceType>>(_invoiceTypeDal.GetAll(), Messages.InvoiceTypeListed);
        }

        public IResult Update(InvoiceType invoiceType)
        {
        
            _invoiceTypeDal.Update(invoiceType);
            return new SuccessResult(Messages.InvoiceTypeUpdated);
        }
    }
}
