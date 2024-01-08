using Godot;
using System;

public partial class BackButton : Button
{
	private const String _NEXT_SCENE_PATH = "res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn";
	public void _on_back_button_pressed()
	{
		GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
	}
}
