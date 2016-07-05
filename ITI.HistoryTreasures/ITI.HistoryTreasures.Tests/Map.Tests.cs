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
            t = g.Themes[0];
            l = t.Levels[0];
            m = new Map(l);
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
            Tile t2 = m.TileArray[3, 5];

            Assert.That(t1.TileHitbox == null);
            Assert.That(t2.TileHitbox != null);
        }

        [Test]
        //[Ignore("Not completed")]
        public void Tile_can_be_create_and_have_a_hitbox()
        {
            Tile t1 = m.TileArray[3, 5];

            Assert.That(t1.TileHitbox.xA == 160);
            Assert.That(t1.TileHitbox.yA == 96);
            Assert.That(t1.TileHitbox.xB == 192);
            Assert.That(t1.TileHitbox.yB == 96);
            Assert.That(t1.TileHitbox.xC == 192);
            Assert.That(t1.TileHitbox.yC == 128);
            Assert.That(t1.TileHitbox.xD == 160);
            Assert.That(t1.TileHitbox.yD == 128);
        }
    }
}
