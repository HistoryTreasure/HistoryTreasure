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
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 0, 0, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);
            string speech = "Hello world !";
            Assert.That(p.Speech, Is.EqualTo(speech)); //Verify if the speech is correct
            Assert.That(p.Level, Is.EqualTo(l));
            Assert.That(l._pnj.Contains(p));
        }

        [Test]
        public void PNJ_cannot_be_created_if_his_position_is_negative()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");

            Assert.Throws<ArgumentException>(() => new PNJ(g, l, -1, 0, "test", "Hawke", "Hello world"));
        }

        [Test]
        public void PNJ_return_correct_coordinate() //Return position of PNJ
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 0, 0, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);
            Assert.That(p.positionX, Is.EqualTo(0));
            Assert.That(p.positionY, Is.EqualTo(0));
            Assert.That(l._pnj.Contains(p));
        }

        [Test]
        public void PNJ_return_speech_correctly()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 0, 0, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);
            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(l._pnj.Contains(p));
        }

        [Test]
        public void PNJ_We_can_created_two_pnj_different_and_they_return_two_speech_different()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 0, 0, "test", "Hawke", "Hello world !");
            PNJ n = new PNJ(g, l, 15, 5, "test", "Marth", "And you failed !");
            l._pnj.Add(p);
            l._pnj.Add(n);
            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(n.Speech, Is.EqualTo("And you failed !"));
            Assert.That(l._pnj.Contains(p));
            Assert.That(l._pnj.Contains(n));
        }

        [Test]
        public void PNJ_can_created_two_PNJ_different_but_not_in_the_same_coordonate()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 15, 5, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);
            Assert.Throws<InvalidOperationException>(() => new PNJ(g, l, 15, 5, "test", "Marth", "And you failed !"));
            Assert.That(l._pnj.Contains(p));
        }

        [Test]
        public void PNJ_hitbox_return_good_value()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            PNJ p = new PNJ(g, l, 16, 16, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);
            Assert.That(p.HitBox.xA, Is.EqualTo(0));
            Assert.That(p.HitBox.yA, Is.EqualTo(16));
            Assert.That(p.HitBox.xB, Is.EqualTo(32));
            Assert.That(p.HitBox.yB, Is.EqualTo(16));
            Assert.That(p.HitBox.xC, Is.EqualTo(32));
            Assert.That(p.HitBox.yC, Is.EqualTo(32));
            Assert.That(p.HitBox.xD, Is.EqualTo(0));
            Assert.That(p.HitBox.yD, Is.EqualTo(32));
        }

        [Test]
        public void PNJ_cannot_be_created_with_his_hitbox_outside_the_map()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 16, 16, "test", "Judd");
            Level l = new Level(t, mC, "Level");

            Assert.Throws<ArgumentException>(() => new PNJ(g, l, 15, 15, "test", "Hawke", "Hello world !"));
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
            MainCharacter mC = new MainCharacter(g, 0, 20, "test", "Judd");

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
        public void MainCharacter_cannot_move_if_he_collide_a_PNJ_by_the_botom()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 48, 50, "test", "Judd");
            Level l = new Level(t, mC, "Level");
            g._themes.Add(t);
            t._levels.Add(l);
            PNJ pnj = new PNJ(g, l, 48, 32, "test", "Hawke", "coucou");
            l._pnj.Add(pnj);

            for (int i = 0; i < 10; i++)
            {
                if ((mC.HitBox.yA != pnj.HitBox.yD) && (mC.HitBox.yB != pnj.HitBox.yC))
                {
                    mC.Movement(KeyEnum.up);
                }
            }

            Assert.That(mC.positionX == 48 && mC.positionY == 48);
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
            Assert.That(mC.HitBox.yC, Is.EqualTo(48));
            Assert.That(mC.HitBox.xD, Is.EqualTo(16));
            Assert.That(mC.HitBox.yD, Is.EqualTo(48));
        }

        [Test]
        [Ignore("Not complete")]
        public void MainCharacter_cannot_be_created_two_times()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            MainCharacter mC = new MainCharacter(g, 48, 50, "test", "Judd");
            Level l = new Level(t, mC, "Level");

            Assert.Throws<InvalidOperationException>(() => new MainCharacter(g, 15, 15, "test", "Bob"));
        }

        [Test]
        public void MainCharacter_cannot_be_created_with_his_hitbox_outside_the_map()
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
           
            Assert.Throws<ArgumentException>(() => new MainCharacter(g, 15, 15, "test", "Judd"));
        }
    }
}
