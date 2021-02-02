using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Brand> GetBrandName(int brand);
        List<Color> GetColorName(int color);
    }
}
