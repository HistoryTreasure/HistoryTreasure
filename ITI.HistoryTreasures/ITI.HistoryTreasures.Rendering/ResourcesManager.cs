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
            _tileBitmaps[TileEnum.HOME] = Properties.Resources.home;
            _tileBitmaps[TileEnum.FLOOR] = Properties.Resources.floor;
            _tileBitmaps[TileEnum.ROCK] = Properties.Resources.rock;
            _tileBitmaps[TileEnum.STONEPATH] = Properties.Resources.stonepath;
            _tileBitmaps[TileEnum.HOLE] = Properties.Resources.hole;

            _characterBitmaps = new Dictionary<CharacterEnum, Bitmap>();
            _characterBitmaps[CharacterEnum.MCFACE] = Properties.Resources.downStand;
            _characterBitmaps[CharacterEnum.MCFACERIGHT] = Properties.Resources.downRight;
            _characterBitmaps[CharacterEnum.MCFACELEFT] = Properties.Resources.downLeft;
            _characterBitmaps[CharacterEnum.MCBACK] = Properties.Resources.upStand;
            _characterBitmaps[CharacterEnum.MCBACKLEFT] = Properties.Resources.upLeft;
            _characterBitmaps[CharacterEnum.MCBACKRIGHT] = Properties.Resources.upRight;
            _characterBitmaps[CharacterEnum.MCLEFT] = Properties.Resources.leftStand;
            _characterBitmaps[CharacterEnum.MCLEFTRIGHT] = Properties.Resources.leftRight;
            _characterBitmaps[CharacterEnum.MCLEFTLEFT] = Properties.Resources.leftLeft;
            _characterBitmaps[CharacterEnum.MCRIGHT] = Properties.Resources.rightStand;
            _characterBitmaps[CharacterEnum.MCRIGHTRIGHT] = Properties.Resources.rightRight;
            _characterBitmaps[CharacterEnum.MCRIGHTLEFT] = Properties.Resources.rightLeft;

            _characterBitmaps[CharacterEnum.PNJGIRL] = Properties.Resources.downGirl;
            _characterBitmaps[CharacterEnum.PNJGIRLLEFT] = Properties.Resources.leftGirl;
            _characterBitmaps[CharacterEnum.PNJGIRLRIGHT] = Properties.Resources.rightGirl;
            _characterBitmaps[CharacterEnum.PNJCREED] = Properties.Resources.downPnj;
            _characterBitmaps[CharacterEnum.PNJCREEDLEFT] = Properties.Resources.leftPnj;
            _characterBitmaps[CharacterEnum.PNJCREEDRIGHT] = Properties.Resources.rightPnj;
            _characterBitmaps[CharacterEnum.PNJGUARD] = Properties.Resources.downGuard;
            _characterBitmaps[CharacterEnum.PNJGUARDLEFT] = Properties.Resources.leftGuard;
            _characterBitmaps[CharacterEnum.PNJGUARDRIGHT] = Properties.Resources.rightGuard;
            _characterBitmaps[CharacterEnum.PNJUNDERTAKER] = Properties.Resources.downUndertaker;
            _characterBitmaps[CharacterEnum.PNJUNDERTAKERLEFT] = Properties.Resources.leftUndertaker;
            _characterBitmaps[CharacterEnum.PNJUNDERTAKERRIGHT] = Properties.Resources.rightUndertaker;

            _clueBitmaps = new Dictionary<ClueEnum, Bitmap>();
            _clueBitmaps[ClueEnum.LIVRE] = Properties.Resources.book;
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

        /// <summary>
        /// Gets the character bitmap.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        public Bitmap GetCharacterBitmap(Character character)
        {
            return _characterBitmaps[character.CharacterBitmapName];
        }

        /// <summary>
        /// Gets the clue bitmap.
        /// </summary>
        /// <param name="clue">The clue.</param>
        /// <returns></returns>
        public Bitmap GetClueBitmap(Clue clue)
        {
            return _clueBitmaps[clue.ClueBitmapName];
        }
    }
}
