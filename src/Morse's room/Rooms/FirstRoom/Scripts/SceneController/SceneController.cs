using Godot;
using System;

public partial class SceneController : Node
{

	public CharacterBody2D _player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<CharacterBody2D>("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_area_2d_body_entered(CharacterBody2D body)
	{
		GetTree().ChangeSceneToFile("res://Morse's room/Rooms/Labyrinth/Labyrinth.tscn");
	}
}
