using Godot;
using System;

public partial class Transition : AnimationPlayer
{
	private const String _PATH_BACK_SCENE = "res://Morse's room/Rooms/Maze/FirstLooseMaze.tscn";
	private const String _PATH_NEXT_SCENE = "res://Morse's room/Rooms/LastScene/LastScene.tscn";
	public void _on_animation_finished(String anim_name)
	{
		if (anim_name == "transition-monster")
		{
			GetTree().ChangeSceneToFile(_PATH_BACK_SCENE);
		}
		if (anim_name == "transition-exit")
		{
			GetTree().ChangeSceneToFile(_PATH_NEXT_SCENE);	
		}
	}
}
