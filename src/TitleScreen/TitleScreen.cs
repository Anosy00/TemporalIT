using Godot;
using System;
using PausedMenu;

public partial class TitleScreen : Node
{
	private PausedMenu.PausedMenu _pausedMenu;

	private Dictionary<string, string>_uniqueTexts1 = LanguageManager.getUniqueTexts("TitleScreen/Texts/unique_texts.json");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pausedMenu = new PausedMenu.PausedMenu();
		GetNode<Button>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/StartButton").Text = _uniqueTexts1["Play"];
		GetNode<Button>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/OptionsButton").Text = _uniqueTexts1["Options"];
		GetNode<Button>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/CreditsButton").Text = _uniqueTexts1["Credits"];
		GetNode<Button>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/ExitButton").Text = _uniqueTexts1["Exit"];
	}
}
