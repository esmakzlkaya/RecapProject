using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFindeksDal : EfEntityRepositoryBase<Findeks, RentACar_ReCapContext>, IFindeksDal
    {
        public Findeks GetFindeksByUserId(int userId)
        {
            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                var result = from f in context.FindeksScores
                             join u in context.Users
                             on f.UserId equals u.Id
                             select new Findeks
                             {
                                  Id=f.Id,
                                   UserId=f.UserId,
                                    NationalityId=f.NationalityId,
                                     Score=f.Score
                             };
                return result.FirstOrDefault(f=>f.UserId==userId);

            }
        }

    }
}
