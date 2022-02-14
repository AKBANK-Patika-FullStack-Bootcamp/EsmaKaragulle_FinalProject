using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string CardNumber { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PayDate { get; set; }
    }
}
