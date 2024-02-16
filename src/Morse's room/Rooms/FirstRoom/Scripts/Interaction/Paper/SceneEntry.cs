using Godot;
using System;

public partial class SceneEntry : Sprite2D
{
	private AnimationPlayer _animation;

	private const String _PATH_ANIMATION = "AnimationPlayer";

	private const String _NAME_OF_THE_ANIMATION = "instructionCard";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animation = GetNode<AnimationPlayer>(_PATH_ANIMATION);
		_animation.Play(_NAME_OF_THE_ANIMATION);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
