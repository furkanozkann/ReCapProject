using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
            
        }

        public List<Brand> GetBrandName(int brand)
        {
            return _carDal.GetByBrandId(brand);
            
        }

        public List<Car> GetById(int car)
        {
            return _carDal.GetById(car);
        }

        public List<Color> GetColorName(int color)
        {
            return _carDal.GetByColorId(color);

        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
