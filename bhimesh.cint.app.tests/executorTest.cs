using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;

namespace bhimesh.cint.app.tests
{
    [TestFixture]
    public class executorTest
    {
        Mock<IReadin> _mockReadin;
        Mock<IParsein> _mockParsein;
        Mock<IRobotObj> _mockRobotObj;

        [SetUp]
        public void TestInit()
        {
            _mockReadin = new Mock<IReadin>();
            _mockParsein = new Mock<IParsein>();
            _mockRobotObj = new Mock<IRobotObj>();
        }

        [Test]
        public void display_PlacesCleaned()
        {
            ExecuteCleaning order = new ExecuteCleaning(_mockReadin.Object, _mockParsein.Object, _mockRobotObj.Object);
            _mockParsein.Setup(x => x.ReadCommands()).Returns(new ExecuteOrder( new Coord(0,0), new List<MoveCmd>()));
            _mockRobotObj.Setup(x => x.ExecuteClear(It.IsAny<ExecuteOrder>())).Returns(5420);
            _mockReadin.Setup(x => x.Writeout(It.IsAny<String>()));
            order.Execute();
            _mockReadin.Verify(O => O.Writeout(It.Is< String > (s => s == "=> Cleaned: 5420")), Times.Once);
        }
    }
}
