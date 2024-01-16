using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

public partial class FinalText : CenterContainer
{
	private AnimationPlayer _animationText;
	private Label _text;

	private const String _PATH_ANIMATION = "AnimationText";
	private const String _PATH_TEXT = "Label";
	private const String _PATH_CREDITS_SCENE = "res://Credits/CreditsScene.tscn";
	
	private const String _NAME_OF_THE_ANIMATION = "text-animation";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Music.stopMusic();
		_animationText = GetNode<AnimationPlayer>(_PATH_ANIMATION);
		_text = GetNode<Label>(_PATH_TEXT);
		_animationText.Play(_NAME_OF_THE_ANIMATION);
	}

	public void _on_animation_text_finished(String _animationName)
	{
		GetTree().ChangeSceneToFile(_PATH_CREDITS_SCENE);
	}
}
