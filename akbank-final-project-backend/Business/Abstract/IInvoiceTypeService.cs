using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IInvoiceTypeService
    {
        IDataResult<List<InvoiceType>> GetAll();
        IDataResult<InvoiceType> Get(int id);
        IResult Add(InvoiceType invoiceType);
        IResult Update(InvoiceType invoiceType);
        IResult Delete(InvoiceType invoiceType);
    }
}
