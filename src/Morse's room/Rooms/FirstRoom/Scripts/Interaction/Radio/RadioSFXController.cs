using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

public partial class RadioSFXController : VBoxContainer
{
	//Elements
	private Button _playButton;
	private AudioStreamPlayer _morseCodeSound;
	private float _timePosition;
	private ProgressBar _progressBar;

	private bool _playing = false;
	
	//Const
	private const String _MORSE_CODE_SOUND_PATH = "AudioStreamPlayer";
	private const String _PROGRESS_BAR_PATH = "ProgressMorseCodeSFX";
	private const String _PLAY_BUTTON = "ButtonPlayPauseRetry/Play";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Music.StopMusic();
		_morseCodeSound = GetNode<AudioStreamPlayer>(_MORSE_CODE_SOUND_PATH);
		_progressBar = GetNode<ProgressBar>(_PROGRESS_BAR_PATH);
		_playButton = GetNode<Button>(_PLAY_BUTTON);
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
		if (_playing)
		{
			_playButton.Text = " || ";
			_timePosition = _morseCodeSound.GetPlaybackPosition();
			_morseCodeSound.Playing = false;
			_playing = false;
		}
		else
		{
			_playButton.Text = " \u25b6 \ufe0f\ufe0f ";
			_morseCodeSound.Play(_timePosition);
			_playing = true;
		}
	}
	
	public void _on_retry_pressed()
	{
		_morseCodeSound.Playing = false;
		_timePosition = 0;
		_playButton.Text = " || ";
		_playing = false;
	}
}
