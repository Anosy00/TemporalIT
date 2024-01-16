using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class LadderSaddler : Node
{
	private EButton _keyInteration;
	private const String _NAME_OF_THE_ANIMATION = "default";
	private DialogBox _dialogBox;
	private KeyboardInteraction _keyboardInteraction;
	private Node2D _tileMap;
	private Camera2D _camera;
	private Camera2D _cameraTileMap;
	private Node2D _saddler;
	private Sprite2D _objectif;
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
		_saddler = GetNode<Node2D>("../../../Saddler");
		_cameraTileMap = GetNode<Camera2D>("../../../Node2D/TileMap/Camera2D");
		_saddler.ProcessMode = ProcessModeEnum.Inherit;
		_saddler.Show();
		_objectif = GetNode<Sprite2D>("../../../ObjectifSaddler");
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
		if (GlobalJMJ.hadInteractedWithNewsPaper && Input.IsActionJustReleased("button_e") && _keyInteration.isVisible())
		{
			_objectif.Visible = false;
			GD.Print("J'ai effacé l'obj");
			_camera.Enabled = false;
			_saddler.ProcessMode = ProcessModeEnum.Disabled;
			_tileMap.ProcessMode = ProcessModeEnum.Inherit;
			_tileMap.Show();
			_cameraTileMap.Enabled = true;
		}
		else if (_keyInteration.isVisible() && Input.IsActionJustReleased("button_e")){
			_dialogBox.setTextOfLabel("[Player]", "Je devrais peut-être aller voir le journal avant");
			_dialogBox.available("displayText");
			
		}
		_dialogBox.setCanCloseDialogBox(true);
		_dialogBox.closeDialogBox();
		if (GlobalJMJ.isObjActive && _camera.Enabled)
		{
			_objectif.Visible = true;
		}
		else
		{
			_objectif.Visible = false;
		}
	}
}
