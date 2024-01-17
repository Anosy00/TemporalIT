using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class LadderScript : Node
{
	private EButton _keyInteration;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";
	private const String _NEXT_SCENE_PATH = "res://JMJ's Room/Room/Saddler.tscn";
	private Sprite2D _objectif;

	private Camera2D _camera;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyInteration.disable();
		_objectif = GetNode<Sprite2D>("../../Objectif");
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
		_keyInteration.makeInteraction(GetTree(), _E_BUTTON, _NEXT_SCENE_PATH);
		if (GlobalJMJ.isObjActive)
		{
			_objectif.Visible = true;
		}
		else
		{
			_objectif.Visible = false;
		}
	}
	
}
