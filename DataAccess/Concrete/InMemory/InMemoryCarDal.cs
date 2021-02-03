using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        InMemoryBrandDal inMemoryBrandDal = new InMemoryBrandDal();
        InMemoryColorDal inMemoryColorDal = new InMemoryColorDal();

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2000, DailyPrice=10000, Description="Eski ama sağlam araba."},
                new Car{CarId=2, BrandId=2, ColorId=2, ModelYear=2002, DailyPrice=20000, Description="Az kullanılmış eski araba."},
                new Car{CarId=3, BrandId=3, ColorId=3, ModelYear=2020, DailyPrice=100000, Description="Bir sene eskimiş araba."},
                new Car{CarId=4, BrandId=4, ColorId=4, ModelYear=2200, DailyPrice=1000000, Description="Erken sipariş arabası."}
            };
        }
        public void Add(Car car)
        {
            
            _cars.Add(car);

        }

        public void Delete(int carId)
        {
            Car carToDelete = null;
            carToDelete = _cars.SingleOrDefault(cr => cr.CarId == carId);
            _cars.Remove(carToDelete);
        }

        public void GetAll()
        {
            var brand = inMemoryBrandDal.GetAll();
            var color = inMemoryColorDal.GetAll();

            var cars = from c in _cars
                       join b in brand
                       on c.BrandId equals b.BrandId
                       join clr in color
                       on c.ColorId equals clr.ColorId
                       select new 
                       { 
                           CarId = c.CarId, 
                           BrandName = b.BrandName, 
                           ColorName = clr.ColorName, 
                           ModelYear = c.ModelYear, 
                           Price = c.DailyPrice 
                       };
            Console.WriteLine("Car Id\t\tBrand\t\tColor\t\tModel Year\tPrice");
            
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.CarId}\t\t{item.BrandName}\t{item.ColorName}\t\t{item.ModelYear}\t\t{item.Price}\n\n");
            }

            
        }

        public void GetAllByBrand(int brandId)
        {
            var brand = inMemoryBrandDal.GetAll();

            var brands = from c in _cars
                         join b in brand
                         on c.BrandId equals b.BrandId
                         where b.BrandId == brandId
                         select new
                         {
                             CarId=c.CarId,
                             BrandId=b.BrandId,
                             BrandName=b.BrandName
                         };

            Console.WriteLine("Car Id\t\tBrand Id\tBrand Name");

            foreach (var i in brands)
            {
                Console.WriteLine($"{i.CarId}\t\t{i.BrandId}\t\t{i.BrandName}\n\n");
            }

        }

        public void GetAllByColor(int colorId)
        {
            var color = inMemoryColorDal.GetAll();

            var colors = from c in _cars
                         join clr in color
                         on c.ColorId equals clr.ColorId
                         where clr.ColorId == colorId
                         select new
                         {
                             CarId = c.CarId,
                             ColorId = clr.ColorId,
                             ColorName = clr.ColorName
                         };

            Console.WriteLine("Car Id\t\tColor Id\tColor Name");

            foreach (var i in colors)
            {
                Console.WriteLine($"{i.CarId}\t\t{i.ColorId}\t\t{i.ColorName}\n\n");
            }
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
