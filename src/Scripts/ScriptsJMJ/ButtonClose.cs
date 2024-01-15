using Godot;
using System;

public partial class ButtonClose : Button
{
	private DialogBox _dialogBox;
	
	public override void _Ready()
	{
		_dialogBox = new DialogBox(GetNode<Sprite2D>("../../DialogBox"),
			GetNode<Label>("../../DialogBox/LabelText"),
			GetNode<Label>("../../DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../../DialogBox/AnimationPlayer"));
		_dialogBox.disable();
	}
	public void _on_pressed()
	{
		NewsPaper.setInvisibleNewsPaper();
		_dialogBox.setTextOfLabel("[Player]", "Quoi ?! Nous sommes en 1801 ?! Comment est-ce possible je viens de 2023");
		_dialogBox.available("displayText");
	}
}
