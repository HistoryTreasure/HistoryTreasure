using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.HistoryTreasures.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void T01_Character_can_be_created_and_have_a_name()
        {
            Character c = new Character(0, 0, "test", "Judd");
            string name = "Judd";
            Assert.That(c.Name, Is.EqualTo(name)); //We want to recover the name of the character
        }

        [Test]
        public void T02_Character_return_his_position()
        {
            Character c = new Character(0, 0, "test", "Judd");
            int positionX = 0;
            int positionY = 0;
            Assert.That(c.positionX, Is.EqualTo(positionX)); //Found position X
            Assert.That(c.positionY, Is.EqualTo(positionY)); //Found position Y
        }

        [Test]
        public void T03_Character_return_correctly_bitMapName()
        {
            Character c = new Character(0, 0, "test", "Judd");
            string bitMapName = "test";
            Assert.That(c.BitMapName, Is.EqualTo(bitMapName)); //Recover character by his BitMapName
        }

        [Test]
        public void T04_PNJ_can_be_created_and_say_the_good_speech()
        {
            PNJ p = new PNJ(0, 0, "test", "Hawke", "Hello world !");
            string speech = "Hello world !";
            Assert.That(p.Speech, Is.EqualTo(speech)); //Verify creation of PNJ and if the speech is correct
        }

        [Test]
        public void T05_MainCharacter_had_name_and_have_a_speed()
        {
            MainCharacter mC = new MainCharacter(0, 0, "test", "Judd");
            string name = "Judd";
            int speed = 1;
            Assert.That(mC.Name, Is.EqualTo("Judd"));
            Assert.That(mC.Speed, Is.EqualTo(1));
        }
    }
}
