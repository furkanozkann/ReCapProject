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

                
        }
    }
}
