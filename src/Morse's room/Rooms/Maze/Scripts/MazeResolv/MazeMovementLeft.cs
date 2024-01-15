namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv;

public class MazeMovementLeft : MazeStrategyInterface
{
    public void move(MazeResolv _mazeResolv)
    {
        int indexPlayerX = _mazeResolv.getIndexPlayerX();
        int indexPlayerY = _mazeResolv.getIndexPlayerY();
        int[][] maze = _mazeResolv.getMaze();
        _mazeResolv.setNextCase(maze[indexPlayerX][indexPlayerY-1]);
        _mazeResolv.changeValue(maze[indexPlayerX][indexPlayerY], _mazeResolv.getNextCase());
        _mazeResolv.setIndexPlayerY(indexPlayerY-1);
    }
}