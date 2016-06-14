using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;

namespace ITI.HistoryTreasures.MapEditor
{
    public class BitmapToXML
    {
        Bitmap b = Properties.Resources._base;
        
        public void Translate()
        {
            List<Color> _colors = new List<Color>();
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    Color p = b.GetPixel(i, j);
                    _colors.Add(p);
                    //if (p == Color.CornflowerBlue)
                    //{
                    //    XElement map = new XElement("Map",
                    //    new XElement("Tile", "Water")
                    //      );
                    //}
                    //else if (p == Color.SandyBrown)
                    //{
                    //    new XElement("Tile", "Floor");
                    //}
                    //else if (p == Color.Brown)
                    //{
                    //    new XElement("Tile", "Bridge");
                    //}
                    //else if (p == Color.Black)
                    //{
                    //    new XElement("Tile", "Home");
                    //}
                    //else if (p == Color.Violet)
                    //{
                    //    new XElement("Tile", "PNJ");
                    //}
                    //else if (p == Color.Crimson)
                    //{
                    //    new XElement("Tile", "Clue");
                    //}
                }
            }
        }
    }
}
