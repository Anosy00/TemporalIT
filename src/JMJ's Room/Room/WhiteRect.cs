using Godot;
using System;

public partial class WhiteRect : CharacterBody2D
{
	private Vector2 position;
	private bool isInRedRect = false;
	private bool augment = true;
	private bool canMove = true;

	private int win = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		position = Position;
		GD.Print(Position);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = position;
		if (augment && canMove)
		{
			position.X += 1.5F;
		}
		else if (!augment && canMove){ position.X -= 1.5F; }

		if (Input.IsActionJustPressed("closeDialog"))
		{
			if (isInRedRect){ 
				canMove = false;
				win++;
			}
		}
		
		if (win == 3)
		{
			GetTree().ChangeSceneToFile("res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn");
		}
	}
	
	public bool getAugment()
	{
		return augment;
	}
	
	public void setAugment(bool value)
	{
		augment = value;
	}
	
	public bool getInRedRect(bool value)
	{
		return isInRedRect;
	}
	
	public void setInRedRect(bool value)
	{
		isInRedRect = value;
	}
}
