
namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv
{
    public class MazeConstants
    {
        public const int LIMIT_COLUMN_MAX = 7;
        public const int FREE_CASE = 0;
        public const int START_CASE = 1;
        public const int MONSTER_CASE = 2;
        public const int EXIT_CASE = 3;

        public static int[][] fill()
        {
            int[][] _maze = new int[6][];
            int[] borderTopBot = new int[LIMIT_COLUMN_MAX] {MONSTER_CASE,MONSTER_CASE,MONSTER_CASE,MONSTER_CASE,MONSTER_CASE,MONSTER_CASE,MONSTER_CASE};
            _maze[0] = borderTopBot;
            _maze[1] = new int[LIMIT_COLUMN_MAX]
            {
                MONSTER_CASE,START_CASE,FREE_CASE,MONSTER_CASE,MONSTER_CASE,MONSTER_CASE,MONSTER_CASE
            };
            _maze[2] = new int[LIMIT_COLUMN_MAX]
            {
                MONSTER_CASE,FREE_CASE,FREE_CASE,MONSTER_CASE,FREE_CASE,FREE_CASE,EXIT_CASE
            };
            _maze[3] = new int[LIMIT_COLUMN_MAX]
            {
                MONSTER_CASE,FREE_CASE,MONSTER_CASE,FREE_CASE,FREE_CASE,MONSTER_CASE,MONSTER_CASE
            };
            _maze[4] = new int[LIMIT_COLUMN_MAX]
            {
                MONSTER_CASE, FREE_CASE, FREE_CASE, FREE_CASE, MONSTER_CASE, MONSTER_CASE, MONSTER_CASE
            };
            _maze[5] = borderTopBot;
            return _maze;
        }
        
    }
}