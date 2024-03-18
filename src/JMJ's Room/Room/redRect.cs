using Godot;
using System;

public partial class redRect : Area2D
{
	private WhiteRect _characterBody2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_characterBody2D = GetNode<WhiteRect>("../../CharacterBody");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_body_entered(CharacterBody2D body)
	{
		_characterBody2D.setInRedRect(true);
	}
	public void _on_body_exited(CharacterBody2D body)
	{
		_characterBody2D.setInRedRect(false);
	}
}
