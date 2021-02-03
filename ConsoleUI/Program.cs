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
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            Console.WriteLine("\t\t\tEXISTING ONES\n");
            carManager.GetAll();
            Console.WriteLine("\n-------------------------------------------------------------------\n");

            Brand brand5 = new Brand() { BrandId = 5, BrandName = "CarBrand5" };
            brandManager.Add(brand5);
            Color color5 = new Color() { ColorId = 5, ColorName = "Blue" };
            colorManager.Add(color5);

            //foreach (var i in brandManager.GetAll())
            //{
            //    Console.WriteLine(i.BrandName);
            //}

            //Yeni BrandId ve ColorId girmek için önce onlardan eklenmeli.
            carManager.Add(new Car() { CarId = 5, BrandId = 5, ColorId = 5, 
                ModelYear = 2021, DailyPrice = 90000, Description = "Dumanı üstünde"});

            // **** Eklenen aracı göstermiyor ****

            //carManager.GetAll();   


            //foreach (var i in carManager.GetAllByBrand(2))
            //{
            //    Console.WriteLine(i.BrandId+" "+i.CarId);
            //}

            carManager.GetAllByBrand(1);

            carManager.GetAllByColor(3);



            // Eksikleri Tamamlanacak

        }

    }
}
