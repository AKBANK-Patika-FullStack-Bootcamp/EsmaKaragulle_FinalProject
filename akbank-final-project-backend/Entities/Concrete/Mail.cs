using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Mail:IEntity
    {
        public int MailId { get; set; }
        public string FromMail { get; set; }
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsNew { get; set; }
        public bool IsRead { get; set; }
        public bool IsDelete { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime OpenDate { get; set; }
        
    }
}
