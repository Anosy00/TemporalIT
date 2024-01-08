using Godot;
using System;

namespace TemporalIT.Transition
{
	public partial class TransitionScript : CanvasLayer
	{
		//TODO make transition between the scenes
		public AnimationPlayer animationPlayer;
		public override void _Ready()
		{
			animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		}

		public void transitionTo(String nextScenePath)
		{
			animationPlayer.Play("Fade");
			ToSignal(animationPlayer, "animation_finished");
			GetTree().ChangeSceneToFile(nextScenePath);
			animationPlayer.PlayBackwards("Fade");
		}
	}
}
