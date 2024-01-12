using Godot;

namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv
{
	public class MazeResolv
	{
		private int[][] _maze;
		private int _indexPlayerX;
		private int _indexPlayerY;
		private int nextCase;

		public MazeResolv()
		{
			_maze = MazeConstants.fill();
			_indexPlayerX = 1;
			_indexPlayerY = 1;
		}
		
		private void changeValue(int player,int caseToGo)
		{
			int temp = player;
			player = caseToGo;
			caseToGo = temp;
		}
		public void moveRight()
		{
			nextCase = _maze[_indexPlayerX][_indexPlayerY + 1];
			if (verficationCase(MazeConstants.MONSTER_CASE) && !verficationCase(MazeConstants.EXIT_CASE))
			{
				changeValue(_maze[_indexPlayerX][_indexPlayerY], nextCase);
				_indexPlayerY++;
			}
			GD.Print("x = "+_indexPlayerX+" - y = "+_indexPlayerY + " value = "+_maze[_indexPlayerX][_indexPlayerY]);
		}

		public void moveLeft()
		{
			nextCase = _maze[_indexPlayerX][_indexPlayerY - 1];
			if (verficationCase(MazeConstants.MONSTER_CASE) && !verficationCase(MazeConstants.EXIT_CASE))
			{
				changeValue(_maze[_indexPlayerX][_indexPlayerY], nextCase);
				_indexPlayerY--;
			}
			GD.Print("x = "+_indexPlayerX+" - y = "+_indexPlayerY + " value = "+_maze[_indexPlayerX][_indexPlayerY]);
		}
		public void moveUp()
		{
			nextCase = _maze[_indexPlayerX + 1][_indexPlayerY];
			if (verficationCase(MazeConstants.MONSTER_CASE) && !verficationCase(MazeConstants.EXIT_CASE))
			{
				changeValue(_maze[_indexPlayerX][_indexPlayerY], nextCase);
				_indexPlayerX++;
			}
			GD.Print("x = "+_indexPlayerX+" - y = "+_indexPlayerY + " value = "+_maze[_indexPlayerX][_indexPlayerY]);
		}
		public void moveDown()
		{
			nextCase = _maze[_indexPlayerX - 1][_indexPlayerY];
			if (verficationCase(MazeConstants.MONSTER_CASE) && !verficationCase(MazeConstants.EXIT_CASE))
			{
				changeValue(_maze[_indexPlayerX][_indexPlayerY], nextCase);
				_indexPlayerX--;
			}
			GD.Print("x = "+_indexPlayerX+" - y = "+_indexPlayerY + " value = "+_maze[_indexPlayerX][_indexPlayerY]);
		}

		public bool verficationCase(int condition)
		{
			if (nextCase == condition)
			{
				return false;
			}
			return true;
		}
		
	}
}