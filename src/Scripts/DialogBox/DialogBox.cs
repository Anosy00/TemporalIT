using Godot;
using System;
using System.Data;

public partial class DialogBox : Node
{
	private Sprite2D _dialogBox;
	private Label _labelText;
	private Label _labelName;
	private AnimationPlayer _animationPlayer;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_dialogBox = GetNode<Sprite2D>("DialogBox");
		_labelText = GetNode<Label>("LabelText");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void available(String nameOfTheAnimation)
	{
		_dialogBox.Visible = true;
		_animationPlayer.Play(nameOfTheAnimation);
	}

	public void disable()
	{
		_dialogBox.Visible = false;
		_animationPlayer.Stop();
	}

	public bool isVisible()
	{
		return _dialogBox.IsVisibleInTree();
	}

	public void setText(String text)
	{
		
	}
}
