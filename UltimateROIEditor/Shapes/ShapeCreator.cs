using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UltimateROIEditor.Shapes
{
    //абстрактный класс - создатель фигур
    //нужен при клике на кнопку и рисовании соотствующей фигуры вручную
    //для каждого типы фигуры создается свой наследник от этого класса
    public class ShapeCreator
    {
        public ShapeCreator()
        { 
        
        }
        public void CreateInThisPoint(int x, int y, PictureBox pictureBox, List<UltimateShape> figures)
        { 
            //пока сделаем для прямоугольника

            UltimateRectangle urect = new UltimateRectangle(new Rectangle(x, y, 1, 1));
            urect.SetPictureBox(pictureBox);
            figures.Add(urect);
            pictureBox.Invalidate();

            urect.IsActive = true;
            urect.IsReshape = true; //сразу начинаем его растягивать
            urect.nodeSelected = PosSizableRect.RightBottom;
        }
    }
}
