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

	private void _on_tree_exited()
	{
		_playerSaveManager.Reset();
	}

	public void _on_animation_finished(String anim_name)
	{
		GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
	}
}