using System.Collections.Generic;

namespace bhimesh.cint
{
    public class Robotobj : IRobotObj
    {
        private Coord _currentPos;
        private Dictionary<Coord, bool> _cleanOffice;

        public Robotobj()
        {
            _cleanOffice = new Dictionary<Coord, bool>();
        }

        private void CleanExecCurrentPos()
        {
            _cleanOffice[_currentPos] = true;
        }

        public Coord CurrentPos
        {
            get { return _currentPos; }
            private set
            {
                _currentPos = value;
                CleanExecCurrentPos();
            }
        }

        public void Movetowards(Moveto movetoward, int numSteps)
        {
            Coord movetowards = OfficeFloor.Movetowards(movetoward);
            for (int i = 0; i < numSteps; i++)
            {
                CurrentPos = new Coord(_currentPos.XPos + movetowards.XPos, _currentPos.YPos + movetowards.YPos);
            }
        }

        public int ExecuteClear(ExecuteOrder executeclean)
        {
            JumpTo(executeclean.StartingPos);
            foreach(var cmd in executeclean.cmd)
            {
                this.Movetowards(cmd.Moveto, cmd.numSteps);
            }
            return _cleanOffice.Count;
        }

        public void JumpTo(Coord pos)
        {
            CurrentPos = pos;
        }
        
    }
}