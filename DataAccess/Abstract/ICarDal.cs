using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Brand> GetByBrandId(int brandId);
        List<Color> GetByColorId(int colorId);
        List<Car> GetById(int carId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
