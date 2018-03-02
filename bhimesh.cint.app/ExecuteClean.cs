using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace bhimesh.cint
{
    public class ExecuteClean
    {
        private Coord _startPos;
        private List<MoveCmd> _cmd;

        public Coord StartingPos
        {
            get { return _startPos; }
        }
        public List<MoveCmd> cmd
        {
            get { return _cmd; }
        }
        public ExecuteClean(Coord startPos, List<MoveCmd> cmd)
        {
            this._startPos = startPos;
            this._cmd = cmd;
        }
    }
}