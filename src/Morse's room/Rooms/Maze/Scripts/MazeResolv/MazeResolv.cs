using Godot;

namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv;

public class MazeResolv
{
	private int[][] _maze;
	private int _indexPlayerX;
	private int _indexPlayerY;
	private int _nextCase;
	private MazeStrategyInterface _mazeStrategy;

	public MazeResolv()
	{
		_maze = MazeConstants.fill();
		_indexPlayerX = 1;
		_indexPlayerY = 1;
	}
	
	//Getters
	public int getIndexPlayerX()
	{
		return _indexPlayerX;
	}
	public int getIndexPlayerY()
	{
		return _indexPlayerY;
	}
	public int getNextCase()
	{
		return _nextCase;
	}
	
	public int[][] getMaze()
	{
		return _maze;
	}
	
	//Setters
	public void setIndexPlayerX(int value)
	{
		_indexPlayerX = value;
	}
	
	public void setIndexPlayerY(int value)
	{
		_indexPlayerY = value;
	}
	
	public void setNextCase(int value)
	{
		_nextCase = value;
	}

	public void setStrategy(MazeStrategyInterface strategy)
	{
		_mazeStrategy = strategy;
	}

	public void move()
	{
		_mazeStrategy.move(this);
	}
	public void changeValue(int player,int caseToGo)
	{
		int temp = player;
		player = caseToGo;
		caseToGo = temp;
	}
	public bool verficationCase(int condition)
	{
		if (_nextCase == condition)
		{
			return false;
		}
		return true;
	}
	
}