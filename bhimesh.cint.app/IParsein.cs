namespace bhimesh.cint
{
    public interface IParsein
    {
        int NumCommands();
        Coord StartingCoord();
        MoveCmd ReadMovecd();
        ExecuteOrder ReadCommands();
    }
}