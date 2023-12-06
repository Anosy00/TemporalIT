using Godot;
using System;

public partial class player : CharacterBody2D
{
	private const float SPEED = 3f;

	private AnimatedSprite2D animateSprite;

	public override void _Ready()
	{
		base._Ready();
		animateSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
	}

	public override void _PhysicsProcess(double d)
	{
		Vector2 velocity = new Vector2();
		float directionX = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		float directionY = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");

		if (Input.IsActionPressed("ui_down"))
		{
			velocity.Y = directionY * SPEED;
			animateSprite.Play("moveDown");
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			velocity.Y -= SPEED;
			animateSprite.Play("moveUp");
		}
		else if (Input.IsActionPressed("ui_right"))
		{
			velocity.X = directionX * SPEED;
			animateSprite.Play("moveRight");
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			velocity.X -= SPEED;
			animateSprite.Play("moveLeft");
		}
		else
		{
			animateSprite.Stop();
		}

		MoveAndCollide(velocity);
	}

	/*void _on_area_2d_body_entered(CharacterBody2D body)
	{
		// Replace with function body.
		GetTree().ChangeSceneToFile("res://TilesMapMusee/mapMusee.tscn");
	}*/
	
<<<<<<< HEAD
=======
	void _on_area_2d_body_exited(CharacterBody2D body)
	{
		Global.changeValueOfCanInteraciWithJean();
	}*/
>>>>>>> 07b48d800074676fdd8e525c9926cb489cea98b5
}



/*public void _on_interactive_zone_of_the_punched_card_body_entered(Node2D body)
{
	// Replace with function body.
}


public void _on_interactive_zone_of_the_punched_card_body_exited(Node2D body)
{
	// Replace with function body.
}*/
