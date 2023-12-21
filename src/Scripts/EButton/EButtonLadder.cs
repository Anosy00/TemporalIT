using Godot;
using System;

public partial class EButtonLadder : EButtonAbstract {
	
	private AnimatedSprite2D eButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		eButton = GetNode<AnimatedSprite2D>("EButtonLadderSprite");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact") && eButton.IsVisibleInTree() && Global.hadInteractedWithNewsPaper)
		{
			GetTree().ChangeSceneToFile("res://tile_map.tscn");
		}
		
		if (Input.IsActionPressed("interact") && eButton.IsVisibleInTree() && !Global.hadInteractedWithNewsPaper)
		{
			Console.WriteLine("You need to interact with the newspaper first!");
		}
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
