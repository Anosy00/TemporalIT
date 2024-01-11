using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

public partial class RadioSFXController : VBoxContainer
{
	//Elements
	private Button _playButton;
	private Button _pauseButton;
	private Button _retryButton;
	private AudioStreamPlayer _morseCodeSound;
	private float _timePosition;
	private ProgressBar _progressBar;
	
	//Const
	private const String _MORSE_CODE_SOUND_PATH = "AudioStreamPlayer";
	private const String _PROGRESS_BAR_PATH = "ProgressMorseCodeSFX";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Music.stopMusic();
		_morseCodeSound = GetNode<AudioStreamPlayer>(_MORSE_CODE_SOUND_PATH);
		_progressBar = GetNode<ProgressBar>(_PROGRESS_BAR_PATH);
	}

	public override void _Process(double delta)
	{
		if (_morseCodeSound.Playing == true)
		{
			_timePosition = _morseCodeSound.GetPlaybackPosition();
			_progressBar.Value = (_timePosition / 19) * 100;
		}
		_progressBar.Value = (_timePosition/19)*100;
	}

	public void _on_play_pressed()
	{
		_morseCodeSound.Play(_timePosition);
	}
	
	public void _on_pause_pressed()
	{
		_timePosition = _morseCodeSound.GetPlaybackPosition();
		_morseCodeSound.Playing = false;
	}
	
	public void _on_retry_pressed()
	{
		_morseCodeSound.Playing = false;
		_timePosition = 0;
	}
}
