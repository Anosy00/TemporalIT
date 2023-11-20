using Godot;
using System;

public partial class book : Node
{	
	// Called when the node enters the scene tree for the first time.
	private AnimatedSprite2D keyboardInteration;
	public override void _Ready()
	{
		keyboardInteration = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("button_e") && keyboardInteration.IsVisibleInTree())
		{
			GetTree().ChangeSceneToFile("res://Morse's room/Rooms/FirstRoom/InTheBook.tscn");
		}
	}

	void _on_body_entered(CharacterBody2D body)
	{
		// Replace with function body.
		keyboardInteration.Visible = true;
		keyboardInteration.Play("default");
	}
	
	void _on_body_exited(CharacterBody2D body)
	{
		// Replace with function body.
		keyboardInteration.Visible = false;
		keyboardInteration.Stop();
	}
}
