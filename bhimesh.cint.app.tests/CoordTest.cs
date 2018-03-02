
using NUnit.Framework;

namespace bhimesh.cint.app.tests
{
    [TestFixture]
    public class CoordTest
    {
        [Test]
        public void sameCoord_isTrue()
        {
            Coord coord_n1 = new Coord(15, 35);
            Coord coord_n2 = new Coord(15, 35);
            bool answer = coord_n1.Equals(coord_n2);
            Assert.IsTrue(answer);
        }

        [Test]
        public void diffCoord_isFalse()
        {
            Coord coord_n1 = new Coord(15, 35);
            Coord coord_n2 = new Coord(125, -35);
            bool answer = coord_n1.Equals(coord_n2);
            Assert.IsFalse(answer);
        }

        [Test]
        public void nullCoord_isFalse()
        {
            Coord coord_n1 = new Coord(15, 35);
            bool answer = coord_n1.Equals(null);
            Assert.IsFalse(answer);
        }

    }
}
