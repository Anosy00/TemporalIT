using Godot;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

namespace TemporalIT.Scripts.ScriptsMuseum.Card;
public partial class ButtonPunchedCard : Button
{
	// Called when the node enters the scene tree for the first time.
	private String _nextScene = "res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn";
	private AnimatedSprite2D _keyboardInteration;
	private PlayerSaveManager _playerSaveManager;
	public override void _Ready()
	{
		if (Input.IsActionPressed("button_e"))
		{
			// Simulate releasing the E button to disable the action
			Input.ActionRelease("button_e");
		}
		_keyboardInteration = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_keyboardInteration.Visible = true;
		_keyboardInteration.Play("default");
		_playerSaveManager = new PlayerSaveManager();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!Input.IsActionPressed("button_e")) return;
		Global.ChestIsOpened = false;
		GetTree().ChangeSceneToFile(_nextScene);
		Music.PlayMusic();
		_playerSaveManager.Reset();
	}

	private void _on_pressed()
	{
		Global.ChestIsOpened = false;
		GetTree().ChangeSceneToFile(_nextScene);
		Music.PlayMusic();
		_playerSaveManager.Reset();
	}
}