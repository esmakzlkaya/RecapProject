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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                if (entity.Description.Length >= 2 && entity.DailyPrice > 0)
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\nEklenen araba açıklaması en az 2 harften oluşmalıdır. / Araba günlük fiyatı 0 dan büyük olmalıdır.\n");
                }
            }
        }

        public void Delete(Car entity)
        {
            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentACar_ReCapContext context = new RentACar_ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
