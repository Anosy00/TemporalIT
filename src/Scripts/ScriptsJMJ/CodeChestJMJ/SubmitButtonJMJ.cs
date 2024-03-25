using Godot;
using System;
using TemporalIT;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest;

public partial class SubmitButtonJMJ : Node
{
	//OBJECTs
	private Button _submitButton;
	private CodeVerificationJMJ _codeVerification;
	private LineEdit _codeEntered;
	
	//CONSTs
	private int _CORRECT_ANSWER;
	private const String _PATH_NEXT_SCENE = "res://JMJ's Room/Room/Saddler.tscn";
	private const String _PATH_CODE_ENTERED_LINE_EDIT = "../CodeEntered";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		_CORRECT_ANSWER = 3110;
		_codeEntered = GetNode<LineEdit>(_PATH_CODE_ENTERED_LINE_EDIT);
	}

	public void _on_submit_pressed()
	{
		_codeVerification = new CodeVerificationJMJ(_CORRECT_ANSWER);
		_codeVerification.verfication(int.Parse(_codeEntered.Text));
		changeSceneWhenCodeIsGood();
	}
	
	private void changeSceneWhenCodeIsGood()
	{
		if (_codeVerification.chestIsOpened())
		{
			GlobalJMJ.hasString = true;
			GlobalJMJ.canInteractWithMachine = true;
			GetTree().ChangeSceneToFile(_PATH_NEXT_SCENE);
		}
		else
		{
			_codeEntered.Text = "";
		}
	}
}
