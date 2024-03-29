using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.DialogBox;

public partial class ButtonClose : Button
{
	private DialogBox _dialogBox;
	List<Sentence>_dialog1 = LanguageManager.GetSequentialSentences("JMJ's Room/Texts/DialoguesSaddler.json");
	
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
		if (!GlobalJMJ.hadInteractedWithNewsPaper)
		{
			_dialogBox.setTextOfLabel(_dialog1[0]._speaker, _dialog1[0]._text);
			_dialogBox.available("displayText");
			GlobalJMJ.hadInteractedWithNewsPaper = true;
		}
		else
		{
			Global.isDialogActive = false;
		}
	}
}