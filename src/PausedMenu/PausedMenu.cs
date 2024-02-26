using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

namespace PausedMenu; 

public partial class PausedMenu : CanvasLayer
{
	private string _actualScene;
	private string pathToScene;
	private Node scene;

	public override void _Ready()
	{
		Hide();
	}

	public override void _Process(double delta)
	{
		if (GetTree().Paused)
		{
			Show();
		}
		else
		{
			Hide();
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("echap"))
		{
			scene = GetTree().CurrentScene;
			pathToScene = scene.SceneFilePath;
		}
	}

	public void _on_continue_pressed()
	{
		Hide();
		GetTree().Paused = false;
	}

	public void _on_exit_pressed()
	{
		Hide();
		GetTree().Paused = false;
		Music.StopMusic();
		GetTree().ChangeSceneToFile("res://TitleScreen/TitleScreen.tscn");
	}
}

