using System;

namespace bhimesh.cint
{
    class Readin : IReadin
    {
        public void Writeout(string output)
        {
            Console.WriteLine(output);
            //To sustain the output
            Console.ReadLine();
        }

        string IReadin.Readin()
        {
            return Console.ReadLine();
        }
    }
}
