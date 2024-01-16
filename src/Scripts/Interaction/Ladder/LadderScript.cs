using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class LadderScript : Node
{
	private EButton _keyInteration;
	private KeyboardInteraction _keyboardInteraction;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";
	private Node2D _saddler;
	private Node2D _tileMap;
	private Camera2D _cameraSaddler;
	private Sprite2D _objectif;

	private Camera2D _camera;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyInteration.disable();
		_tileMap = GetNode<Node2D>("../../../Node2D");
		_saddler = GetNode<Node2D>("../../../Saddler");
		_cameraSaddler = GetNode<Camera2D>("../../../Saddler/TileMap/Camera2D");
		_camera = GetNode<Camera2D>("../Camera2D");
		_objectif = GetNode<Sprite2D>("../../../Objectif");
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
		if (Input.IsActionJustReleased("button_e") && _keyInteration.isVisible())
		{
			_tileMap.ProcessMode = ProcessModeEnum.Disabled;
			_tileMap.Hide();
			_saddler.ProcessMode = ProcessModeEnum.Inherit;
			_saddler.Show();
			_saddler.Visible = true;
			_cameraSaddler.Enabled = true;
			_camera.Enabled = false;
		}
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
