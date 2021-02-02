using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using Entities.Abstract;
using System;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Add(new Car { Id=4,BrandId=2,ColorId=2,ModelYear=2018,DailyPrice=300,Description="AUDI A2 DİZEL"});

            Console.WriteLine("ADD -------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Update(new Car { Id = 1, DailyPrice = 500, Description = "ZAMLANDI" });

            Console.WriteLine("UPDATE -------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Delete(new Car { Id=4});

            Console.WriteLine("DELETE -------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
