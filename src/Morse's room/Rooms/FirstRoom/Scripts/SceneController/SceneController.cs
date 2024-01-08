using Godot;
using System;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class SceneController : Node
{
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void makeInteraction(String key,KeyboardInteraction _keyboardInteration,String nextScenePth)
	{
		if (Input.IsActionPressed(key) && _keyboardInteration.isVisible())
		{
			GetTree().ChangeSceneToFile(nextScenePth);
		}
	}

}
