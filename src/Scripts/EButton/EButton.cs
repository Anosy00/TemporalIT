using Godot;
using System;

namespace TemporalIT.Scripts.EButton
{
	public class EButton
	{
		private AnimatedSprite2D _keyInteraction;
		
		public EButton(AnimatedSprite2D keyInteraction)
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
	}
}