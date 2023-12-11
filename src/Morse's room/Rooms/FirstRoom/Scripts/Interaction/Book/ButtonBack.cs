using Godot;
using System;

public partial class ButtonBack : Button
{
	// Called when the node enters the scene tree for the first time.
	private Button _buttonBack;
	public override void _Ready()
	{
		_buttonBack = GetNode<Button>("ButtonBack");
	}
    
	void _on_pressed()
	{
		GetTree().ChangeSceneToFile("res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn");
	}
}
