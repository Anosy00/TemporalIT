using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.DialogBox;

public partial class ButtonClose : Button
{
	private DialogBox.DialogBox _dialogBox;
	
	public override void _Ready()
	{
		_dialogBox = new DialogBox.DialogBox(GetNode<Sprite2D>("../../DialogBox"),
			GetNode<Label>("../../DialogBox/LabelText"),
			GetNode<Label>("../../DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../../DialogBox/AnimationPlayer"));
		_dialogBox.disable();
	}
	public void _on_pressed()
	{
		NewsPaper.setInvisibleNewsPaper();
		if (!GlobalJMJ.hadInteractedWithNewsPaper)
		{
			_dialogBox.setTextOfLabel("[Player]", "Quoi ?! Nous sommes en 1801 ?! Comment est-ce possible je viens de 2023");
			_dialogBox.available("displayText");
			GlobalJMJ.hadInteractedWithNewsPaper = true;
		}
		else
		{
			Global.isDialogActive = false;
		}
		

	}
}