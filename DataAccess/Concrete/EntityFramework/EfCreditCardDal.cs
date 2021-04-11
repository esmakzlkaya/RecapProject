using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, RentACar_ReCapContext>, ICreditCardDal
    {
        public List<CreditCard> GetAllCreditCards()
        {
            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                var result = from c in context.CreditCards
                             join p in context.Payments
                             on c.CreditCardNo equals p.CreditCardNo
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CreditCard
                             {
                              Id=c.Id,
                               UserId=u.Id,
                                NameSurname=u.FirstName+u.LastName,
                             CreditCardNo=c.CreditCardNo,
                              ExpirationMonth=p.ExpirationDate.Month,
                              ExpirationYear=p.ExpirationDate.Year,
                               CardType=c.CardType,
                                Cvv=c.Cvv
                             };
                return result.ToList();

            }
        }
    }
}
