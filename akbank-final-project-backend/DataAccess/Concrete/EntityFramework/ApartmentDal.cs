using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    public class ApartmentDal : EfEntityRepositoryBase<Apartment, ApartmentDBContext>, IApartmentDal
    {
        public List<ApartmentDetailDto> GetApartmentDetails()
        {
            using (ApartmentDBContext context = new ApartmentDBContext())
            {
                var result = from a in context.Apartments
                             join u in context.Users
                             on a.OwnerId equals u.UserId
                             join us in context.Users
                             on a.TenantId equals us.UserId  
                           



                             select new ApartmentDetailDto
                             {
                                 ApartmentId = a.ApartmentId,
                                 OwnerName = $"{u.FirstName} {u.LastName}",
                                 TenantName = $"{us.FirstName} { us.LastName }",
                                 BlockNo = a.BlockNo,
                                 FloorNo = a.FloorNo,
                                 DoorNo = a.DoorNo,
                                 ApartmentType = a.ApartmentType,
                                 IsBlank = a.IsBlank,
                                 IsActive = a.IsActive
                               

                             };
                return result.ToList();
                             
            }
        }
    }
}
