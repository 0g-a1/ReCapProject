using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void GetAll();
        void GetAllByBrand(int brandId);
        void GetAllByColor(int colorId);

        void Add(Car car);
        void Update(Car car);
        void Delete(int carId);
    }
}
