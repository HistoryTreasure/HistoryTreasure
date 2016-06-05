using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.HistoryTreasures.Rendering
{
    class ResourcesManager
    {
        readonly Dictionary<TileEnum, Bitmap> _tileBitmaps;
        readonly Dictionary<CharacterEnum, Bitmap> _characterBitmaps;
        readonly Dictionary<ClueEnum, Bitmap> _clueBitmaps;

        /// <summary>
        /// This constructor instantiate a ResourcesManager.
        /// </summary>
        public ResourcesManager()
        {
            _tileBitmaps = new Dictionary<TileEnum, Bitmap>();
            _tileBitmaps[TileEnum.GRASS] = Properties.Resources.herbe;
            _tileBitmaps[TileEnum.WATER] = Properties.Resources.eau;
            _characterBitmaps = new Dictionary<CharacterEnum, Bitmap>();
            _characterBitmaps[CharacterEnum.MCFACE] = Properties.Resources.img_X1_Y0;
            _characterBitmaps[CharacterEnum.GUARDFACE] = Properties.Resources.droite;
            _clueBitmaps = new Dictionary<ClueEnum, Bitmap>();
            _clueBitmaps[ClueEnum.LIVRE] = Properties.Resources.livre;
        }

        /// <summary>
        /// This method returns Tile Bitmap.
        /// </summary>
        /// <param name="tile">This parameter contains a tile.</param>
        /// <returns></returns>
        public Bitmap GetTileBitmap(Tile tile)
        {
            return _tileBitmaps[tile.TileType];
        }

        public Bitmap GetCharacterBitmap(Character character)
        {
            return _characterBitmaps[character.CharacterBitmapName];
        }

        public Bitmap GetClueBitmap(Clue clue)
        {
            return _clueBitmaps[clue.ClueBitmapName];
        }
    }
}
