using Godot;
using System;
using TemporalIT;

public partial class BackButton : Button
{
	private String _NEXT_SCENE_PATH;

	public override void _Ready()
	{
		
		_NEXT_SCENE_PATH = "res://Morse's room/Rooms/FirstRoom/FirestRoom.tscn";
		
	}

	public void _on_back_button_pressed()
	{
		GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
	}
}
