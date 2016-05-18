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
    }
}
