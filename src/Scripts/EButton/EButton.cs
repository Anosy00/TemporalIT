using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.ScriptsJMJ;

public partial class EButton : Node
{
	private AnimatedSprite2D _keyInteraction;
	private AnimationPlayer _transitionAnimation;
		
	public EButton(AnimatedSprite2D keyInteraction)
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
		return _keyInteraction.IsVisibleInTree();
	}
		
	public int makeInteraction(SceneTree tree,String key,String nextScenePath)
	{
		if (Input.IsActionPressed(key) && isVisible() && GlobalJmj.hadInteractedWithNewsPaper)
		{
			tree.ChangeSceneToFile(nextScenePath);
			return 0;
		}
		else if (Input.IsActionPressed(key) && isVisible() && !GlobalJmj.hadInteractedWithNewsPaper)
		{
			return 1;
		}

		return 2;
	}

	public int makeTalking()
	{
		if (Input.IsActionPressed("button_e") && isVisible())
		{
			return 0;
		}

		return 1;
	}
}
