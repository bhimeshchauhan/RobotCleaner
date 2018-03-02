using System.Collections.Generic;

namespace bhimesh.cint
{
    public class Parsein : IParsein
    {
        IReadin _ireadin;
        public Parsein(IReadin ireadin)
        {
            _ireadin = ireadin; 
        }

        public int NumCommands()
        {
            return int.Parse(_ireadin.Readin());
        }

        public MoveCmd ReadMovecd()
        {
            string cmdin = _ireadin.Readin();
            string[] cmdArr = cmdin.Split(' ');
            return new MoveCmd(OfficeFloor.GetMoveto(cmdArr[0]), int.Parse(cmdArr[1]));
        }

        public Coord StartingCoord()
        {
            string cmdin = _ireadin.Readin();
            string[] coordArr = cmdin.Split(' ');
            int x_coord = int.Parse(coordArr[0]);
            int y_coord = int.Parse(coordArr[1]);
            return new Coord(x_coord, y_coord);
        }

        public ExecuteOrder ReadCommands()
        {
            int numCmds = this.NumCommands();
            Coord startPos = this.StartingCoord();
            List<MoveCmd> cmd = new List<MoveCmd>();
            while (cmd.Count < numCmds)
            {
                cmd.Add(this.ReadMovecd());
            }
            ExecuteOrder execorder = new ExecuteOrder(startPos, cmd);
            return execorder;
        }
    }
}
