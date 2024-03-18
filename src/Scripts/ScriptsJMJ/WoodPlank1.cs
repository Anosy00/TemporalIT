using Godot;
using System;
using TemporalIT;

public partial class WoodPlank1 : Area2D
{
	private EButton _button;
	private static CollisionShape2D _collisionShape2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_button = new EButton(GetNode<AnimatedSprite2D>("EButtonSpritePlank"));
		_button.disable();
		_collisionShape2D = GetNode<CollisionShape2D>("WoodPlank/WoodPlankCollision");
		if (GlobalJMJ.nbPlanks == 2)
		{
			Visible = false;
			_collisionShape2D.Disabled = true;
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("button_e") && _button.isVisible())
		{
			Visible = false;
			_collisionShape2D.Disabled = !_collisionShape2D.Disabled;
			GlobalJMJ.nbPlanks++;
		}
		
		GD.Print(_collisionShape2D.Disabled);
	}

	public void _on_body_entered(CharacterBody2D body)
	{
		if (GlobalJMJ.canInteractWithPlanks)
		{
			_button.available("default");
		}
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_button.disable();
	}
}
