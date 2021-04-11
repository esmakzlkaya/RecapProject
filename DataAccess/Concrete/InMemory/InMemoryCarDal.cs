using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=2,ModelYear=2015,DailyPrice=170,Description="RENAULT FLUENCE 2015 Dizel" },
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2015,DailyPrice=250,Description="AUDI A3 2013 Dizel Otomatik"},
                new Car{Id=3,BrandId=3,ColorId=1,ModelYear=2013,DailyPrice=200,Description="VOLKSWAGEN JETTA 2013 Dizel Otomatik"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public CarDetailDto GetCarDetailByIdSingle(int carId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);

            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        List<CarDetailDto> ICarDal.GetCarDetailById(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
