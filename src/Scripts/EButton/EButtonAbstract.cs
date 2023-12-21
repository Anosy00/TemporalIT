using Godot;
using System;

public abstract partial class EButtonAbstract : Node
{
	private AnimatedSprite2D eButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	void _on_area_2d_body_entered(CharacterBody2D body)
	{
		eButton.Visible = true;
		eButton.Play("animation");
	}

	void _on_body_exited(CharacterBody2D body)
	{
		eButton.Visible = false;
		eButton.Stop();
	}
}
