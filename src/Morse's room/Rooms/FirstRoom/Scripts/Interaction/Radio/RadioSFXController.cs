using Godot;
using System;

public partial class RadioSFXController : VBoxContainer
{
	//Elements
	private Button _playButton;
	private Button _pauseButton;
	private Button _retryButton;
	private AudioStreamPlayer _morseCodeSound;
	
	//Const
	private const String _PLAY_BUTTON_PATH = "ButtonPlayPauseRetry/Play";
	private const String _PAUSE_BUTTON_PATH = "ButtonPlayPauseRetry/Pause";
	private const String _RETRY_BUTTON_PATH = "ButtonPlayPauseRetry/Retry";
	private const String _MORSE_CODE_SOUND_PATH = "AudioStreamPlayer";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_playButton = GetNode<Button>(_PLAY_BUTTON_PATH);
		_pauseButton = GetNode<Button>(_PAUSE_BUTTON_PATH);
		_retryButton = GetNode<Button>(_RETRY_BUTTON_PATH);
		_morseCodeSound = GetNode<AudioStreamPlayer>(_MORSE_CODE_SOUND_PATH);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
