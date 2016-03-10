using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UltimateROIEditor.Shapes
{
    public class ShapeCreatorTrapecia : ShapeCreator
    {
        public ShapeCreatorTrapecia()
        { 
        
        }
        public override void CreateInThisPoint(int x, int y, PictureBox pictureBox, List<UltimateShape> figures)
        { 
            //пока сделаем для прямоугольника

            UltimateTrapecia urect = new UltimateTrapecia(new Rectangle(x, y, 1, 1));
            urect.SetPictureBox(pictureBox);
            figures.Add(urect);
            pictureBox.Invalidate();

            urect.IsActive = true;
            urect.IsReshape = true; //сразу начинаем его растягивать
            urect.nodeSelected = PosSizableRect.RightBottom;
        }
    }
}
