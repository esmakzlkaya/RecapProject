using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACar_ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            //using (var context = new RentACar_ReCapContext())
            //{
            //    var result = from operationClaim in context.OperationClaims
            //                 join userOperationClaim in context.UserOperationClaims
            //                     on operationClaim.Id equals userOperationClaim.OperationClaimId
            //                 where userOperationClaim.UserId == user.Id
            //                 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            //    return result.ToList();

            //}

            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                var result = from op in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on op.Id equals uoc.OperationClaimId
                             where uoc.UserId==user.Id
                             select new OperationClaim
                             {
                                  Id=op.Id,
                                  Name=op.Name
                             };
                return result.ToList();
            }
        }
    }
