﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(int colorId)
        {
            _colorDal.Delete(colorId);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetAllById(int colorId)
        {
            return _colorDal.GetAllById(colorId);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
