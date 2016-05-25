using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.HistoryTreasures.Tests
{
    [TestFixture]
    public class PNJTests
    {
        [Test]
        public void PNJ_can_be_created_with_a_context_a_name_and_a_speech()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");
            
            string speech = "Hello world !";
            Assert.That(p.Speech, Is.EqualTo(speech)); //Verify if the speech is correct
            Assert.That(p.Level, Is.EqualTo(l));
            Assert.That(l.PNJ.Contains(p));
        }

        [Test]
        public void PNJ_can_be_created_with_a_unique_name()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");

            Assert.Throws<InvalidOperationException>(() => l.CreatePNJ(g, 32, 32, "Test", "Hawke", "Hello world !"));
        }

        [Test]
        public void PNJ_cannot_be_created_if_his_position_is_negative()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Assert.Throws<ArgumentException>(() => l.CreatePNJ(g, -1, 0, "Test", "Hawke", "Hello world !"));
        }

        [Test]
        public void PNJ_return_correct_coordinate() //Return position of PNJ
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");
            
            Assert.That(p.positionX, Is.EqualTo(16));
            Assert.That(p.positionY, Is.EqualTo(16));
            Assert.That(l.PNJ.Contains(p));
        }

        [Test]
        public void PNJ_return_speech_correctly()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");
            
            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(l.PNJ.Contains(p));
        }

        [Test]
        public void PNJ_We_can_created_two_pnj_different_and_they_return_two_speech_different()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            PNJ p = l.CreatePNJ(g, 0, 0, "test", "Hawke", "Hello world !");
            PNJ n = l.CreatePNJ(g, 15, 5, "test", "Marth", "You have to search the good questions !");

            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(n.Speech, Is.EqualTo("You have to search the good questions !"));
            Assert.That(l.PNJ.Contains(p));
            Assert.That(l.PNJ.Contains(n));
        }
    }

    [TestFixture]
    public class MainCharacterTests
    {
        [Test]
        public void MainCharacter_have_a_name_and_a_speed()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            string name = "Judd";
            int speed = 1;
            Assert.That(mC.Name, Is.EqualTo(name));
            Assert.That(mC.Speed, Is.EqualTo(speed));
        }

        [Test]
        public void MainCharacter_cannot_be_created_if_his_position_is_negative()
        {
            Game g = new Game();

            Assert.Throws<ArgumentException>(() => new MainCharacter(g, -1, 0, "test", "Judd"));
        }

        [Test]
        public void MainCharacter_can_move_up()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");

            for (int i = 0; i < 10; i++)
                mC.Movement(KeyEnum.up);

            Assert.That(mC.positionY, Is.EqualTo(10));
        }

        [Test]
        public void MainCharacter_can_move_left()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 10, 0, "test", "Judd");

            for (int i = 0; i < 10; i++)
                mC.Movement(KeyEnum.left);

            Assert.That(mC.positionX, Is.EqualTo(0));
        }

        [Test]
        public void MainCharacter_cannot_move_outside_the_map()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 32, 32, "test", "Judd");
            for (int i = 32; i > 10; i--)
            {
                mC.Movement(KeyEnum.left);
            }

            Assert.That(mC.positionX == 16);
        }

        [Test]
        public void MainCharacter_cannot_have_more_than_three_life()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Assert.Throws<ArgumentException>(() => mC.Life++);
        }

        [Test]
        public void MainCharacter_game_over_return_false_if_life_equal_zero()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Assert.That(mC.GameOver, Is.EqualTo(true));
            mC.Life = 0;
            Assert.That(mC.GameOver, Is.EqualTo(false));
        }

        [Test]
        public void MainCharacter_hitbox_return_good_value()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 32, 32, "test", "Judd");
            Assert.That(mC.HitBox.xA, Is.EqualTo(16));
            Assert.That(mC.HitBox.yA, Is.EqualTo(32));
            Assert.That(mC.HitBox.xB, Is.EqualTo(48));
            Assert.That(mC.HitBox.yB, Is.EqualTo(32));
            Assert.That(mC.HitBox.xC, Is.EqualTo(48));
            Assert.That(mC.HitBox.yC, Is.EqualTo(16));
            Assert.That(mC.HitBox.xD, Is.EqualTo(16));
            Assert.That(mC.HitBox.yD, Is.EqualTo(16));
        }

        [Test]
        [Ignore("Not completed")]
        public void MainCharacter_cannot_move_if_he_collide_a_PNJ()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            PNJ pnj = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");

            l.MainCharacter.Movement(KeyEnum.up);

            Assert.That(l.MainCharacter.positionX == 32 && l.MainCharacter.positionY == 32);
        }

        [Test]
        public void MainCharacter_cannot_be_create_two_times()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Assert.Throws<InvalidOperationException>(() => l.CreateMain(t, 16, 16, "test", "judd"));
        }        
    }
}
