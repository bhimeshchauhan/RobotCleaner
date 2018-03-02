
using NUnit.Framework;

namespace bhimesh.cint.app.tests
{
    [TestFixture]
    public class OfficeFloorTest
    {
        [Test]
        public void NorthStep_isCorrect()
        {
            Coord answer = OfficeFloor.Movetowards(Moveto.N);

            Assert.AreEqual(0, answer.XPos);
            Assert.AreEqual(1, answer.YPos);

        }

        [Test]
        public void EastStep_isCorrect()
        {
            Coord answer = OfficeFloor.Movetowards(Moveto.E);

            Assert.AreEqual(1, answer.XPos);
            Assert.AreEqual(0, answer.YPos);

        }

        [Test]
        public void WestStep_isCorrect()
        {
            Coord answer = OfficeFloor.Movetowards(Moveto.W);

            Assert.AreEqual(-1, answer.XPos);
            Assert.AreEqual(0, answer.YPos);

        }

        [Test]
        public void SouthStep_isCorrect()
        {
            Coord answer = OfficeFloor.Movetowards(Moveto.S);

            Assert.AreEqual(0, answer.XPos);
            Assert.AreEqual(-1, answer.YPos);

        }
    }
}
