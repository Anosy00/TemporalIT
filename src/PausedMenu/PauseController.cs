using Godot;
using System;

public partial class PauseController : CanvasLayer
{
	private string _actualScene;
	private string pathToScene;
	private Node scene;
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("echap"))
		{
			if (GetTree().Paused)
			{
				GetTree().Paused = false;
			}
			scene = GetTree().CurrentScene;
			pathToScene = scene.SceneFilePath;
			if (checkIfSceneCanBePaused(pathToScene))
			{
				GetTree().Paused = true;
			}
		}
	}
	private bool checkIfSceneCanBePaused(String pathScene)
	{
		var cant_paused_nodes = GetTree().GetNodesInGroup("cant_paused");

		foreach (var node in cant_paused_nodes)
		{
			if (node.SceneFilePath == pathScene)
				return false;
		}
		return true;
	}
}
