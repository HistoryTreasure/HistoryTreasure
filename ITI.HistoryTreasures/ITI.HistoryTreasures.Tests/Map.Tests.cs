using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.HistoryTreasures.Tests
{
    [TestFixture]
    class MapTest
    {
        [Test]
        [Ignore("To do")]
        public void Map_array_return_good_value()
        {
        }

        [Test]
        public void Map_can_be_create()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            Map m = new Map(l, 10, 10);

            Assert.That(m, Is.EqualTo(m));
        }

        [Test]
        public void Only_tile_with_isSolid_parameter_on_true_have_hitbox()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            Map m = new Map(l, 10, 10);
            Tile t1 = new Tile(false, TileEnum.GRASS, m);
            Tile t2 = new Tile(true, TileEnum.WATER, m);

            Assert.That(t1.TileHitbox == null);
            Assert.That(t2.TileHitbox != null);
        }
        
        [Test]
        [Ignore("Not completed")]
        public void Tile_can_be_create_and_have_a_hitbox()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            Map m = new Map(l, 10, 10);
            Tile t1 = new Tile(true, TileEnum.WATER, m);

            Assert.That(t1.TileHitbox.xA== 0);
            Assert.That(t1.TileHitbox.yA == 32);
            Assert.That(t1.TileHitbox.xB == 32);
            Assert.That(t1.TileHitbox.yB == 32);
            Assert.That(t1.TileHitbox.xC == 32);
            Assert.That(t1.TileHitbox.yC == 0);
            Assert.That(t1.TileHitbox.xD == 0);
            Assert.That(t1.TileHitbox.yD == 0);
        }
    }
}
