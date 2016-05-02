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
            Theme t = new Theme(g,"Theme");
            Level l = new Level(t,"Level");
            PNJ p = new PNJ(g, l, 0, 0, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);
            string speech = "Hello world !";
            Assert.That(p.Speech, Is.EqualTo(speech)); //Verify if the speech is correct
            Assert.That(p.Level, Is.EqualTo(l));
            Assert.That(l._pnj.Contains(p));
        }

        [Test]
        public void PNJ_return_correct_coordinate() //Return position of PNJ
        {
            Game g = new Game();
            Theme t = new Theme(g, "Theme");
            Level l = new Level(t, "Level");
            PNJ p = new PNJ(g, l, 0, 0, "test", "Hawke", "Hello world !");
            l._pnj.Add(p);
            Assert.That(p.positionX, Is.EqualTo(0));
            Assert.That(p.positionY, Is.EqualTo(0));
            Assert.That(l._pnj.Contains(p));
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
        public void MainCharacter_can_move_up()
        {
            Game g = new Game();
            MainCharacter mC = new MainCharacter(g, 0, 0, "test", "Judd");

            for(int i = 0; i < 10; i++)
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
    }
}
