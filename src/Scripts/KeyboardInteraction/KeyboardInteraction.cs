using Godot;
using System;

namespace TemporalIT.Scripts.KeyboardInteraction
{
	public partial class KeyboardInteraction : Node 
	{
		private AnimatedSprite2D _keyInteraction;
		
		private AnimationPlayer _transitionAnimation;
		
		public KeyboardInteraction(AnimatedSprite2D keyInteraction)
		{
			_keyInteraction = keyInteraction;
		}

		public override void _Ready()
		{
			_transitionAnimation = GetNode<CanvasLayer>("/root/TransitionScene").GetNode<AnimationPlayer>("AnimationPlayer");
		}

		public void available(String nameOfTheAnimation)
		{
			_keyInteraction.Visible = true;
			_keyInteraction.Play(nameOfTheAnimation);
		}
		
		public void disable()
		{
			_keyInteraction.Visible = false;
			_keyInteraction.Stop();
		}

		public bool isVisible()
		{
			return this._keyInteraction.IsVisibleInTree();
		}
		
		public void makeInteraction(SceneTree tree,String key,String nextScenePath)
		{
			if (Input.IsActionPressed(key) && isVisible())
			{
				tree.ChangeSceneToFile(nextScenePath);
			}
		}

		public void onButtonPress(Control node)
		{
			if (Input.IsActionPressed("button_e") && isVisible())
			{
				node.Visible = true;
			}
		}
		public void onButtonPress(Node2D node)
		{
			if (Input.IsActionPressed("button_e") && isVisible())
			{
				node.Visible = true;
			}
		}
		
	}
}
