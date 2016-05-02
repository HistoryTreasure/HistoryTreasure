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
            Theme t = new Theme(g,"theme");
            Level l = new Level(t,"Level");
            PNJ p = new PNJ(l, 0, 0, "test", "Hawke", "Hello world !");
            string speech = "Hello world !";
            Assert.That(p.Speech, Is.EqualTo(speech)); //Verify creation of PNJ and if the speech is correct
            Assert.That(p.Level, Is.EqualTo(l));
        }
    }

    [TestFixture]
    public class MainCharacterTests
    {
        [Test]
        public void MainCharacter_have_a_name_and_a_speed()
        {
            MainCharacter mC = new MainCharacter(0, 0, "test", "Judd");
            string name = "Judd";
            int speed = 1;
            Assert.That(mC.Name, Is.EqualTo(name));
            Assert.That(mC.Speed, Is.EqualTo(speed));
        }
    }
}
