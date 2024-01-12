using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

public partial class FirstRoomController : Node2D
{
	private CharacterBody2D _player;
	private PlayerSaveManager _playerSaveManager;

	private const String _PATH_NODE_PLAYER = "Player";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<CharacterBody2D>(_PATH_NODE_PLAYER);
		_playerSaveManager = new PlayerSaveManager();
		_playerSaveManager.load();
		_player.Position = new Vector2(_playerSaveManager.getX(),_playerSaveManager.getY());
		Music.playMusic();
	}

	public void _on_tree_exited()
	{
		Vector2 playerPostition = _player.GetPositionDelta();
		_playerSaveManager.save(playerPostition.X, playerPostition.Y);
	}
}
