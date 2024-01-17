using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.KeyboardInteraction;

public partial class LadderSaddler : Node
{
	private EButton _keyInteration;
	private const String _NAME_OF_THE_ANIMATION = "default";
	private const String _E_BUTTON =  "button_e";
	private const String _PATH_NEXT_SCENE = "res://JMJ's Room/Room/tile_map.tscn";
	private DialogBox _dialogBox;
	private KeyboardInteraction _keyboardInteraction;
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
		_keyboardInteraction = new KeyboardInteraction(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_objectif = GetNode<Sprite2D>("../../ObjectifSaddler");
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
			_keyInteration.makeInteraction(GetTree(), _E_BUTTON, _PATH_NEXT_SCENE);
		}
		else if (_keyInteration.isVisible() && Input.IsActionJustReleased("button_e")){
			_dialogBox.setTextOfLabel("[Player]", "Je devrais peut-être aller voir le journal avant");
			_dialogBox.available("displayText");
			
		}
		_dialogBox.setCanCloseDialogBox(true);
		_dialogBox.closeDialogBox();
	}
}
