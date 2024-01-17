using Godot;

namespace TemporalIT.Scripts.Interaction.Ladder;

public partial class LadderScript : Node
{
	private EButton _keyboardInteration;
	private const String EButton = "button_e";
	private const String NameOfTheAnimation = "default";
	private DialogBox.DialogBox _dialogBox;

	private const String NextScene = "res://JMJ's Room/Room/Saddler.tscn";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyboardInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyboardInteration.disable();
		_dialogBox = new DialogBox.DialogBox(GetNode<Sprite2D>("../DialogBox"),
			GetNode<Label>("../DialogBox/LabelText"),
			GetNode<Label>("../DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../DialogBox/AnimationPlayer"));
		_dialogBox.disable();
	}
	
	public void _on_area_2d_body_entered(CharacterBody2D body)
	{
		_keyboardInteration.available(NameOfTheAnimation);
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_keyboardInteration.disable();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_keyboardInteration.makeInteraction(GetTree(), EButton, NextScene) == 0)
		{
			_keyboardInteration.makeInteraction(GetTree(), EButton, NextScene);
		}
		else if (_keyboardInteration.makeInteraction(GetTree(), EButton, NextScene) == 1)
		{
			_dialogBox.setTextOfLabel("[Player]", "Je devrais peut-être aller voir le journal avant");
			_dialogBox.available("displayText");
			
		}

		if (_dialogBox.isVisible())
		{
			_dialogBox.closeDialogBox();
		}
	}
	
}