using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.Write("==> " +car.ModelYear + " Model ");
                foreach (var color in carManager.GetColorName(car.ColorId))
                {
                    Console.Write(color.ColorName + " ");
                }
                foreach (var brand in carManager.GetBrandName(car.BrandId))
                {
                    Console.WriteLine(brand.BrandName);
                    Console.WriteLine("-----------------------------");
                }
                Console.WriteLine(" "+car.Description);
                Console.WriteLine("                                      ********************************************");
            }

            //Id bilgisi ile veri çekme
            Console.WriteLine(" ");
            Console.WriteLine("----- Id Verisi İle Bilgi Çekme -----");
            foreach (var selectedCar in carManager.GetById(2))
            {
                Console.WriteLine(selectedCar.CarId + " ===> " + selectedCar.Description );   
            }

            //Add komutu deneme 1 - 2
            Console.WriteLine(" ");
            Console.WriteLine("----- Add komutu Deneme -----");
            carManager.Add(new Car { CarId = 5, BrandId = 2, ColorId = 3, DailyPrice = 100200, Description = "GetById Deneme", ModelYear = 2022 });

            foreach (var products in carManager.GetAll())
            {
                Console.WriteLine(products.CarId + products.Description);
            }

        }
    }
}
