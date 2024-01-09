
namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv
{
    public class MazeConstants
    {
        private const int _LIMIT_COLUMN_MAX = 7;
        private const int _FREE_CASE = 0;
        private const int _PLAYER_POSITION = 1;
        private const int _MONSTER_POSITION = 2;

        public static int[][] fill()
        {
            int[][] _maze = new int[7][];
            int[] borderTopBot = new int[_LIMIT_COLUMN_MAX] {_MONSTER_POSITION,_MONSTER_POSITION,_MONSTER_POSITION,_MONSTER_POSITION,_MONSTER_POSITION,_MONSTER_POSITION,_MONSTER_POSITION};
            _maze[0] = borderTopBot;
            _maze[1] = new int[_LIMIT_COLUMN_MAX]
            {
                _MONSTER_POSITION, _FREE_CASE, _FREE_CASE, _FREE_CASE, _MONSTER_POSITION, _MONSTER_POSITION,
                _MONSTER_POSITION
            };
            _maze[2] = new int[_LIMIT_COLUMN_MAX]
            {
                _MONSTER_POSITION,_FREE_CASE,_MONSTER_POSITION,_FREE_CASE,_FREE_CASE,_MONSTER_POSITION,_MONSTER_POSITION
            };
            _maze[3] = new int[_LIMIT_COLUMN_MAX]
            {
                _MONSTER_POSITION,_FREE_CASE,_FREE_CASE,_MONSTER_POSITION,_FREE_CASE,_FREE_CASE,10
            };
            _maze[4] = new int[_LIMIT_COLUMN_MAX]
            {
                _FREE_CASE,_FREE_CASE,_FREE_CASE,_MONSTER_POSITION,_MONSTER_POSITION,_MONSTER_POSITION,_MONSTER_POSITION
            };
            _maze[5] = borderTopBot;
            return _maze;
        }
    }
}