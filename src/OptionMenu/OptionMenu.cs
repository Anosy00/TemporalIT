using Godot;
using System;

public partial class OptionMenu : Node
{
	private Dictionary<string, string>_uniqueTexts1 = LanguageManager.getUniqueTexts("OptionMenu/Texts/unique_texts.json");
	public override void _Ready(){
		
		GetNode<Label>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/WindowMode").Text = _uniqueTexts1["WindowedMode"];
		OptionButton WindowMenu = GetNode<OptionButton>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/WindowMenu");
		WindowMenu.SetItemText(0, _uniqueTexts1["Fullscreen"]);
		WindowMenu.SetItemText(1, _uniqueTexts1["Maximized"]);
		WindowMenu.SetItemText(2, _uniqueTexts1["Windowed"]);
		GetNode<Label>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/ResolutionLabel").Text = _uniqueTexts1["Resolution"];

		GetNode<Label>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/VolumeLabel").Text = _uniqueTexts1["Volume"];
		GetNode<Button>("CanvasLayer/Options/CenterContainer/PanelContainer/VBoxContainer/HBoxContainer/ReturnButton").Text = _uniqueTexts1["RETURN"];
	}
}
