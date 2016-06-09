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
        Game g;
        Theme t;
        Level l;
        PNJ p;

        [TestFixtureSetUp]
        public void PNJSetUp()
        {
            g = new Game();
            t = g.CreateTheme("Theme");
            l = t.CreateLevel("Level");
            p = l.Pnj;
        }

        [Test]
        public void PNJ_can_be_created_with_a_context_a_name_and_a_speech()
        {
            string speech = "Hello world !";
            Assert.That(p.Speech, Is.EqualTo(speech)); //Verify if the speech is correct
            Assert.That(p.Level, Is.EqualTo(l));
            Assert.That(l.Pnjs.Contains(p));
        }

        [Test]
        public void PNJ_can_be_created_with_a_unique_name()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreatePNJ(g, 32, 32, CharacterEnum.MCFACE, "Hawke", "Hello world !"));
        }

        [Test]
        public void PNJ_cannot_be_created_if_his_position_is_negative()
        {
            Assert.Throws<ArgumentException>(() => l.CreatePNJ(g, -1, 0, CharacterEnum.MCFACE, "Hawke", "Hello world !"));
        }

        [Test]
        public void PNJ_return_correct_coordinate() //Return position of PNJ
        {
            Assert.That(p.positionX, Is.EqualTo(16));
            Assert.That(p.positionY, Is.EqualTo(128));
            Assert.That(l.Pnjs.Contains(p));
        }

        [Test]
        public void PNJ_return_speech_correctly()
        {
            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(l.Pnjs.Contains(p));
        }

        [Test]
        public void PNJ_We_can_created_two_pnj_different_and_they_return_two_speech_different()
        {
            PNJ n = l.CreatePNJ(g, 32, 32, CharacterEnum.MCFACE, "Marth", "You have to search the good questions !");

            Assert.That(p.Speech, Is.EqualTo("Hello world !"));
            Assert.That(n.Speech, Is.EqualTo("You have to search the good questions !"));
            Assert.That(l.Pnjs.Contains(p));
            Assert.That(l.Pnjs.Contains(n));
        }

        [Test]
        public void PNJ_hitbox_return_good_value()
        {
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
            Assert.Throws<ArgumentException>(() => l.CreatePNJ(g, 15, 15, CharacterEnum.GUARDFACE, "Hawke", "Hello world !"));
        }

        [Test]
        public void PNJ_have_a_unique_speech()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreatePNJ(g, 32, 32, CharacterEnum.GUARDFACE, "Hawke", "Hello world !"));
        }
    }

    [TestFixture]
    public class MainCharacterTests
    {
        Game g;
        Theme t;
        Level l;
        MainCharacter mC;

        [TestFixtureSetUp]
        public void MainCharacterSetUp()
        {
            g = new Game();
            t = g.CreateTheme("Theme");
            l = t.CreateLevel("Level");
            mC = l.MainCharacter;
        }

        [Test]
        public void MainCharacter_have_a_name_and_a_speed()
        {
            MainCharacter mC = new MainCharacter(g, l, 16, 16, CharacterEnum.MCFACE, "Judd");
            string name = "Judd";
            int speed = 6;

            Assert.That(l.MainCharacter.Name, Is.EqualTo(name));
            Assert.That(l.MainCharacter.Speed, Is.EqualTo(speed));
        }

        [Test]
        public void MainCharacter_cannot_be_created_if_his_position_is_negative()
        {
            Assert.Throws<ArgumentException>(() => l.MainCharacter.positionX = -1);
            Assert.Throws<ArgumentException>(() => new MainCharacter(g, l, -1, 0, CharacterEnum.MCFACE, "Judd"));
        }

        [Test]
        public void MainCharacter_can_move_down()
        {            
            for (int i = 0; i < 10; i++)
                l.MainCharacter.Movement(KeyEnum.down);

            Assert.That(l.MainCharacter.positionY, Is.EqualTo(76));
        }

        [Test]
        public void MainCharacter_can_move_right()
        {
            MainCharacter mC = new MainCharacter(g, l, 100, 0, CharacterEnum.MCFACE, "Judd");
            for (int i = 0; i < 10; i++)
                l.MainCharacter.Movement(KeyEnum.right);

            Assert.That(l.MainCharacter.positionX, Is.EqualTo(76));
        }

        [Test]
        [Ignore("Hitbox not correct for the moment")]
        public void MainCharacter_cannot_move_outside_the_map()
        {
            for (int i = 32; i > 10; i--)
            {
                l.MainCharacter.Movement(KeyEnum.left);
            }

            Assert.That(l.MainCharacter.positionX == 16);
        }

        [Test]
        [Ignore("We have to found a new operation")]
        public void MainCharacter_cannot_move_outside_the_map_by_the_right()
        {
            Map m = new Map(l, 5, 5);

            for (int i = 0; i < 1000; i++)
            {
                l.MainCharacter.Movement(KeyEnum.right);
            }

            Assert.That(l.MainCharacter.positionX == 144);
        }

        [Test]
        [Ignore("Not complete")]
        public void MainCharacter_cannot_move_if_he_collide_a_PNJ_by_the_botom()
        {
            PNJ pnj = l.CreatePNJ(g, 32, 32, CharacterEnum.GUARDFACE, "Edward", "Bonjour");

            for (int i = 0; i < 10; i++)
            {
                if ((mC.HitBox.yA != pnj.HitBox.yD) && (mC.HitBox.yB != pnj.HitBox.yC))
                {
                    mC.Movement(KeyEnum.up);
                }
            }

            Assert.That(mC.positionX == 16 && mC.positionY == 16);
        }

        [Test]
        public void MainCharacter_cannot_have_more_than_three_life()
        {
            Assert.Throws<ArgumentException>(() => l.MainCharacter.Life++);
        }

        [Test]
        public void MainCharacter_game_over_return_false_if_life_equal_zero()
        {            
            Assert.That(l.MainCharacter.GameOver, Is.EqualTo(true));
            l.MainCharacter.Life = 0;
            Assert.That(l.MainCharacter.GameOver, Is.EqualTo(false));
        }

        [Test]
        [Ignore("Not complete")]
        public void MainCharacter_hitbox_return_good_value()
        {
            MainCharacter mC = new MainCharacter(g, l, 0, 0, CharacterEnum.MCFACE, "Judd");
            Assert.That(mC.HitBox.xA, Is.EqualTo(0));
            Assert.That(mC.HitBox.yA, Is.EqualTo(0));
            Assert.That(mC.HitBox.xB, Is.EqualTo(32));
            Assert.That(mC.HitBox.yB, Is.EqualTo(0));
            Assert.That(mC.HitBox.xC, Is.EqualTo(32));
            Assert.That(mC.HitBox.yC, Is.EqualTo(32));
            Assert.That(mC.HitBox.xD, Is.EqualTo(0));
            Assert.That(mC.HitBox.yD, Is.EqualTo(32));
        }

        [Test]
        [Ignore("Not complete")]
        public void MainCharacter_cannot_be_created_with_his_hitbox_outside_the_map()
        {
            Assert.Throws<ArgumentException>(() => l.CreateMain(t, 15, 15, CharacterEnum.MCFACE, "Judd"));
        }

        [Test]
        public void MainCharacter_cannot_be_create_two_times()
        {
            Assert.Throws<InvalidOperationException>(() => l.CreateMain(t, 16, 16, CharacterEnum.MCFACE, "Judd"));
        }         
    }
}
