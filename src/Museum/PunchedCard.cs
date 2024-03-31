using Godot;
using System;

public partial class PunchedCard : Node2D
{
	private Dictionary<string, string> _uniqueTexts1 = LanguageManager.getUniqueTexts("Museum/Texts/unique_textsPunchedCard.json");

	public override void _Ready(){
		GetNode<Label>("Label").Text = _uniqueTexts1["Continue"];
	}
}
