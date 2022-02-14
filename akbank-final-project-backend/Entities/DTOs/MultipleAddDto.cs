using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MultipleAddDto : IDto
    {
        public string BlockNo { get; set; }
        public decimal PaymentAmount { get; set; }
        public int InvoiceId{ get; set; }

    }
}
