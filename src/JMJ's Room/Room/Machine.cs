using Godot;
using System;
using TemporalIT;

public partial class Machine : Area2D
{
	private EButton _eButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_eButton = new EButton(GetNode<AnimatedSprite2D>("EButton"));
		_eButton.disable();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("button_e") && _eButton.isVisible())
		{
			GetTree().ChangeSceneToFile("res://JMJ's Room/Room/Machine.tscn");
		}
	}
	
	public void _on_body_entered(CharacterBody2D body)
	{
		if (GlobalJMJ.canInteractWithMachine)
		{
			_eButton.available("default");	
		}
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_eButton.disable();
	}
}
