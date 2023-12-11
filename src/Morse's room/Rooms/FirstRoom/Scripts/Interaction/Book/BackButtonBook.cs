using Godot;
using System;

public partial class BackButtonBook : Button
{
	private Button _buttonBack;
	private const String _NEXT_SCENE_PATH = "res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_buttonBack = GetNode<Button>("ButtonBack");
	}
    
	void _on_pressed()
	{
		GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
	}
}
