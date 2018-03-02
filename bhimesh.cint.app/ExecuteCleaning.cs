namespace bhimesh.cint
{
    public class ExecuteCleaning
    {
        IReadin _readin;
        IParsein _parser;
        IRobotObj _robot;

        public ExecuteCleaning (IReadin readin, IParsein parser, IRobotObj robot)
        {
            _readin = readin;
            _parser = parser;
            _robot = robot;
        }

        public void Execute()
        {
            ExecuteOrder execClean = _parser.ReadCommands();
            int cleanedPos = _robot.ExecuteClear(execClean);
            _readin.Writeout(string.Format("=> Cleaned: {0}", cleanedPos));
        }
    }
}