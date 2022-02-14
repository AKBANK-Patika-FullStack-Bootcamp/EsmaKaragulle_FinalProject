using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        IMailDal _mailDal;

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public IResult Add(Mail mail)
        {
            mail.SendDate = DateTime.Now;
            mail.OpenDate = DateTime.Now;
            mail.IsNew = true;
            _mailDal.Add(mail);
            return new SuccessResult(Messages.MailSend);
        }

        public IResult Delete(Mail mail)
        {
            mail.IsDelete = true;
            _mailDal.Update(mail);

            return new SuccessResult(Messages.MailDelete);
        }

        public IDataResult<Mail> Get(string mail)
        {
            return new SuccessDataResult<Mail>(_mailDal.Get(m => m.ToMail == mail));
        }

        public IDataResult<List<Mail>> GetAll()
        {
            return new SuccessDataResult<List<Mail>>(_mailDal.GetAll(), Messages.MailList);
        }

        public IDataResult<List<Mail>> InboxGetAll(string mail)
        {

            return new SuccessDataResult<List<Mail>>(_mailDal.GetAll(m=>m.ToMail==mail), Messages.MailList);
        }

        public IDataResult<List<Mail>> SendGetAll(string mail)
        {
            return new SuccessDataResult<List<Mail>>(_mailDal.GetAll(m => m.FromMail == mail), Messages.MailList);
        }

        public IResult Update(Mail mail)
        {
            mail.IsNew = false;
            mail.IsRead = true;
            _mailDal.Update(mail);

            return new SuccessResult(Messages.MailUpdate);
        }
    }
}
