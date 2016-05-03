using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.HistoryTreasures.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Created_new_game()
        {
            Game game = new Game();
            Assert.That(game.Themes != null);
        }
    }

    [TestFixture]
    public class ThemeTests
    {
        [Test]
        public void Themes_are_created_and_have_a_name_and_is_correctly_add_to_his_list()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Test");
            string name = "Test";
            g._themes.Add(t);
            Assert.That(t.Name, Is.EqualTo(name));
            Assert.That(g._themes.Contains(t));
        }

        [Test]
        public void Themes_is_finish_if_all_levels_are_complete()
        {
            Game g = new Game();
            Theme t = new Theme(g, "theme");
            Level l = new Level(t, "level");
            g._themes.Add(t);
            t._levels.Add(l);

            l.FinishLevel();
            t.FinishTheme();

            Assert.That(g._themes[0].IsFinish == true);
        }
    }

    [TestFixture]
    public class LevelTests
    {
        [Test]
        public void Levels_are_created_and_have_a_name_and_is_correctly_add_to_his_list()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Test");
            Level l = new Level(t, "Try");
            string name = "Try";
            g._themes.Add(t);
            t._levels.Add(l);
            Assert.That(l.Name, Is.EqualTo(name));
            Assert.That(t._levels.Contains(l));
        }

        [Test]
        public void Levels_finish_return_good_value()
        {
            Game g = new Game();
            Theme t = new Theme(g, "theme");
            Level l = new Level(t,"level");
            g._themes.Add(t);
            t._levels.Add(l);
            l.FinishLevel();

            Assert.That(t._levels[0].IsFinish == true);
        }
    }
}
