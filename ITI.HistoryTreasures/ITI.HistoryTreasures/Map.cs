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
        XmlTextReader test = new XmlTextReader("Map.xml");
        

        /// <summary>
        /// This constructor create a Map.
        /// </summary>
        /// <param name="level">Level context.</param>
        public Map(Level level, int width, int height)
        {
            _level = level;

            _tileArray = new Tile[ArrayWidth(test),ArrayHeigth(test)];
            
            /*_tileArray = new Tile[5, 5];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _tileArray[0, 0] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[0, 1] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[0, 2] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[0, 3] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[0, 4] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[1, 0] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[1, 1] = new Tile(true, TileEnum.WATER, level.MapContext);
                    _tileArray[1, 2] = new Tile(true, TileEnum.WATER, level.MapContext);
                    _tileArray[1, 3] = new Tile(true, TileEnum.WATER, level.MapContext);
                    _tileArray[1, 4] = new Tile(true, TileEnum.WATER, level.MapContext);
                    _tileArray[2, 0] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[2, 1] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[2, 2] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[2, 3] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[2, 4] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[3, 0] = new Tile(true, TileEnum.WATER, level.MapContext);
                    _tileArray[3, 1] = new Tile(true, TileEnum.WATER, level.MapContext);
                    _tileArray[3, 2] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[3, 3] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[3, 4] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[4, 0] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[4, 1] = new Tile(true, TileEnum.WATER, level.MapContext);
                    _tileArray[4, 2] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[4, 3] = new Tile(false, TileEnum.GRASS, level.MapContext);
                    _tileArray[4, 4] = new Tile(true, TileEnum.WATER, level.MapContext);
                }
            }*/

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

        private int ArrayWidth(XmlTextReader test)
        {
            int arrayWidth = 0;
            
            while (test.Read())
            {
                if (test.Name == "Width")
                {
                    test.Read();
                    arrayWidth = Convert.ToInt32(test.Value);
                    return arrayWidth;
                }
            }

            return 0;
        }

        private int ArrayHeigth(XmlTextReader test)
        {
            int arrayHeight = 0;

            while (test.Read())
            {
                if (test.Name == "Height")
                {
                    test.Read();
                    arrayHeight = Convert.ToInt32(test.Value);
                    return arrayHeight;
                }
            }

            return 0;
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
