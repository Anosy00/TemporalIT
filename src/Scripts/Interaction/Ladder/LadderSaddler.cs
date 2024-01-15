using Godot;
using System;

public partial class LadderSaddler : Node
{
	private EButton _keyboardInteration;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";
	private DialogBox _dialogBox;

	private const String _nextScene = "res://JMJ's Room/Room/tile_map.tscn";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyboardInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyboardInteration.disable();
		_dialogBox = new DialogBox(GetNode<Sprite2D>("../DialogBox"),
			GetNode<Label>("../DialogBox/LabelText"),
			GetNode<Label>("../DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../DialogBox/AnimationPlayer"));
		_dialogBox.disable();
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
		if (_keyboardInteration.makeInteraction(GetTree(), _E_BUTTON, _nextScene) == 0)
		{
			_keyboardInteration.makeInteraction(GetTree(), _E_BUTTON, _nextScene);
		}
		else if (_keyboardInteration.makeInteraction(GetTree(), _E_BUTTON, _nextScene) == 1)
		{
			_dialogBox.setTextOfLabel("[Player]", "Je devrais peut-être aller voir le journal avant");
			_dialogBox.available("displayText");
			
		}
		_dialogBox.setCanCloseDialogBox(true);
		_dialogBox.closeDialogBox();
	}
}
