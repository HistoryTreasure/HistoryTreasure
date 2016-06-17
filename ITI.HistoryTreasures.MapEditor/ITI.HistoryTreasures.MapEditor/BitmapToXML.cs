using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using System.Xml;

namespace ITI.HistoryTreasures.MapEditor
{
    public class BitmapToXML
    {
        Bitmap b = Properties.Resources._1_3;
        List<XElement> xElements = new List<XElement>();
        StringBuilder sb = new StringBuilder();
        XmlWriterSettings xws = new XmlWriterSettings();

        public BitmapToXML()
        {
            XElement map = new XElement("Map",
                new XElement("Width", b.Height),
                new XElement("Height", b.Width),
                Translate()
                );
            map.Save("./1_3.xml");

            ReadXMLFile();
        }

        public List<XElement> Translate()
        {
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    Color p = b.GetPixel(i, j);

                    if (p.Name == "ff3f48cc")
                    {
                        xElements.Add(new XElement("Tile", "Water"));
                    }
                    else if (p.Name == "ffb97a57")
                    {
                        xElements.Add(new XElement("Tile", "Floor"));
                    }
                    else if (p.Name == "ff800000")
                    {
                        xElements.Add(new XElement("Tile", "Bridge"));
                    }
                    else if (p.Name == "ff000000")
                    {
                        xElements.Add(new XElement("Tile", "Home"));
                    }
                    else if (p.Name == "ff22b14c")
                    {
                        xElements.Add(new XElement("Tile", "Grass"));
                    }
                    else if (p.Name == "ff7f7f7f")
                    {
                        xElements.Add(new XElement("Tile", "Rock"));
                    }
                    else if (p.Name == "ffc3c3c3")
                    {
                        xElements.Add(new XElement("Tile", "StonePath"));
                    }

                }
            }
            return xElements;
        }

        public void ReadXMLFile()
        {
            string tile;
            XmlTextReader reader = new XmlTextReader("Map.xml");
            reader.Read();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name == "Tile")
                    {
                        reader.Read();
                        if (reader.NodeType == XmlNodeType.Text)
                        {
                            tile = reader.Value;
                            reader.Read();
                        }
                    }
                }
            }
        }
    }
}
