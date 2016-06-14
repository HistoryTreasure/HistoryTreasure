using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.HistoryTreasures.MapEditor
{
    public class BitmapToXML
    {
        Bitmap b = Properties.Resources._base;

        public void Translate()
        {
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    b.GetPixel(i, j);
                }
            }
        }
    }
}
