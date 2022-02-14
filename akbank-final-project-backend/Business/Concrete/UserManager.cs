using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {

            IResult result = BusinessRules.Run(CheckIfUserExists(user.IdentityNo));

            if (result!=null)
            {
                return result;
            }
            user.IDate = DateTime.Now;
            user.IsActive = true;
            user.IsDeleted = false;
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);


        }

        public IResult Delete(User user)
        {
            user.UDate = DateTime.Now;
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (email != null && result!=null)
            {

                return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
            }
            return new ErrorDataResult<User>();
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {

            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u => u.UserId == user.UserId);
            user.UDate = DateTime.Now;
            user.IDate = result.IDate;
            user.PasswordHash = result.PasswordHash;
            user.PasswordSalt = result.PasswordSalt;
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        private IResult CheckIfUserExists(string identityNo)
        {
            var result = _userDal.GetAll(u => u.IdentityNo == identityNo).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();

        }

    }


}
