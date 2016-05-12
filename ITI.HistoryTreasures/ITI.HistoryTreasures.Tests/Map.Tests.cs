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

            Assert.That(_test[0, 0].Map, Is.EqualTo(_verif[0, 0].Map));
            Assert.That(_test[0, 0].IsSolid, Is.EqualTo(_verif[0, 0].IsSolid));
            Assert.That(_test[0, 0].TileEnum, Is.EqualTo(_verif[0, 0].TileEnum));
            CollectionAssert.AreEqual(_test, _verif);
        }
    }
}
