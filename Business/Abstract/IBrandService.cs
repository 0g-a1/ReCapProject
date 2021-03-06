﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(int brandId);

        List<Brand> GetAll();
        List<Brand> GetAllById(int brandId);
    }
}
