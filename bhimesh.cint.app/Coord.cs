using System;

namespace bhimesh.cint
{
    public class Coord
    {
        public int XPos
        {
            get { return _xypair.Item1; }
        }

        public int YPos
        {
            get { return _xypair.Item2; }

        }

        private Tuple<int, int> _xypair;

        public Coord(int xpos, int ypos)
        {
            _xypair = new Tuple<int, int>(xpos, ypos);
        }
        
        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Coord xycoord = (Coord)obj;
            return this._xypair.Equals(xycoord._xypair);
        }

        public override int GetHashCode()
        {
            return _xypair.GetHashCode();
        }
    }
}
