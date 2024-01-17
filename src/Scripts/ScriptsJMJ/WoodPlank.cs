using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.ScriptsJMJ;

public partial class WoodPlank : Area2D
{
	private EButton _button;
	private CollisionShape2D _collisionShape2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_button = new EButton(GetNode<AnimatedSprite2D>("EButtonSpritePlank"));
		_button.disable();
		_collisionShape2D = GetNode<CollisionShape2D>("WoodPlank/WoodPlankCollision");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("button_e") && _button.isVisible())
		{
			this.Visible = false;
			_collisionShape2D.Disabled = true;
			GlobalJmj.nbPlanks++;
		}
	}

	public void _on_body_entered(CharacterBody2D body)
	{
		if (GlobalJmj.canInteractWithPlanks)
		{
			_button.available("default");
		}
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_button.disable();
	}
}
