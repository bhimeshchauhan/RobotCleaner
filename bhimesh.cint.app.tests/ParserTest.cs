using NUnit.Framework;
using Moq;

namespace bhimesh.cint.test
{
    [TestFixture]
    class ParserTest
    {
        Mock<IReadin> _mockReadin;

        [SetUp]
        public void TestInit()
        {
            _mockReadin = new Mock<IReadin>();
        }

        [Test]
        public void ReadingData_isInteger()
        {
            Parsein parseTest = new Parsein(_mockReadin.Object);
            _mockReadin.Setup(x => x.Readin()).Returns("52");
            int answer = parseTest.NumCommands();

            Assert.AreEqual(52, answer);
        }

        [Test]
        public void ReadingData_isStartPos()
        {
            Parsein parseTest = new Parsein(_mockReadin.Object);
            _mockReadin.Setup(x => x.Readin()).Returns("5987 2654");
            Coord answer = parseTest.StartingCoord();

            Assert.AreEqual(5987, answer.XPos);
            Assert.AreEqual(2654, answer.YPos);
        }

        [Test]
        public void ReadingData_isMoveCmd()
        {
            Parsein parseTest = new Parsein(_mockReadin.Object);
            _mockReadin.Setup(x => x.Readin()).Returns("E 456");
            MoveCmd answer = parseTest.ReadMovecd();

            Assert.AreEqual(Moveto.E, answer.Moveto);
            Assert.AreEqual(456, answer.numSteps);
        }

        [Test]
        public void ReadingData_isInOrder()
        {
            Parsein parseTest = new Parsein(_mockReadin.Object);
            _mockReadin.SetupSequence(x => x.Readin()).Returns("5")
                .Returns("789 -852")
                .Returns("N 789")
                .Returns("E 456")
                .Returns("W 123")
                .Returns("W 159")
                .Returns("S 753");
            ExecuteOrder answer = parseTest.ReadCommands();
            Assert.AreEqual(789, answer.StartingPos.XPos);
            Assert.AreEqual(-852, answer.StartingPos.YPos);
            Assert.AreEqual(5, answer.cmd.Count);

            Assert.AreEqual(Moveto.N, answer.cmd[0].Moveto);
            Assert.AreEqual(789, answer.cmd[0].numSteps);

            Assert.AreEqual(Moveto.E, answer.cmd[1].Moveto);
            Assert.AreEqual(456, answer.cmd[1].numSteps);

            Assert.AreEqual(Moveto.W, answer.cmd[2].Moveto);
            Assert.AreEqual(123, answer.cmd[2].numSteps);

            Assert.AreEqual(Moveto.W, answer.cmd[3].Moveto);
            Assert.AreEqual(159, answer.cmd[3].numSteps);

            Assert.AreEqual(Moveto.S, answer.cmd[4].Moveto);
            Assert.AreEqual(753, answer.cmd[4].numSteps);
        }
    }
}
