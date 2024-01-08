using Godot;
using System;
using System.Data;

public partial class DialogBox : Node
{
	private Sprite2D _dialogBox;
	private Label _labelText;
	private Label _labelName;
	private AnimationPlayer _animationPlayer;

	public DialogBox(Sprite2D dialogBox, Label labelText, Label labelName, AnimationPlayer animationPlayer)
	{
		_dialogBox = dialogBox;
		_labelText = labelText;
		_labelName = labelName;
		_animationPlayer = animationPlayer;
	}
	
	public void disable()
	{
		_dialogBox.Visible = false;
		_animationPlayer.Stop();
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void available(String nameOfTheAnimation)
	{
		_dialogBox.Visible = true;
		_animationPlayer.Play(nameOfTheAnimation);
	}

	

	public bool isVisible()
	{
		return _dialogBox.IsVisibleInTree();
	}

	public void setText(String name, String text)
	{
		_labelName.Text = name;
	}

	public AnimationPlayer getAnimationPlayer()
	{
		return _animationPlayer;
	}
}
