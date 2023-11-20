using Godot;
using System;

public partial class buttonBack : Button
{
	// Called when the node enters the scene tree for the first time.
	private Button _buttonBack;
	public override void _Ready()
	{
		_buttonBack = GetNode<Button>("ButtonBack");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
    
	void _on_pressed()
	{
		GetTree().ChangeSceneToFile("res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn");
	}
}
