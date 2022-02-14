using Entities.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IDbClient
    {
        IMongoCollection<CreditCard> GetCreditCardCollection();
    }
}
