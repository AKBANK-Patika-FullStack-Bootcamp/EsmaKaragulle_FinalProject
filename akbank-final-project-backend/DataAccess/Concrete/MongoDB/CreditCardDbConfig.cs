using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MongoDB
{
    public class CreditCardStoreDbConfig
    {
        public string Database_Name { get; set; }
        public string CreditCard_Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
