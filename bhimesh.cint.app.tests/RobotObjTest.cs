using NUnit.Framework;
using System.Collections.Generic;

namespace bhimesh.cint.app.tests
{
    [TestFixture]
    class RobotObjTest
    {

        [Test]
        public void Jumpto_Test()
        {
            Robotobj robot = new Robotobj();
            robot.JumpTo(new Coord(-1000, 2000));

            Assert.AreEqual(-1000, robot.CurrentPos.XPos);
            Assert.AreEqual(2000, robot.CurrentPos.YPos);
        }
        
        [Test]
        public void MovememntNorth_Test()
        {
            Robotobj robot = new Robotobj();
            robot.JumpTo(new Coord(0, 0));
            robot.Movetowards(Moveto.N, 1500);

            Assert.AreEqual(0, robot.CurrentPos.XPos);
            Assert.AreEqual(1500, robot.CurrentPos.YPos);
        }

        [Test]
        public void MovementEast_Test()
        {
            Robotobj robot = new Robotobj();
            robot.JumpTo(new Coord(0, 0));

            robot.Movetowards(Moveto.E, 1500);

            Assert.AreEqual(1500, robot.CurrentPos.XPos);
            Assert.AreEqual(0, robot.CurrentPos.YPos);
        }

        [Test]
        public void MovmentWest_Test()
        {
            Robotobj robot = new Robotobj();
            robot.JumpTo(new Coord(0, 0));
            robot.Movetowards(Moveto.W, 1500);

            Assert.AreEqual(-1500, robot.CurrentPos.XPos);
            Assert.AreEqual(0, robot.CurrentPos.YPos);
        }

        [Test]
        public void MovementSouth_Test()
        {
            Robotobj robot = new Robotobj();
            robot.JumpTo(new Coord(0, 0));
            robot.Movetowards(Moveto.S, 1500);

            Assert.AreEqual(0, robot.CurrentPos.XPos);
            Assert.AreEqual(-1500, robot.CurrentPos.YPos);
        }

        [Test]
        public void Boundary_Test()
        {
            List<MoveCmd> commands = new List<MoveCmd>();
            commands.Add(new MoveCmd(Moveto.E, 4000));
            ExecuteOrder execClean = new ExecuteOrder(new Coord(-2000, 2000), commands);

            Robotobj robot = new Robotobj();
            int places = robot.ExecuteClear(execClean);

            Assert.AreEqual(2000, robot.CurrentPos.XPos);
            Assert.AreEqual(2000, robot.CurrentPos.YPos);
            Assert.AreEqual(4001, places);
        }

        [Test]
        public void AreaCoverage_Test()
        {
            Robotobj robot = new Robotobj();

            List<MoveCmd> commands = new List<MoveCmd>();
            commands.Add(new MoveCmd(Moveto.N, 200000));
            commands.Add(new MoveCmd(Moveto.E, 200000));
            commands.Add(new MoveCmd(Moveto.S, 200000));
            commands.Add(new MoveCmd(Moveto.W, 200000));
            ExecuteOrder execClean = new ExecuteOrder(new Coord(-100000, 100000), commands);
            int coordvisited = robot.ExecuteClear(execClean);

            Assert.AreEqual(-100000, robot.CurrentPos.XPos);
            Assert.AreEqual(100000, robot.CurrentPos.YPos);
            Assert.AreEqual(800000, coordvisited);
        }

        [Test]
        public void AvoidRepeats_Test()
        {
            Robotobj robot = new Robotobj();

            List<MoveCmd> commands = new List<MoveCmd>();
            commands.Add(new MoveCmd(Moveto.E, 80));
            commands.Add(new MoveCmd(Moveto.S, 25));
            commands.Add(new MoveCmd(Moveto.W, 60));
            commands.Add(new MoveCmd(Moveto.S, 22));
            commands.Add(new MoveCmd(Moveto.E, 29));
            commands.Add(new MoveCmd(Moveto.N, 36));
            ExecuteOrder session = new ExecuteOrder(new Coord(0, 0), commands);
            int places = robot.ExecuteClear(session);

            Assert.AreEqual(80 - 60 + 29, robot.CurrentPos.XPos);
            Assert.AreEqual(36 - 25 - 22, robot.CurrentPos.YPos);
            Assert.AreEqual(252, places);
        }

        [Test]
        public void InlineBoundary_Test()
        {
            Robotobj robot = new Robotobj();

            List<MoveCmd> commands = new List<MoveCmd>();
            commands.Add(new MoveCmd(Moveto.E, 1500));
            commands.Add(new MoveCmd(Moveto.N, 1500));
            ExecuteOrder execClean = new ExecuteOrder(new Coord(-15000, -15000), commands);
            int places = robot.ExecuteClear(execClean);

            Assert.AreEqual(-13500, robot.CurrentPos.XPos);
            Assert.AreEqual(-13500, robot.CurrentPos.YPos);
            Assert.AreEqual(3001, places);
        }

    }
}
