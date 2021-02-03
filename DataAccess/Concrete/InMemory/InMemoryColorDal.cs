using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="White"},
                new Color{ColorId=2,ColorName="Black"},
                new Color{ColorId=3,ColorName="Red"},
                new Color{ColorId=4,ColorName="Green"}
            };
            
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(int colorId)
        {
            Color colorToDelete = _colors.First(clr => clr.ColorId == colorId);
            _colors.Remove(colorToDelete);
            
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAllById(int colorId)
        {
            return _colors.Where(clr => clr.ColorId == colorId).ToList();
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.First(clr => clr.ColorId == color.ColorId);

            colorToUpdate.ColorId = color.ColorId;
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
