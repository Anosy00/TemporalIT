using Godot;
using System;
using TemporalIT;
using TemporalIT.JMJ_s_Room.Room.SaverManagement;
using TemporalIT.Morse_s_room.Rooms.Maze.Scripts.Player;

public partial class Saddler : Node2D
{
	private PlayerSaveManagerJMJ _playerSaveManager;
	private CharacterBody2D _characterBody2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_characterBody2D = GetNode<CharacterBody2D>("TileMap/Player");
		_playerSaveManager = new PlayerSaveManagerJMJ();
		_playerSaveManager.load();
		if (GlobalJMJ.firstEntryInSaddler)
		{
			_characterBody2D.Position = _playerSaveManager.launchingPosition();
			GlobalJMJ.firstEntryInSaddler = false;
		}
		else
		{
			_characterBody2D.Position = new Vector2(-34, -5);
		}
	}

	public void _on_tree_exited()
	{
		var playerPosition = _characterBody2D.GetPositionDelta();
		GD.Print(playerPosition.X + " " + playerPosition.Y);
		_playerSaveManager.save(playerPosition.X,playerPosition.Y);
	}
}
