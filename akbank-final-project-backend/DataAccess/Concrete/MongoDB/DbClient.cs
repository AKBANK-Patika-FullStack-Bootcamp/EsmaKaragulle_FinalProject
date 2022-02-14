using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MongoDB
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<CreditCard> _creditCards;
        public DbClient(IOptions<CreditCardStoreDbConfig> creditCartDbConfig)
        {
            var client = new MongoClient(creditCartDbConfig.Value.Connection_String);
            var database = client.GetDatabase(creditCartDbConfig.Value.Database_Name);
            _creditCards = database.GetCollection<CreditCard>(creditCartDbConfig.Value.CreditCard_Collection_Name);
        }
        public IMongoCollection<CreditCard> GetCreditCardCollection() => _creditCards;
    }
}
