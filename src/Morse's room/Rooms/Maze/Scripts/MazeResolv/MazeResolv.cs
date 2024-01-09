using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv;

namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv
{
	public class MazeResolv
	{
		private int[][] _maze;

		private const int _LIMIT_COLUMN_MAX = 7;
		private const int _FREE_CASE = 0;
		private const int _PLAYER_POSITION = 1;
		private const int _MONSTER_POSITION = 2;

		public MazeResolv()
		{
			_maze = MazeConstants.fill();
		}
		
	}
}