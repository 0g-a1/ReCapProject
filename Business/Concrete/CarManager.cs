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

        public void Delete(int carId)
        {
            _carDal.Delete(carId);
        }

        public void GetAll()
        {
            //iş kodu , yetki vs vs . . . 
            _carDal.GetAll();
        }

        public void GetAllByBrand(int brandId)
        {
            _carDal.GetAllByBrand(brandId);
        }

        public void GetAllByColor(int colorId)
        {
            _carDal.GetAllByColor(colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
