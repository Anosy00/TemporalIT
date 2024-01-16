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
	private Control _INTERFACE_TO_CLOSE;
	private Area2D _area2D;
	private const String _PATH_SUBMIT_BUTTON = "SubmitButton";
	private const String _PATH_CODE_ENTERED_LINE_EDIT = "../CodeEntered";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		_CORRECT_ANSWER = 3110;
		_INTERFACE_TO_CLOSE = GetNode<Control>("../../../../CodeChest");
		_submitButton = GetNode<Button>(_PATH_SUBMIT_BUTTON);
		_codeEntered = GetNode<LineEdit>(_PATH_CODE_ENTERED_LINE_EDIT);
		_area2D = GetNode<Area2D>("../../../../TileMap/StringFound");
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
			_INTERFACE_TO_CLOSE.Visible = false;
			_area2D.Visible = true;
		}
		else
		{
			_codeEntered.Text = "";
		}
	}
}
