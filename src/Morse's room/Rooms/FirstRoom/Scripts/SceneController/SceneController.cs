using Godot;
using System;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class SceneController : Node
{
	private const String _NEXT_SCENE_PATH = "res://Morse's room/Rooms/Maze/Maze.tscn";
	public void _on_body_entered(CharacterBody2D player)
	{
		GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
	}

}
