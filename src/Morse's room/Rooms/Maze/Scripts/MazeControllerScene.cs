using Godot;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts;

public partial class MazeControllerScene : Control
{
	private const String _NEXT_SCENE_PATH = "res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn";
	private PlayerSaveManager _playerSaveManager;
	private AnimationPlayer _animationPlayer;
	private const String _NAME_OF_THE_ANIM = "text-animation";
	private const String _PATH_ANIM = "AnimationPlayer";
	public override void _Ready()
	{
		_playerSaveManager = new PlayerSaveManager();
		_animationPlayer = GetNode<AnimationPlayer>(_PATH_ANIM);
		_animationPlayer.Play(_NAME_OF_THE_ANIM);
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("button_e"))
		{
			GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
		}
	}

	private void _on_tree_exited()
	{
		_playerSaveManager.Reset();
	}
}