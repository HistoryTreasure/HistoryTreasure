using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ITI.HistoryTreasures
{
    public class Map
    {
        readonly Level _level;
        Tile[,] _tileArray;
        List<Hitbox> hitboxes;
        readonly XmlTextReader test = new XmlTextReader("Map.xml");


        /// <summary>
        /// This constructor create a Map.
        /// </summary>
        /// <param name="level">Level context.</param>
        public Map(Level level, int width, int height)
        {
            _level = level;

            _tileArray = new Tile[ArrayWidth(test), ArrayHeigth(test)];

            _tileArray = CreateMap(TileArray, test);

            level.MainCharacter.MCtx = this;
            CreateTileHitbox(TileArray);
        }

        /// <summary>
        /// Creates the tile hitbox.
        /// </summary>
        /// <param name="tileArray">The tile array.</param>
        public void CreateTileHitbox(Tile[,] tileArray)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    TileArray[i, j].posX = x;
                    TileArray[i, j].posY = y;

                    if (TileArray[i, j].IsSolid == true)
                    {
                        TileArray[i, j].CreateTileHitbox(x, y);
                    }

                    x += 32;
                }
                x = 0;
                y += 32;
            }
        }

        /// <summary>
        /// This property returns a level.
        /// </summary>
        public Level Level
        {
            get { return _level; }
        }

        /// <summary>
        /// Get the Width of the array from an XML
        /// </summary>
        /// <param name="xml">The xml.</param>
        /// <returns>The width in a int</returns>
        private int ArrayWidth(XmlTextReader xml)
        {
            int arrayWidth = 0;

            while (xml.Read())
            {
                if (xml.Name == "Width")
                {
                    xml.Read();
                    arrayWidth = Convert.ToInt32(xml.Value);
                    return arrayWidth;
                }
            }

            throw new ArgumentException("The XML dosn't contains a width information");
        }

        /// <summary>
        /// Arrays the heigth.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>The height in a int</returns>
        private int ArrayHeigth(XmlTextReader xml)
        {
            int arrayHeight = 0;

            while (xml.Read())
            {
                if (xml.Name == "Height")
                {
                    xml.Read();
                    arrayHeight = Convert.ToInt32(xml.Value);
                    return arrayHeight;
                }
            }

            throw new ArgumentException("The XML dosn't contains a height information");
        }

        /// <summary>
        /// Creates the map.
        /// </summary>
        /// <param name="tileArray">The tile array.</param>
        /// <param name="xml">The XML.</param>
        /// <returns>The tilearray of the map</returns>
        /// <exception cref="System.ArgumentException">
        /// The tileArray must not be empty
        /// or
        /// The XML must not be empty
        /// </exception>
        private Tile[,] CreateMap(Tile[,] tileArray, XmlTextReader xml)
        {
            int x = 0;
            int y = 0;
            if (TileArray == null)
            {
                throw new ArgumentException("The tileArray must not be empty");
            }
            if (xml == null)
            {
                throw new ArgumentException("The XML must not be empty");
            }

            while (xml.Read())
            {
                {
                    if (xml.Name == "Tile")
                    {
                        xml.Read();
                        if (xml.Value == "Water")
                        {
                            tileArray[x, y] = new Tile(true, TileEnum.WATER, this);
                            if (x == Width - 1)
                            {
                                tileArray[x, y] = new Tile(true, TileEnum.WATER, this);
                                x = 0;
                                y++;
                            }
                            else
                            {
                                x++;
                            }
                        }
                        else if (xml.Value == "Bridge")
                        {
                            tileArray[x, y] = new Tile(false, TileEnum.BRIDGE, this);
                            if (x == Width - 1)
                            {
                                tileArray[x, y] = new Tile(false, TileEnum.BRIDGE, this);
                                x = 0;
                                y++;
                            }

                            else
                            {
                                x++;
                            }
                        }
                        else if (xml.Value == "Home")
                        {
                            tileArray[x, y] = new Tile(false, TileEnum.HOME, this);
                            if (x == Width - 1)
                            {
                                tileArray[x, y] = new Tile(false, TileEnum.HOME, this);
                                x = 0;
                                y++;
                            }
                            else
                            {
                                tileArray[x, y] = new Tile(false, TileEnum.HOME, this);
                                x++;
                            }
                        }
                        else if (xml.Value == "Clue")
                        {
                            tileArray[y, x] = new Tile(false, TileEnum.CLUE, this);
                            if (x == Width - 1)
                            {
                                tileArray[y, x] = new Tile(false, TileEnum.CLUE, this);
                                x = 0;
                                y++;
                            }
                            else
                            {
                                x++;
                            }
                        }
                        else if (xml.Value == "Floor")
                        {
                            tileArray[x, y] = new Tile(true, TileEnum.CLUE, this);
                            if (x == Width - 1)
                            {
                                tileArray[x, y] = new Tile(true, TileEnum.CLUE, this);
                                x = 0;
                                y++;
                            }
                            else
                            {
                                tileArray[x, y] = new Tile(true, TileEnum.CLUE, this);
                                x++;
                            }
                        }
                        else if (xml.Value == "Pnj")
                        {
                            tileArray[x, y] = new Tile(false, TileEnum.PNJ, this);
                            if (x == Width - 1)
                            {
                                tileArray[y, x] = new Tile(false, TileEnum.PNJ, this);
                                x = 0;
                                y++;
                            }
                            else
                            {
                                x++;
                            }
                        }
                    }
                }
            }
            return tileArray;
        }

        /// <summary>
        /// This property returns field tilearray.
        /// </summary>
        public Tile[,] TileArray
        {
            get { return _tileArray; }
            set { _tileArray = value; }
        }

        /// <summary>
        /// This property returns vertical length of array.
        /// </summary>
        public int Height
        {
            get { return _tileArray.GetLength(1); }
        }

        /// <summary>
        /// This property returns horizontal length of array.
        /// </summary>
        public int Width
        {
            get { return _tileArray.GetLength(0); }
        }

        /// <summary>
        /// Gets the hitboxes of all elements in the map except maincharacter.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public List<Hitbox> GetHitboxes(Map map)
        {
            hitboxes = new List<Hitbox>();
            foreach (Tile tile in TileArray)
            {
                if (tile.IsSolid)
                {
                    hitboxes.Add(tile.TileHitbox);
                }
            }

            foreach (PNJ pnj in Level.Pnjs)
            {
                hitboxes.Add(pnj.HitBox);
            }

            foreach (Clue clue in Level.Clues)
            {
                hitboxes.Add(clue.HitBox);
            }

            return hitboxes;
        }
    }
}
