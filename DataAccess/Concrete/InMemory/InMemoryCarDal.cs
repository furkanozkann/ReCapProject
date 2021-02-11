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
        List<Color> _colors;
        List<Brand> _brands;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { CarId = 1, BrandId = 1, ColorId = 4, ModelYear = 2021, Description = "Yeni BMW 4 Serisi Coupé M Modelleri estetik, karakter ve M modellerine özgü atletik özelliklerin hayranlık veren bir bileşimini sunuyor.", DailyPrice = 100000 },
                new Car { CarId = 2, BrandId = 2, ColorId = 1, ModelYear = 2020, Description = "Aventador Revolutionary thinking is at the heart of every idea from Automobili Lamborghini. Whether it is aerospace-inspired design or technologies applied to the naturally aspirated V12 engine or carbon-fiber structure, going beyond accepted limits is part of our philosophy.", DailyPrice = 120000 },
                new Car { CarId = 3, BrandId = 2, ColorId = 5, ModelYear = 2021, Description = "The Urus Pearl Capsule offers a selection of exclusive pearl paints and style elements that embrace the bright colors of Lamborghini tradition. ", DailyPrice = 140000 },
                new Car { CarId = 4, BrandId = 1, ColorId = 6, ModelYear = 2020, Description = "BMW 3 Serisi, yolculuğunuzu daha güvenli ve daha konforlu kılacak bir dizi akıllı asistan sistemi ve yenilikçi teknolojiler sunuyor.", DailyPrice = 160000 }
            };

            _colors = new List<Color> {
                new Color {ColorId = 1, ColorName = "Beyaz"},
                new Color {ColorId = 2, ColorName = "Siyah"},
                new Color {ColorId = 3, ColorName = "Kırmızı"},
                new Color {ColorId = 4, ColorName = "Sarı"},
                new Color {ColorId = 5, ColorName = "Yeşil"},
                new Color {ColorId = 6, ColorName = "Mavi"}
            };

            _brands = new List<Brand> { 
                new Brand {BrandId = 1, BrandName = "BMW"},
                new Brand {BrandId = 2, BrandName = "Lamborghini"},
                new Brand {BrandId = 3, BrandName = "Porsche"},
                new Brand {BrandId = 4, BrandName = "Camaro"},
                new Brand {BrandId = 5, BrandName = "Audi"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
