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
   public interface IApartmentService
    {
        IDataResult<List<ApartmentDetailDto>> GetAll();

        IDataResult<List<Apartment>> GetAllByBlockName(string blockNo);
        IDataResult<Apartment> Get(int id);
        IResult Add(Apartment apartment);
        IResult Update(Apartment apartment);
        IResult Delete(Apartment apartment);
        
        IDataResult<List<Apartment>> GetAllByBlank();
        IDataResult<List<Apartment>> GetAllByActive();
        IDataResult<List<Apartment>> GetAllByBlankAndActive();

        IDataResult<int> BlankApartmentCount();
        IDataResult<int> ActiveApartmentCount();

      



    }
}
