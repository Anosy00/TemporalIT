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
		_keyInteration = new EButton();
	}

	public void _on_back_button_pressed()
	{
		_keyInteration.makeInteraction(GetTree(), "button_e", _PATH_NEXT_SCENE);
	}
}
