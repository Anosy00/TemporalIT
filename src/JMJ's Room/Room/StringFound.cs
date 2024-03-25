using Godot;
using System;
using TemporalIT;

public partial class StringFound : Area2D
{
	private Sprite2D _stringFound;
	private Label _labelStringFound;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_stringFound = GetNode<Sprite2D>("StringFound");
		_labelStringFound = GetNode<Label>("Label");
		_stringFound.Visible = false;
		_labelStringFound.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GlobalJMJ.hasString)
		{
			_stringFound.Visible = true;
			_labelStringFound.Visible = true;
		}
	}
}
