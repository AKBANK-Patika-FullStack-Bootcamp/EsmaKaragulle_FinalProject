using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int ApartmentId { get; set; }
        public int InvoiceId { get; set; }
        public int Amount { get; set; }
        public bool SuccessPayment { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime DueDate { get; set; }
       


    }
}
