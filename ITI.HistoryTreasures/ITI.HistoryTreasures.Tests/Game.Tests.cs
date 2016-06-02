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
            PNJ p = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");

            Assert.That(l.PNJ.Contains(p));
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

            PNJ pnj = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");

            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        [Test]
        public void Level_method_interaction_work_in_diagonal_between_MainCharacter_and_PNJ()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            MainCharacter mC = new MainCharacter(g, 16, 16, "test", "Judd");
            Level l = t.CreateLevel("Level");
    
            PNJ pnj = new PNJ(g, l, 48, 48, "test", "Hawke", "Hello world !");
            
            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hello world !"));
        }

        [Test]
        public void Level_method_interaction_works_between_MainCharacter_and_Clue()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c = l.CreateClue(t, 32, 32, "Clue","Livre", "Un indice ? Son nom est François.");

            Assert.That(l.InteractionsWithClue(KeyEnum.action), Is.EqualTo("Un indice ? Son nom est François."));
        }

        [Test]
        public void Level_method_interaction_works_in_diagonal_between_MainCharacter_and_Clue()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c = l.CreateClue(t, 48, 48, "Clue", "Livre", "Un indice ? Son nom est François.");

            Assert.That(l.InteractionsWithClue(KeyEnum.action), Is.EqualTo("Un indice ? Son nom est François."));
        }

        [Test]
        public void Levels_return_correctly_main_character()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            
            Assert.That(l.MainCharacter.Game == g);
            Assert.That(l.MainCharacter.positionX == 16);
            Assert.That(l.MainCharacter.positionY == 16);
            Assert.That(l.MainCharacter.BitMapName == "Test");
            Assert.That(l.MainCharacter.Name == "Judd");
        }

        [Test]
        public void Levels_returns_correctly_Clue()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c = l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est François !");

            Assert.That(c.LCtx == l);
            Assert.That(c.X == 32);
            Assert.That(c.Y == 32);
            Assert.That(c.Name == "Livre");
            Assert.That(c.Speech == "Un indice ? Son nom est François !");
        }

        [Test]
        public void Level_can_create_several_clue_and_return_several_speech_different()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c1 = l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !");
            Clue c2 = l.CreateClue(t, 52, 52, "Clue", "Tableau", "Un indice ? Son cheval est blanc !");

            Assert.That(c1.Speech, Is.EqualTo("Un indice ? Son nom est Henri !"));
            Assert.That(c2.Speech, Is.EqualTo("Un indice ? Son cheval est blanc !"));
            Assert.That(l.Clues.Contains(c1));
            Assert.That(l.Clues.Contains(c2));
        }

        [Test]
        public void Level_the_Clue_have_a_unique_name()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c = l.CreateClue(t, 16, 32, "Clue", "Livre", "Bouh");

            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_the_Clue_have_a_unique_speech()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c = l.CreateClue(t, 16, 32, "Clue", "Test", "Un indice ? Son nom est Henri !");

            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_created_if_his_position_is_negative()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Assert.Throws<ArgumentException>(() => l.CreateClue(t, -1, 0, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_created_outside_the_map()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Map m = new Map(l, 5, 5);

            Assert.Throws<ArgumentException>(() => l.CreateClue(t, 170, 170, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_two_Clue_cannot_be_create_on_the_same_position()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c1 = l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !");

            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_create_on_a_PNJ()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            PNJ p = l.CreatePNJ(g, 32, 32, "Test", "Hawke", "Hello world !");

            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_create_on_MainCharacter()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

           Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 16, 16, "Clue", "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_returns_correctly_his_hitbox()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Clue c = l.CreateClue(t, 32, 32, "Clue", "Livre", "Un indice ? Son nom est Henri !");

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
