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
        public void Map_array_return_good_value()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            Level l = new Level(t, "Level");
            Map m = new Map(l);
            Tile[,] _test;
            Tile _floor = new Tile(false, TileEnum.BOATFLOOR, m);
            Tile[,] _verif = new Tile[,] { { _floor, _floor }, { _floor, _floor } };

            _test = m.map1;

            int line = 0;

            for (int i = 0; i < 2; i++)
            {
                Assert.That(_test[line, i].Map, Is.EqualTo(_verif[line, i].Map));
                Assert.That(_test[line, i].IsSolid, Is.EqualTo(_verif[line, i].IsSolid));
                Assert.That(_test[line, i].TileType, Is.EqualTo(_verif[line, i].TileType));
                if (i == 1 && line < 1)
                {
                    i = 0;
                    line++;
                }
            }
        }

        [Test]
        public void Map_can_be_create()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            Level l = new Level(t, "Level");
            Map m = new Map(l);

            Assert.That(m, Is.EqualTo(m));
        }
    }
}
