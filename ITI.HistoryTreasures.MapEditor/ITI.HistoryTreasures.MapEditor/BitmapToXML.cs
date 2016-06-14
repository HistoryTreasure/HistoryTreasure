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
                    if (p.Name == "ff4040c0")
                    {
                        XElement map = new XElement("Map",
                        new XElement("Tile", "Water")
                          );
                    }
                    else if (p.Name == "ff08040")
                    {
                        new XElement("Tile", "Floor");
                    }
                    else if (p.Name == "ff800000")
                    {
                        new XElement("Tile", "Bridge");
                    }
                    else if (p.Name == "ff000000")
                    {
                        new XElement("Tile", "Home");
                    }
                    else if (p.Name == "ff040c0")
                    {
                        new XElement("Tile", "PNJ");
                    }
                    else if (p.Name == "ffe02040")
                    {
                        new XElement("Tile", "Clue");
                    }
                }
            }
        }
    }
}
