using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.HistoryTreasures.Tests
{
    [TestFixture]
    public class Game
    {
        [Test]
        public void T01_Theme_can_be_created_and_be_add_to_the_theme_list()
        {
            Theme t = new Theme("Test");
            string name = "Test";
            t._theme.Add(t);
            Assert.That(t.Name, Is.EqualTo(name));
            Assert.That(t._theme.Contains(t)); //Yacine write this
        }
    }
}
