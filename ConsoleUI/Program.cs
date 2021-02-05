using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using Entities.Abstract;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("\nGetAllCars----------------\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nGetById----------------\n");
            Console.WriteLine(carManager.GetById(2).Description);

            Console.WriteLine("\n--------------------------\n");

            Console.WriteLine("\nGetAllColors----------------\n");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine("\nGetCarsByColorId----------------\n");
            foreach (var color in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(color.Description);
            }

            Console.WriteLine("\n--------------------------\n");

            Console.WriteLine("\nGetAllBrands----------------\n");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("\nGetCarsByBrandId----------------\n");
            foreach (var color in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(color.Description);
            }

            Console.WriteLine("\n New Car Added----------------\n");
            carManager.Add(new Car 
            { 
                BrandId=3,
                ColorId=1,
                ModelYear=2016,
                DailyPrice=0,
                Description= "y"
            });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            /*   carManager.Add(new Car { Id=4,BrandId=2,ColorId=2,ModelYear=2018,DailyPrice=300,Description="AUDI A2 DİZEL"});

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



               Console.WriteLine("GETBYID -------------------");

                   Console.WriteLine((carManager.GetById(2)).Description);

               */
        }
    }
}
