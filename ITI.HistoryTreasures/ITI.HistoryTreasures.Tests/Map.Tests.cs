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
        Game g;
        Theme t;
        Level l;
        Map m;

        [TestFixtureSetUp]
        public void MapSetUp()
        {
            g = new Game();
            t = g.CreateTheme("Theme");
            l = t.CreateLevel("Level");
            m = new Map(l, 10, 10);
        }

        [Test]
        public void Map_can_be_create()
        {
            Assert.That(m, Is.EqualTo(m));
        }

        [Test]
        public void Only_tile_with_isSolid_parameter_on_true_have_hitbox()
        {
            Tile t1 = m.TileArray[0, 0];
            Tile t2 = m.TileArray[1, 1];

            Assert.That(t1.TileHitbox == null);
            Assert.That(t2.TileHitbox != null);
        }

        [Test]
        //[Ignore("Not completed")]
        public void Tile_can_be_create_and_have_a_hitbox()
        {
            Tile t1 = m.TileArray[1, 1];

            Assert.That(t1.TileHitbox.xA == 32);
            Assert.That(t1.TileHitbox.yA == 32);
            Assert.That(t1.TileHitbox.xB == 64);
            Assert.That(t1.TileHitbox.yB == 32);
            Assert.That(t1.TileHitbox.xC == 64);
            Assert.That(t1.TileHitbox.yC == 64);
            Assert.That(t1.TileHitbox.xD == 32);
            Assert.That(t1.TileHitbox.yD == 64);
        }
    }
}
