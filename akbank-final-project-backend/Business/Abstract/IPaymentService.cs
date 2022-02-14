using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> Get(int id);
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);

        IResult MultipleAdd(MultipleAddDto multipleAdd);
    }
}
