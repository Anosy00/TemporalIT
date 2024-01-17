using Godot;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts;

public partial class MazeControllerScene : Control
{
	private PlayerSaveManager _playerSaveManager;
	public override void _Ready()
	{
		_playerSaveManager = new PlayerSaveManager();
	}

	private void _on_tree_exited()
	{
		_playerSaveManager.Reset();
	}
}