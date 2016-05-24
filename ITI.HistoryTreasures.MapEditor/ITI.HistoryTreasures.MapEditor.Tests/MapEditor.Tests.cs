using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.HistoryTreasures.MapEditor.Tests
{
    [TestFixture]
    public class MapEditorTests
    {
        [Test]
        public void Map_can_be_create_and_return_good_value()
        {
            Map m = new Map(5, 5);
            Tile[,] test = new Tile[5, 5];

            for (int i = 0; i < m.GetMap.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetMap.GetLength(1); j++)
                {
                    Assert.That(m.GetMap[i, j] == test[i, j]);
                }
            }
        }
    }
}
