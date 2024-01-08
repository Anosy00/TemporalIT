using Godot;
using System;

public partial class ButtonPunshedCard : Node
{
	// Called when the node enters the scene tree for the first time.
	private Button _buttonPunshedCard;
	public override void _Ready()
	{
		_buttonPunshedCard = GetNode<Button>("ButtonPunshedCard");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("echap") ) //&& _keyboardInteration.IsVisibleInTree()
		{
			GetTree().ChangeSceneToFile("res://TilesMapMusee/mapMusee.tscn");
				
		}
	}
	public void _on_pressed()
	{	
		GetTree().ChangeSceneToFile("res://TilesMapMusee/mapMusee.tscn");
	}
	
}



