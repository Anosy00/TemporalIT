using Godot;
using System;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class LadderScript : Node
{
	private EButton _keyInteration;
	private KeyboardInteraction _keyboardInteraction;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";

	private Node2D _saddler;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyInteration.disable();
		_saddler = GetNode<Node2D>("../../../Node2D");
	}
	
	public void _on_area_2d_body_entered(CharacterBody2D body)
	{
		_keyInteration.available(_NAME_OF_THE_ANIMATION);
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_keyInteration.disable();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("button_e") && _keyInteration.isVisible())
		{
			_saddler.Visible = false;
		}
	}
	
}
