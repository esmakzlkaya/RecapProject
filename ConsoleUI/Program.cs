using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            // userManager.Add(new User { FirstName="Fix  ", LastName="Oto", Email="fixoto@gmail.com", Password="11fix"});
            //  customerManager.Add(new Customer { UserId = 1, CompanyName = "Fix Oto" });

            // AddUser(userManager);
            // AddCustomer(customerManager);
             //AddRental(rentalManager);
           // GetAllRentalDetails(rentalManager);

            // Console.WriteLine("\n-----------Car-----------\n");
            // GetAllCars(carManager);
            // GetCarById(carManager);
            // GetAllCarDetails(carManager);

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
        //private static void GetAllRentalDetails(RentalManager rentalManager)
        //{
        //    var result = rentalManager.GetAllRentalDetails();

        //    foreach (var rental in result.Data)
        //    {
        //        Console.WriteLine(rental.Id + " - " + rental.CarId + " - " + rental.CarName + " - " + rental.CustomerName + " - " + rental.DailyPrice + " - " + rental.RentDate + " - " + rental.ReturnDate + "\n");
        //    }
        //    Console.WriteLine(result.Message);
        //}
        
        private static void AddCustomer(CustomerManager customerManager)
        {
            var result = customerManager.Add(new Customer
            {
                Id = 2,
                UserId = 2,
                CompanyName = "Çetinkaya Rent A Car"
            });

            Console.WriteLine(result.Message);
        }
        //private static void AddRental(RentalManager rentalManager)
        //{
        //    var result = rentalManager.Add(new Rental
        //    {
        //        Id = 18,
        //        CarId = 1,
        //        CustomerId = 2,
        //        RentDate = DateTime.Now,
        //        ReturnDate=null
        //    });

        //    Console.WriteLine(result.Message);
        //}
        private static void GetAllCarDetails(CarManager carManager)
        {
            var result = carManager.GetAllCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice + "\n");
            }
            Console.WriteLine(result.Message);
        }

        private static void AddBrand(BrandManager brandManager)
        {
            brandManager.Add(new Brand
            {
                Id = 4,
                Name = "Toyota"
            });
            Console.WriteLine("\n New Brand Added----------------\n");
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine(result.Message);
        }
        private static void UpdateBrand(BrandManager brandManager)
        {
            brandManager.Update(new Brand { Id = 4, Name = "Ford" });

            Console.WriteLine("\n Brand Updated----------------\n");
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine(result.Message);
        }
        private static void DeleteBrand(BrandManager brandManager)
        {
            brandManager.Delete(new Brand { Id = 4 });

            Console.WriteLine("\n Brand Deleted----------------\n");
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine(result.Message);
        }
        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car
            {
                Id = 9,
                BrandId = 3,
                ColorId = 1,
                ModelYear = 2016,
                DailyPrice = 0,
                Description = "Hatalı Ekleme Deneme"
            });
            Console.WriteLine("\n New Car Added----------------\n");
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine(result.Message);
        }
        private static void UpdateCar(CarManager carManager)
        {
            carManager.Update(new Car { Id = 9, DailyPrice = 550, Description = "ZAMLANDI" });

            Console.WriteLine("\n Car Updated----------------\n");
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine(result.Message);
        }
        private static void DeleteCar(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 9 });

            Console.WriteLine("\n Car Deleted----------------\n");
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine(result.Message);
        }
        private static void AddColor(ColorManager colorManager)
        {
            colorManager.Add(new Color
            {
                Id = 3,
                Name = "Yellow"
            });
            Console.WriteLine("\n New Color Added----------------\n");
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine(result.Message);
        }
        private static void UpdateColor(ColorManager colorManager)
        {
            colorManager.Update(new Color { Id = 3, Name = "Sarı" });

            Console.WriteLine("\n Color Updated----------------\n");
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine(result.Message);
        }
        private static void DeleteColor(ColorManager colorManager)
        {
            colorManager.Delete(new Color { Id = 3 });

            Console.WriteLine("\n Color Deleted----------------\n");
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine(result.Message);
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            Console.WriteLine("\nGetCarsByBrandId----------------\n");
            var result = carManager.GetCarsByBrandId(2);
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Description);
            }
            Console.WriteLine(result.Message);
        }

        private static void GetAllBrands(BrandManager brandManager)
        {
            Console.WriteLine("\nGetAllBrands----------------\n");
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine(result.Message);
        }
        private static void GetBrandById(BrandManager brandManager)
        {
            var result = brandManager.GetById(2);
            Console.WriteLine("\nGetById----------------\n");
            Console.WriteLine(result.Data.Name);
            Console.WriteLine(result.Message);
        }

        /////////////////////////////////////////////

        private static void GetAllCars(CarManager carManager)
        {
            Console.WriteLine("\nGetAllCars----------------\n");
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine(result.Message);
        }
        private static void GetCarById(CarManager carManager)
        {
            var result = carManager.GetById(2);
            Console.WriteLine("\nGetById----------------\n");
            Console.WriteLine(result.Data.Description);
            Console.WriteLine(result.Message);
        }

        /////////////////////////////////////////////

        private static void GetCarsByColorId(CarManager carManager)
        {
            Console.WriteLine("\nGetCarsByColorId----------------\n");
            var result = carManager.GetCarsByColorId(1);
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Description);
            }
            Console.WriteLine(result.Message);
        }

        private static void GetAllColors(ColorManager colorManager)
        {
            Console.WriteLine("\nGetAllColors----------------\n");
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine(result.Message);
        }
        private static void GetColorById(ColorManager colorManager)
        {
            var result = colorManager.GetById(2);
            Console.WriteLine("\nGetById----------------\n");
            Console.WriteLine(result.Data.Name);
            Console.WriteLine(result.Message);
        }

    }
}
