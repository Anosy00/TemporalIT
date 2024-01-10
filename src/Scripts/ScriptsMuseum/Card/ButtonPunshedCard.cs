using Godot;
using System;

public partial class ButtonPunshedCard : Node
{
	// Called when the node enters the scene tree for the first time.
	private Button _buttonPunshedCard;
	private String sceneSuivante = "res://TilesMapMusee/mapMusee.tscn";
	public AnimatedSprite2D _keyboardInteration;
	
	public override void _Ready()
	{
		_buttonPunshedCard = GetNode<Button>("ButtonPunshedCard");
		if (Input.IsActionPressed("button_e"))
		{
			// Simulate releasing the E button to disable the action
			Input.ActionRelease("button_e");
		}
		_keyboardInteration = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_keyboardInteration.Visible = true;
		_keyboardInteration.Play("default");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		if (Input.IsActionPressed("button_e") ) 
		{
			GetTree().ChangeSceneToFile(sceneSuivante);
				
		}
	}
	public void _on_pressed()
	{	
		GetTree().ChangeSceneToFile(sceneSuivante);
	}
	
	
	
}





