using System;
using System.Collections.Generic;

namespace bhimesh.cint
{
    public enum Moveto
    {
        N, E, W, S
    }

    public class OfficeFloor
    {
        public static Coord Movetowards(Moveto moveto)
        {
            return _floorMapCoord[moveto];
        }

        private static Dictionary<Moveto, Coord> _floorMapCoord = new Dictionary<Moveto, Coord>
        {
            {Moveto.N, new Coord(0, 1)},
            {Moveto.E, new Coord(1, 0)},
            {Moveto.W, new Coord(-1, 0)},
            {Moveto.S, new Coord(0, -1)}
        };

        private static Dictionary<String, Moveto> _floorMapCoordName = new Dictionary<string, Moveto>
        {
            {"N", Moveto.N},
            {"E", Moveto.E},
            {"W", Moveto.W},
            {"S", Moveto.S}
        };

        public static Moveto GetMoveto(string m)
        {
            return _floorMapCoordName[m];
        }
    }
}