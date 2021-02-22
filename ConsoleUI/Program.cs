using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAll komutu ile bilgileri getirip GetColorName ve GetBrandName ile car nesnesinden Id'leri alıp color ve brand tablolarında karşılık gelen isimleri çekme
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.Write("==> " +car.ModelYear + " Model ");
            //    Console.Write(carManager.GetColorName(car.ColorId).ColorName + " ");
            //    Console.WriteLine(carManager.GetBrandName(car.CarId).BrandName);
            //    Console.WriteLine("-----------------------------");
            //    Console.WriteLine(" "+car.Description);
            //    Console.WriteLine("                                      ********************************************");
            //}

            ////Id bilgisi ile veri çekme
            //Console.WriteLine(" ");
            //Console.WriteLine("----- Id Verisi İle Bilgi Çekme -----");
            //Console.WriteLine(carManager.GetById(2).Description );

            ////Add komutu deneme 1 - 2
            //Console.WriteLine(" ");
            //Console.WriteLine("----- Add komutu Deneme -----");
            //carManager.Add(new Car { CarId = 5, BrandId = 2, ColorId = 3, DailyPrice = 100200, Description = "GetById Deneme", ModelYear = 2022 });

            //foreach (var products in carManager.GetAll())
            //{
            //    Console.WriteLine(products.CarId + products.Description);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine("{0} --- {1}", car.DailyPrice, car.Description);
            //}



            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}


            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            Console.WriteLine("------DTO Deneme 1 - 2----------");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var color in carManager.GetCarsDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", color.CarId, color.BrandName,color.ColorName,color.DailyPrice);
            }
            Console.WriteLine(carManager.GetById(1).Data.Description);
            //carManager.Update(new Car { CarId = 2, BrandId = 2, ColorId = 2 });

            Console.WriteLine("--------Color Manager Test----------");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " / " + color.ColorName );
            }
            //colorManager.Update(new Color {ColorId = 1002, ColorName = "Fuşya" });

            Console.WriteLine("------Brand Manager Test------");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }
            //brandManager.Delete(new Brand { BrandId = 1002, BrandName = "Tofaş" });

            Console.WriteLine("------User Manager Test------");

            UserManager userManager = new UserManager(new EfUserDal());
            foreach(var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " / " + user.LastName + " / " + user.Email);
            }

            Console.WriteLine("------Customer Manager Test------");

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " / " + customer.UserId + " / " + customer.CompanyName);
            }

            foreach (var customer in customerManager.GetCustomersDetails().Data)
            {
                Console.WriteLine(customer.CustomerId + " / " + customer.UserName + " / " + customer.CompanyName );
            }

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 1 }).Message);
            Console.ReadLine();
        }
    }
}
