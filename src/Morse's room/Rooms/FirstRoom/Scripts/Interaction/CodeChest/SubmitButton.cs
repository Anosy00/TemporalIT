using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest;

public partial class SubmitButton : Node
{
	//OBJECTs
	private Button _submitButton;
	private CodeVerification _codeVerification;
	private LineEdit _codeEntered;
	
	//CONSTs
	private const int _CORRECT_ANSWER = 2023;
	private const String _PATH_CHEST_IS_OPENED = "res://Morse's room/Rooms/FirstRoom/MorseInstruction.tscn";
	private const String _PATH_SUBMIT_BUTTON = "SubmitButton";
	private const String _PATH_CODE_ENTERED_LINE_EDIT = "CodeEntered";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		_submitButton = GetNode<Button>(_PATH_SUBMIT_BUTTON);
		_codeEntered = GetNode<LineEdit>(_PATH_CODE_ENTERED_LINE_EDIT);
	}
	
	public void _on_submit_pressed()
	{
		_codeVerification = new CodeVerification(_CORRECT_ANSWER);
		_codeVerification.verfication(int.Parse(_codeEntered.Text));
		changeSceneWhenCodeIsGood();
	}
	
	public void _on_code_entered_text_changed(string newText)
	{
		if (!IsNumber(newText))
		{
			_codeEntered.Text = _codeEntered.Text.Substring(0, _codeEntered.Text.Length - 1);
		}
	}

	private bool IsNumber(string text)
	{
		return float.TryParse(text, out _);
	}
	
	private void changeSceneWhenCodeIsGood()
	{
		if (_codeVerification.chestIsOpened())
		{
			GetTree().ChangeSceneToFile(_PATH_CHEST_IS_OPENED);
		}
		else
		{
			_codeEntered.Text = "";
		}
	}
}
