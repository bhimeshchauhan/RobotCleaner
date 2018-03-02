namespace bhimesh.cint
{
    public class MoveCmd
    {
        private Moveto _moveto;

        public Moveto Moveto
        {
            get { return _moveto; }
        }

        private int _numsteps;
        public MoveCmd(Moveto moveto, int numsteps)
        {
            _moveto = moveto;
            _numsteps = numsteps;
        }

        public int numSteps
        {
            get { return _numsteps; }
        }
    }
}