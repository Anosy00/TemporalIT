using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class LadderSaddler : Node
{
	private EButton _keyInteration;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";
	private DialogBox _dialogBox;
	private KeyboardInteraction _keyboardInteraction;
	private Node2D _tileMap;
	private Camera2D _camera;
	private Node2D _saddler;

	private const String _nextScene = "res://JMJ's Room/Room/tile_map.tscn";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyInteration.disable();
		_dialogBox = new DialogBox(GetNode<Sprite2D>("../DialogBox"),
			GetNode<Label>("../DialogBox/LabelText"),
			GetNode<Label>("../DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../DialogBox/AnimationPlayer"));
		_dialogBox.disable();
		_tileMap = GetNode<Node2D>("../../../Node2D");
		_keyboardInteraction = new KeyboardInteraction(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_camera = GetNode<Camera2D>("../Camera2D");
		_saddler = GetNode<Node2D>("../../../Saddler/TileMap");
		_saddler.ProcessMode = ProcessModeEnum.Pausable;
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
		if (GlobalJMJ.hadInteractedWithNewsPaper && Input.IsActionPressed("button_e") && _keyInteration.isVisible())
		{
			_camera.Enabled = false;
			_saddler.Visible = false;
			_saddler.GetTree().Paused = true;
			_tileMap.GetTree().Paused = false;
		}
		else if (_keyInteration.isVisible() && Input.IsActionPressed("button_e")){
			_dialogBox.setTextOfLabel("[Player]", "Je devrais peut-être aller voir le journal avant");
			_dialogBox.available("displayText");
			
		}
		_dialogBox.setCanCloseDialogBox(true);
		_dialogBox.closeDialogBox();
	}
}
