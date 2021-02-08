using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
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

            //  Console.WriteLine("\n-----------Car-----------\n");
            //  GetAllCars(carManager);
            //  GetCarById(carManager);

            foreach (var car in carManager.GetAllCarDetails())
            {
                Console.WriteLine(car.CarName+" - "+ car.BrandName + " - "+ car.ColorName + " - " + car.DailyPrice+"\n");
            }
            



          // /* AddCar(carManager);
          //  UpdateCar(carManager);
          //  DeleteCar(carManager);*/

          //  Console.WriteLine("\n******************************\n");

          //  Console.WriteLine("\n----------Color---------\n");
          //  GetAllColors(colorManager);
          //  GetCarsByColorId(carManager);
          //  GetColorById(colorManager);
          // /* AddColor(colorManager);
          //  UpdateColor(colorManager);
          //  DeleteColor(colorManager);*/

          //  Console.WriteLine("\n******************************\n");

          //  Console.WriteLine("\n----------Brand---------\n");
          //  GetAllBrands(brandManager);
          //  GetCarsByBrandId(carManager);
          //  GetBrandById(brandManager);
          ///*  AddBrand(brandManager);
          //  UpdateBrand(brandManager);
          //  DeleteBrand(brandManager);*/
        }
        private static void AddBrand(BrandManager brandManager)
        {
            brandManager.Add(new Brand
            {
                Id=4,
                Name = "Toyota"
            });
            Console.WriteLine("\n New Brand Added----------------\n");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
        private static void UpdateBrand(BrandManager brandManager)
        {
            brandManager.Update(new Brand {Id=4,Name = "Ford" });

            Console.WriteLine("\n Brand Updated----------------\n");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
        private static void DeleteBrand(BrandManager brandManager)
        {
            brandManager.Delete(new Brand { Id = 4 });

            Console.WriteLine("\n Brand Deleted----------------\n");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car
            {
                Id=9,
                BrandId = 3,
                ColorId = 1,
                ModelYear = 2016,
                DailyPrice = 0,
                Description = "Hatalı Ekleme Deneme"
            });
            Console.WriteLine("\n New Car Added----------------\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void UpdateCar(CarManager carManager)
        {
            carManager.Update(new Car { Id = 9, DailyPrice = 550, Description = "ZAMLANDI" });

            Console.WriteLine("\n Car Updated----------------\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void DeleteCar(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 9 });

            Console.WriteLine("\n Car Deleted----------------\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void AddColor(ColorManager colorManager)
        {
            colorManager.Add(new Color
            {
                Id=3,
                Name="Yellow" 
            });
            Console.WriteLine("\n New Color Added----------------\n");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void UpdateColor(ColorManager colorManager)
        {
            colorManager.Update(new Color {Id=3, Name = "Sarı" });

            Console.WriteLine("\n Color Updated----------------\n");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void DeleteColor(ColorManager colorManager)
        {
            colorManager.Delete(new Color { Id = 3 });

            Console.WriteLine("\n Color Deleted----------------\n");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            Console.WriteLine("\nGetCarsByBrandId----------------\n");
            foreach (var color in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(color.Description);
            }
        }

        private static void GetAllBrands(BrandManager brandManager)
        {
            Console.WriteLine("\nGetAllBrands----------------\n");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
        private static void GetBrandById(BrandManager brandManager)
        {
            Console.WriteLine("\nGetById----------------\n");
            Console.WriteLine(brandManager.GetById(2).Name);
        }

        /////////////////////////////////////////////

        private static void GetAllCars(CarManager carManager)
        {
            Console.WriteLine("\nGetAllCars----------------\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void GetCarById(CarManager carManager)
        {
            Console.WriteLine("\nGetById----------------\n");
            Console.WriteLine(carManager.GetById(2).Description);
        }

        /////////////////////////////////////////////

        private static void GetCarsByColorId(CarManager carManager)
        {
            Console.WriteLine("\nGetCarsByColorId----------------\n");
            foreach (var color in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(color.Description);
            }
        }

        private static void GetAllColors(ColorManager colorManager)
        {
            Console.WriteLine("\nGetAllColors----------------\n");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void GetColorById(ColorManager colorManager)
        {
            Console.WriteLine("\nGetById----------------\n");
            Console.WriteLine(colorManager.GetById(2).Name);
        }

    }
}
