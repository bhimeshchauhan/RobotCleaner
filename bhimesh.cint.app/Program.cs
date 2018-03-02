namespace bhimesh.cint
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadin read = new Readin();
            IParsein parser = new Parsein(read);
            IRobotObj robotobj = new Robotobj();
            ExecuteCleaning execCleaning = new ExecuteCleaning(read, parser, robotobj);
            execCleaning.Execute();

        }
    }
}
