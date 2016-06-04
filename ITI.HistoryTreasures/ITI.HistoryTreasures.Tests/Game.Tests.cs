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
            Theme t = g.CreateTheme("Theme");
            string name = "Theme";
            
            Assert.That(t.Name, Is.EqualTo(name));
            Assert.That(g.Themes.Contains(t));
        }

        [Test]
        public void Themes_is_finish_if_all_levels_are_complete()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            l.IsFinish = true;
            t.FinishTheme();

            Assert.That(g.Themes[0].IsFinish == true);
        }

        [Test]
        public void A_theme_cannot_be_created_two_times_with_same_name()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");

            Assert.Throws<InvalidOperationException>(() => g.CreateTheme("Theme"));
        }
    }

    [TestFixture]
    public class LevelTests
    {
        [Test]
        public void Levels_are_created_and_have_a_name_and_is_correctly_add_to_his_list()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            string name = "Level";

            Assert.That(l.Name, Is.EqualTo(name));
            Assert.That(t.Levels.Contains(l));
        }

        [Test]
        public void Levels_finish_return_good_value()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            l.IsFinish = true;

            Assert.That(t.Levels[0].IsFinish == true);
        }

        [Test]
        public void Levels_return_correctly_PNJ()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.Pnj;

            Assert.That(l.Pnjs.Contains(p));
        }
        
        [Test]
        public void A_level_cannot_be_created_two_times_with_same_name()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Assert.Throws<InvalidOperationException>(() => t.CreateLevel("Level"));
        }
        [Test]
        public void Level_method_interaction_work_between_MainCharacter_and_PNJ()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            PNJ pnj = l.Pnj;

            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        [Test]
        public void Level_method_interaction_work_in_diagonal_between_MainCharacter_and_PNJ()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            PNJ pnj = l.Pnj;
            
            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        /*[Test]
        public void Level_method_interaction_works_between_MainCharacter_and_Clue()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, 7, 15, "test", "Judd");
            Clue c = new Clue("Livre", l, false, 10, 10, "Un indice ? Son nom est François.");
            l._clues.Add((c));
            Assert.That(l.InteractionsWithClue(KeyEnum.action), Is.EqualTo("Un indice ? Son nom est François."));
        }*/

        [Test]
        public void Levels_return_correctly_main_character()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g,l, 16, 16, CharacterEnum.MCFACE, "Judd");

            Assert.That(mC.Game == l.MainCharacter.Game);
            Assert.That(mC.positionX == l.MainCharacter.positionX);
            Assert.That(mC.positionY == l.MainCharacter.positionY);
            //Assert.That(mC.BitMapName == l.MainCharacter.BitMapName);
            Assert.That(mC.Name == l.MainCharacter.Name);
        }
    }
}
