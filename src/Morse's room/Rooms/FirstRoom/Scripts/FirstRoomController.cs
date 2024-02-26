using Godot;
namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

public partial class FirstRoomController : Node2D
{
	private CharacterBody2D _player;
	private PlayerSaveManager _playerSaveManager;
	
	private const string PathNodePlayer = "Player";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<CharacterBody2D>(PathNodePlayer);
		_playerSaveManager = new PlayerSaveManager();
		_playerSaveManager.Load();
		_player.Position = new Vector2(_playerSaveManager.GetX(),_playerSaveManager.GetY());
		Input.MouseMode = Input.MouseModeEnum.Hidden;
		Music.PlayMusic();
		
	}

	private void _on_tree_exited()
	{
		var playerPosition = _player.GetPositionDelta();
		_playerSaveManager.Save(playerPosition.X, playerPosition.Y);
		Input.MouseMode = Input.MouseModeEnum.Visible;
	}

	private void _on_tree_entered()
	{
		GetTree().Paused = false;
	}
}
