using Godot;
using System;
using TemporalIT;
using Environment = Godot.Environment;

public partial class BackButtonJMJ : Button
{
	private const String _PATH_NEXT_SCENE = "res://JMJ's Room/Room/Saddler.tscn";
	private EButton _keyInteration;

	public override void _Ready()
	{
	}

	public void _on_pressed()
	{
		GetTree().ChangeSceneToFile(_PATH_NEXT_SCENE);
	}
}
