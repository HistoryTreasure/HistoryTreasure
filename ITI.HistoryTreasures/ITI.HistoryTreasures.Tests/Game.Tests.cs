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
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "level");
            g._themes.Add(t);
            t._levels.Add(l);

            l.IsFinish = true;
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
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Try");
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
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "level");
            g._themes.Add(t);
            t._levels.Add(l);
            l.IsFinish = true;

            Assert.That(t._levels[0].IsFinish == true);
        }

        [Test]
        public void Levels_return_correctly_PNJ()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 0, 0, "test", "Hawke", "Hello world !");
            g._themes.Add(t);
            t._levels.Add(l);
            l._pnj.Add(p);
            Assert.That(l._pnj.Contains(p));
        }

        [Test]
        public void Level_method_interaction_work_between_MainCharacter_and_PNJ()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 15, 15, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            g._themes.Add(t);
            t._levels.Add(l);
            PNJ pnj = new PNJ(g, l, 48, 48, "test", "Hawke", "Hello world !");
            l._pnj.Add(pnj);
            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        [Test]
        public void Level_method_interaction_work_in_diagonal_between_MainCharacter_and_PNJ()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 7, 15, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            g._themes.Add(t);
            t._levels.Add(l);
            PNJ pnj = new PNJ(g, l, 48, 48, "test", "Hawke", "Hello world !");
            l._pnj.Add(pnj);
            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        [Test]
        public void Levels_return_correctly_main_character()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "Test", "Judd");
            Level l = new Level(t, mC, "Level");
            g._themes.Add(t);
            t._levels.Add(l);
            Assert.That(l.MainCharacter, Is.EqualTo(mC));
        }
    }
}
