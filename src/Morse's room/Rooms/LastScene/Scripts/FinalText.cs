using Godot;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

namespace TemporalIT.Morse_s_room.Rooms.LastScene.Scripts;

public partial class FinalText : CenterContainer
{
	private AnimationPlayer _animationText;
	private Label _text;

	private const string PathAnimation = "AnimationText";
	private const string PathText = "Camera2D/Label";
	private const string PathCreditsScene = "res://Credits/CreditsScene.tscn";
	
	private const string NameOfTheAnimation = "text-animation";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Music.StopMusic();
		_animationText = GetNode<AnimationPlayer>(PathAnimation);
		_text = GetNode<Label>(PathText);
		_animationText.Play(NameOfTheAnimation);
	}

	public void _on_animation_text_finished(String _animationName)
	{
		GetTree().ChangeSceneToFile(PathCreditsScene);
	}
}