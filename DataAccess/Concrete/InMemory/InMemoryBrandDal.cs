using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="CarBrand1"},
                new Brand{BrandId=2,BrandName="CarBrand2"},
                new Brand{BrandId=3,BrandName="CarBrand3"},
                new Brand{BrandId=4,BrandName="CarBrand4"}
            };
        }
        

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(int brandId)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brandId);
            _brands.Remove(brandToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetAllById(int brandId)
        {
            return _brands.Where(b => b.BrandId == brandId).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);

            brandToUpdate.BrandId = brand.BrandId;
            brandToUpdate.BrandName = brand.BrandName;
        }
    }
}
