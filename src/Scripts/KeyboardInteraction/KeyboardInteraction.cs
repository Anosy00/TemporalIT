using Godot;
using System;

namespace TemporalIT.Scripts.KeyboardInteraction
{
	public partial class KeyboardInteraction : Node
	{
		private AnimatedSprite2D _keyInteraction;
		
		public KeyboardInteraction(AnimatedSprite2D keyInteraction)
		{
			this._keyInteraction = keyInteraction;
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
	}
}