using Godot;
using System;

public partial class MazeControllerScene : Control
{
	private PlayerSaveManager _playerSaveManager;
	private const float _PLAYER_POSITION_X =(float) 117.323 ;
	private const float _PLAYER_POSITION_Y =(float) 0.805 ;
	public override void _Ready()
	{
		_playerSaveManager = new PlayerSaveManager();
	}

	public void _on_tree_exited()
	{
		_playerSaveManager.save(_PLAYER_POSITION_X, _PLAYER_POSITION_Y);
	}
}
