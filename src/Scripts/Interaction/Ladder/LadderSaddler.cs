using Godot;
using System;

public partial class LadderSaddler : Node
{
	private EButton _keyboardInteration;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";

	private const String _nextScene = "res://tile_map.tscn";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyboardInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyboardInteration.disable();
	}
	
	public void _on_area_2d_body_entered(CharacterBody2D body)
	{
		_keyboardInteration.available(_NAME_OF_THE_ANIMATION);
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_keyboardInteration.disable();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_keyboardInteration.makeInteraction(GetTree(), _E_BUTTON, _nextScene);
	}
}
