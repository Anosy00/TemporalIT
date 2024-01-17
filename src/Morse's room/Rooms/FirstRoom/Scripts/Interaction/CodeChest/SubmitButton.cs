using Godot;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest;

public partial class SubmitButton : Node
{
	//OBJECTs
	private Button _submitButton;
	private CodeVerification _codeVerification;
	private LineEdit _codeEntered;
	
	//CONSTs
	private const int CorrectAnswer = 2023;
	private const string PathChestIsOpened = "res://Morse's room/Rooms/FirstRoom/MorseInstruction.tscn";
	private const string PathSubmitButton = "SubmitButton";
	private const string PathCodeEnteredLineEdit = "CodeEntered";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		_submitButton = GetNode<Button>(PathSubmitButton);
		_codeEntered = GetNode<LineEdit>(PathCodeEnteredLineEdit);
	}

	private void _on_submit_pressed()
	{
		_codeVerification = new CodeVerification(CorrectAnswer);
		_codeVerification.Verification(int.Parse(_codeEntered.Text));
		ChangeSceneWhenCodeIsGood();
	}

	private void _on_code_entered_text_changed(string newText)
	{
		if (!IsNumber(newText))
		{
			_codeEntered.Text = _codeEntered.Text.Substring(0, _codeEntered.Text.Length - 1);
		}
	}

	private static bool IsNumber(string text)
	{
		return float.TryParse(text, out _);
	}
	
	private void ChangeSceneWhenCodeIsGood()
	{
		if (_codeVerification.ChestIsOpened())
		{
			GetTree().ChangeSceneToFile(PathChestIsOpened);
		}
		else
		{
			_codeEntered.Text = "";
		}
	}
}