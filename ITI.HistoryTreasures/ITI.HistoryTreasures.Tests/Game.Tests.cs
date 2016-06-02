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
        Game g;
        Theme t;

        [TestFixtureSetUp]
        public void ThemeSetUp()
        {
            g = new Game();
            t = g.CreateTheme("Theme");
        }

        [Test]
        public void Themes_are_created_and_have_a_name_and_is_correctly_add_to_his_list()
        {
            string name = "Theme";
            
            Assert.That(t.Name, Is.EqualTo(name));
            Assert.That(g.Themes.Contains(t));
        }

        [Test]
        public void Themes_is_finish_if_all_levels_are_complete()
        {
            Level l = t.CreateLevel("Level");

            l.IsFinish = true;
            t.FinishTheme();

            Assert.That(g.Themes[0].IsFinish == true);
        }

        [Test]
        public void A_theme_cannot_be_created_two_times_with_same_name()
        {
            Assert.Throws<InvalidOperationException>(() => g.CreateTheme("Theme"));
        }
    }

    [TestFixture]
    public class LevelTests
    {
        Game g;
        Theme t;
        Level l;
        Clue c;

        [TestFixtureSetUp]
        public void LevelSetUp()
        {
            g = new Game();
            t = g.CreateTheme("Theme");
            l = t.CreateLevel("Level");
            c = l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !");
        }

        [Test]
        public void Levels_are_created_and_have_a_name_and_is_correctly_add_to_his_list()
        {
            string name = "Level";

            Assert.That(l.Name, Is.EqualTo(name));
            Assert.That(t.Levels.Contains(l));
        }

        [Test]
        public void Levels_finish_return_good_value()
        {
            l.IsFinish = true;

            Assert.That(t.Levels[0].IsFinish == true);
        }

        [Test]
        public void Levels_return_correctly_PNJ()
        {
            PNJ p = l.Pnj;

            Assert.That(l.Pnjs.Contains(p));
        }
        
        [Test]
        public void A_level_cannot_be_created_two_times_with_same_name()
        {
            Assert.Throws<InvalidOperationException>(() => t.CreateLevel("Level"));
        }
        [Test]
        public void Level_method_interaction_work_between_MainCharacter_and_PNJ()
        {
            PNJ pnj = l.Pnj;

            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        [Test]
        public void Level_method_interaction_work_in_diagonal_between_MainCharacter_and_PNJ()
        {
            PNJ pnj = l.Pnj;
            
            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        [Test]
        public void Level_method_interaction_works_between_MainCharacter_and_Clue()
        {
            Assert.That(l.InteractionsWithClue(KeyEnum.action), Is.EqualTo("Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_method_interaction_works_in_diagonal_between_MainCharacter_and_Clue()
        {
            Assert.That(l.InteractionsWithClue(KeyEnum.action), Is.EqualTo("Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Levels_return_correctly_main_character()
        {
            Assert.That(l.MainCharacter.Game == g);
            Assert.That(l.MainCharacter.positionX == 16);
            Assert.That(l.MainCharacter.positionY == 16);
            Assert.That(l.MainCharacter.CharacterBitmapName == CharacterEnum.MCFACE);
            Assert.That(l.MainCharacter.Name == "Judd");
        }

        [Test]
        public void Levels_returns_correctly_Clue()
        {
            Assert.That(c.LCtx == l);
            Assert.That(c.X == 32);
            Assert.That(c.Y == 32);
            Assert.That(c.Name == "Livre");
            Assert.That(c.Speech == "Un indice ? Son nom est Henri !");
        }

        [Test]
        public void Level_can_create_several_clue_and_return_several_speech_different()
        {
            Clue c2 = l.CreateClue(t, 52, 52, "Clue", "Tableau", "Un indice ? Son cheval est blanc !");

            Assert.That(c.Speech, Is.EqualTo("Un indice ? Son nom est Henri !"));
            Assert.That(c2.Speech, Is.EqualTo("Un indice ? Son cheval est blanc !"));
            Assert.That(l.Clues.Contains(c));
            Assert.That(l.Clues.Contains(c2));
        }

        [Test]
        public void Level_the_Clue_have_a_unique_name()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_the_Clue_have_a_unique_speech()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_created_if_his_position_is_negative()
        {
            Assert.Throws<ArgumentException>(() => l.CreateClue(t, -1, 0, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_created_outside_the_map()
        {
            Map m = new Map(l, 5, 5);

            Assert.Throws<ArgumentException>(() => l.CreateClue(t, 170, 170, "Clue", "Truc", "Truc"));
        }

        [Test]
        public void Level_two_Clue_cannot_be_create_on_the_same_position()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 16, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_create_on_a_PNJ()
        {
            PNJ p = l.Pnj;

            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_create_on_MainCharacter()
        {
           Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 16, 16, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_returns_correctly_his_hitbox()
        {
            Assert.That(c.HitBox.xA, Is.EqualTo(16));
            Assert.That(c.HitBox.yA, Is.EqualTo(32));
            Assert.That(c.HitBox.xB, Is.EqualTo(48));
            Assert.That(c.HitBox.yB, Is.EqualTo(32));
            Assert.That(c.HitBox.xC, Is.EqualTo(48));
            Assert.That(c.HitBox.yC, Is.EqualTo(48));
            Assert.That(c.HitBox.xD, Is.EqualTo(16));
            Assert.That(c.HitBox.yD, Is.EqualTo(48));
        }
    }
}
