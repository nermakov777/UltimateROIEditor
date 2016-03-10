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
    //для каждого типа фигуры создается свой наследник от этого класса

    //скорее всего, это должен быть интерфейс

    //для полигонов чуть сложнее - там нужен старт создания и конец создания, всего у нас N вершин
    //т.е. мы кликаем N раз и должны понять, когда рисование окончено

    public class ShapeCreator
    {
        public ShapeCreator()
        { 
        
        }
        public virtual void CreateInThisPoint(int x, int y, PictureBox pictureBox, List<UltimateShape> figures)
        { 
            
        }
    }
}
