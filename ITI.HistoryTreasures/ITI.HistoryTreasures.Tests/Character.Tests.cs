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
            PNJ p = l.Pnj;

            string speech = "Hello world !";
            Assert.That(p.Speech, Is.EqualTo(speech)); //Verify if the speech is correct
            Assert.That(p.Level, Is.EqualTo(l));
            Assert.That(l.Pnjs.Contains(p));
        }

        [Test]
        public void PNJ_can_be_created_with_a_unique_name()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.Pnj;

            Assert.Throws<InvalidOperationException>(() => l.CreatePNJ(g, 32, 32, CharacterEnum.MCFACE, "Hawke", "Hello world !"));
        }

        [Test]
        public void PNJ_cannot_be_created_if_his_position_is_negative()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Assert.Throws<ArgumentException>(() => l.CreatePNJ(g, -1, 0, CharacterEnum.MCFACE, "Hawke", "Hello world !"));
        }

        [Test]
        public void PNJ_return_correct_coordinate() //Return position of PNJ
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.Pnj;

            Assert.That(p.positionX, Is.EqualTo(16));
            Assert.That(p.positionY, Is.EqualTo(128));
            Assert.That(l.Pnjs.Contains(p));
        }

        [Test]
        public void PNJ_return_speech_correctly()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.Pnj;


            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(l.Pnjs.Contains(p));
        }

        [Test]
        public void PNJ_We_can_created_two_pnj_different_and_they_return_two_speech_different()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            PNJ p = l.Pnj;
            PNJ n = l.CreatePNJ(g, 32, 32, CharacterEnum.MCFACE, "Marth", "You have to search the good questions !");

            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(n.Speech, Is.EqualTo("You have to search the good questions !"));
            Assert.That(l.Pnjs.Contains(p));
            Assert.That(l.Pnjs.Contains(n));
        }

        [Test]
        public void PNJ_hitbox_return_good_value()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            PNJ p = l.Pnj;

            Assert.That(p.HitBox.xA, Is.EqualTo(0));
            Assert.That(p.HitBox.yA, Is.EqualTo(128));
            Assert.That(p.HitBox.xB, Is.EqualTo(32));
            Assert.That(p.HitBox.yB, Is.EqualTo(128));
            Assert.That(p.HitBox.xC, Is.EqualTo(32));
            Assert.That(p.HitBox.yC, Is.EqualTo(144));
            Assert.That(p.HitBox.xD, Is.EqualTo(0));
            Assert.That(p.HitBox.yD, Is.EqualTo(144));
        }

        [Test]
        public void PNJ_cannot_be_created_with_his_hitbox_outside_the_map()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Assert.Throws<ArgumentException>(() => new PNJ(g, l, 15, 15, CharacterEnum.MCFACE, "Hawke", "Hello world !"));
        }

        /*[Test]
        [Ignore("Not complete at all")]
        public void PNJ_cannot_be_create_on_a_wall()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 16, 16, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 16, 16, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);

            Assert.That(p.HitBox, Is.EqualTo(p));
        }*/
    }

    [TestFixture]
    public class MainCharacterTests
    {
        [Test]
        public void MainCharacter_have_a_name_and_a_speed()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 16, 16, CharacterEnum.MCFACE, "Judd");
            string name = "Judd";
            int speed = 1;
            Assert.That(mC.Name, Is.EqualTo(name));
            Assert.That(mC.Speed, Is.EqualTo(speed));
        }

        [Test]
        public void MainCharacter_cannot_be_created_if_his_position_is_negative()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            Assert.Throws<ArgumentException>(() => new MainCharacter(g, l, -1, 0, CharacterEnum.MCFACE, "Judd"));
        }

        [Test]
        public void MainCharacter_can_move_up()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 100, 100, CharacterEnum.MCFACE, "Judd");

            for (int i = 0; i < 10; i++)
                mC.Movement(KeyEnum.up);

            Assert.That(mC.positionY, Is.EqualTo(40));
        }

        [Test]
        public void MainCharacter_can_move_left()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 100, 0, CharacterEnum.MCFACE, "Judd");

            for (int i = 0; i < 10; i++)
                mC.Movement(KeyEnum.left);

            Assert.That(mC.positionX, Is.EqualTo(40));
        }

        [Test]
        [Ignore("Hitbox not correct for the moment")]
        public void MainCharacter_cannot_move_outside_the_map()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 32, 32, CharacterEnum.MCFACE, "Judd");
            for (int i = 32; i > 10; i--)
            {
                mC.Movement(KeyEnum.left);
            }

            Assert.That(mC.positionX == 16);
        }

        [Test]
        public void MainCharacter_cannot_move_outside_the_map_by_the_right()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            Map m = new Map(l, 5, 5);

            for (int i = 0; i < 1000; i++)
            {
                l.MainCharacter.Movement(KeyEnum.right);
            }

            Assert.That(l.MainCharacter.positionX == 144);
        }

        [Test]
        public void MainCharacter_cannot_move_if_he_collide_a_PNJ_by_the_botom()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");

            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 32, 32, CharacterEnum.MCFACE, "Judd");
            PNJ pnj = l.CreatePNJ(g, 48, 32, CharacterEnum.MCFACE, "Hawke", "coucou");

            for (int i = 0; i < 10; i++)
            {
                if ((mC.HitBox.yA != pnj.HitBox.yD) && (mC.HitBox.yB != pnj.HitBox.yC))
                {
                    mC.Movement(KeyEnum.up);
                }
            }

            Assert.That(mC.positionX == 32 && mC.positionY == 48);
        }

        [Test]
        public void MainCharacter_cannot_have_more_than_three_life()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 16, 16, CharacterEnum.MCFACE, "Judd");
            Assert.Throws<ArgumentException>(() => mC.Life++);
        }

        [Test]
        public void MainCharacter_game_over_return_false_if_life_equal_zero()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 16, 16, CharacterEnum.MCFACE, "Judd");
            Assert.That(mC.GameOver, Is.EqualTo(true));
            mC.Life = 0;
            Assert.That(mC.GameOver, Is.EqualTo(false));
        }

        [Test]
        public void MainCharacter_hitbox_return_good_value()
        {
            Game g = new Game();
            Theme t = g.CreateTheme(("Theme"));
            Level l = t.CreateLevel("Level");
            MainCharacter mC = new MainCharacter(g, l, 32, 32, CharacterEnum.MCFACE, "Judd");
            Assert.That(mC.HitBox.xA, Is.EqualTo(16));
            Assert.That(mC.HitBox.yA, Is.EqualTo(32));
            Assert.That(mC.HitBox.xB, Is.EqualTo(48));
            Assert.That(mC.HitBox.yB, Is.EqualTo(32));
            Assert.That(mC.HitBox.xC, Is.EqualTo(48));
            Assert.That(mC.HitBox.yC, Is.EqualTo(48));
            Assert.That(mC.HitBox.xD, Is.EqualTo(16));
            Assert.That(mC.HitBox.yD, Is.EqualTo(48));
        }

        [Test]
        public void MainCharacter_cannot_be_created_with_his_hitbox_outside_the_map()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            Assert.Throws<ArgumentException>(() => new MainCharacter(g, l, 15, 15, CharacterEnum.MCFACE, "Judd"));
        }

        /*[Test]
        [Ignore("Not complete at all")]
        public void MainCharacter_cannot_be_create_on_a_wall()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            
            Level l = t.CreateLevel("Level");
            PNJ pnj = l.CreatePNJ(g, 16, 16, "Test", "Hawke", "Hello world !");
            mc.Movement(KeyEnum.up);

            Assert.That(mc.positionX == 32 && mc.positionY == 32);
            
        }

        [Test]
        public void MainCharacter_cannot_be_create_two_times()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");

            Assert.Throws<InvalidOperationException>(() => l.CreateMain(t, 16, 16, "test", "judd"));
        }    */
    }
}
