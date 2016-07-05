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
            t = g.Themes[0];
        }

        [Test]
        public void Themes_are_created_and_have_a_name_and_is_correctly_add_to_his_list()
        {
            string name = "1";

            Assert.That(t.Name, Is.EqualTo(name));
            Assert.That(g.Themes.Contains(t));
        }

        [Test]
        public void Themes_is_finish_if_all_levels_are_complete()
        {
            foreach (Level l in t.Levels)
            {
                l.IsFinish = true;
            }

            t.FinishTheme();

            Assert.That(g.Themes[0].IsFinish == true);
        }

        [Test]
        public void A_theme_cannot_be_created_two_times_with_same_name()
        {
            Assert.Throws<InvalidOperationException>(() => g.CreateTheme("1"));
        }
    }

    [TestFixture]
    public class LevelTests
    {
        Game g;
        Theme t;
        Level l;
        Clue c;
        PNJ p;
        MainCharacter mC;
        
        [TestFixtureSetUp]
        public void LevelSetUp()
        {
            g = new Game();
            t = g.Themes[0];
            l = t.Levels[0];
            c = l.Clues[0];
            p = l.Pnjs[0];
            mC = l.MainCharacter;
        }

        [Test]
        public void Levels_are_created_and_have_a_name_and_is_correctly_add_to_his_list()
        {
            string name = "1_1";

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
            Assert.That(l.Pnjs.Contains(p));
        }

        [Test]
        public void A_level_cannot_be_created_two_times_with_same_name()
        {
            Assert.Throws<InvalidOperationException>(() => t.CreateLevel("1_1"));
        }

        [Test]
        public void Level_method_interaction_work_between_MainCharacter_and_PNJ()
        {
            l.MainCharacter.positionX = l.Pnjs[0].positionX;
            l.MainCharacter.positionY = l.Pnjs[0].positionY + 32;
            l.MainCharacter.HitBox.xA = l.MainCharacter.positionX;
            l.MainCharacter.HitBox.yA = l.MainCharacter.positionY;

            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hawke: "+l.Pnjs[0].Speech));
        }

        [Test]
        public void Level_method_interaction_work_in_diagonal_between_MainCharacter_and_PNJ()
        {
            l.MainCharacter.positionX = l.Pnjs[0].positionX + 32;
            l.MainCharacter.positionY = l.Pnjs[0].positionY + 32;
            l.MainCharacter.HitBox.xA = l.MainCharacter.positionX;
            l.MainCharacter.HitBox.yA = l.MainCharacter.positionY;

            Assert.That(l.InteractionWithPNJ(KeyEnum.action), Is.EqualTo("Hawke: "+l.Pnjs[0].Speech));
        }

        [Test]
        public void Level_method_interaction_works_between_MainCharacter_and_Clue()
        {
            l.MainCharacter.positionX = l.Clues[0].X;
            l.MainCharacter.positionY = l.Clues[0].Y + 32;
            l.MainCharacter.HitBox.xA = l.MainCharacter.positionX;
            l.MainCharacter.HitBox.yA = l.MainCharacter.positionY;

            Assert.That(l.InteractionsWithClue(KeyEnum.action), Is.EqualTo("Book: "+l.Clues[0].Speech));
        }

        [Test]
        public void Levels_return_correctly_main_character()
        {
            Assert.That(l.MainCharacter.Game == g);
            Assert.That(mC.CharacterBitmapName == CharacterEnum.MCFACE);
            Assert.That(mC.Name == "Judd");
        }

        [Test]
        public void Levels_returns_correctly_Clue()
        {
            Assert.That(c.LCtx == l);
            Assert.That(c.X == 608);
            Assert.That(c.Y == 160);
            Assert.That(c.Name == "Book");
            Assert.That(c.Speech == "L'histoire se souviendra de l'an 17... le reste est illisible");
        }

        [Test]
        public void Level_can_create_several_clue_and_return_several_speech_different()
        {
            Clue c2 = l.Clues[1];

            Assert.That(c.Speech, Is.EqualTo("L'histoire se souviendra de l'an 17... le reste est illisible"));
            Assert.That(c2.Speech, Is.EqualTo("La bastille fut prise 11 ans avant la fin du siecle"));
            Assert.That(l.Clues.Contains(c));
            Assert.That(l.Clues.Contains(c2));
        }

        [Test]
        public void Level_the_Clue_have_a_unique_name()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, ClueEnum.LIVRE, "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_the_Clue_have_a_unique_speech()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 32, 32, ClueEnum.LIVRE, "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_created_if_his_position_is_negative()
        {
            Assert.Throws<ArgumentException>(() => l.CreateClue(t, -1, 0, ClueEnum.LIVRE, "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_created_outside_the_map()
        {
            Map m = new Map(l);

            Assert.Throws<ArgumentException>(() => l.CreateClue(t, -1, -1, ClueEnum.LIVRE, "test", "test"));
        }

        [Test]
        public void Level_two_Clue_cannot_be_create_on_the_same_position()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 16, 32, ClueEnum.LIVRE, "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_create_on_a_PNJ()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 16, 128, ClueEnum.LIVRE, "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_cannot_be_create_on_MainCharacter()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateClue(t, 16, 16, ClueEnum.LIVRE, "Livre", "Un indice ? Son nom est Henri !"));
        }

        [Test]
        public void Level_Clue_returns_correctly_his_hitbox()
        {
            Assert.That(c.HitBox.xD, Is.EqualTo(608));
            Assert.That(c.HitBox.yD, Is.EqualTo(192));
        }
    }
}
