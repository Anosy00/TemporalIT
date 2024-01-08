using Godot;
using System;

public partial class SaddlerScript : Node
{
	private DialogBox _dialogBox;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_dialogBox = new DialogBox(GetNode<Sprite2D>("../../DialogBox"),
			GetNode<Label>("../../DialogBox/LabelText"),
			GetNode<Label>("../../DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../../DialogBox/AnimationPlayer"));
		_dialogBox.disable();
	}

	public void displayTextIfNotInteractedWithPaper()
	{
		_dialogBox.available("displayText");
		_dialogBox.setTextOfLabel("[Player]", "Mmh, je devrais peut être intéragir avec le journal");
	}
}
