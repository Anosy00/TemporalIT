using Godot;
using System;

public partial class ContinueButton : VBoxContainer
{

	private Button _continueButton;
	private const String _BUTTON_PATH = "Button";

	private LineEdit _name;
	private const String _LINE_EDIT_PATH = "LineEdit";

	private const String _NEXT_SCENE_PATH = "res://Museum/MuseumMap.tscn";
	
	public override void _Ready()
	{
		_continueButton = GetNode<Button>(_BUTTON_PATH);
		_name = GetNode<LineEdit>(_LINE_EDIT_PATH);
	}

	public void _on_button_pressed()
	{
		if (_name.Text.Equals(""))
		{
			Global.playerName = "Tux";
		}
		else
		{
			Global.playerName = _name.Text;
		}

		GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
	}
	
}
