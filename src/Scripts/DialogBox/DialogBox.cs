using Godot;
using System;
using System.Data;

public partial class DialogBox : Node
{
	private Sprite2D _dialogBox;
	private Label _labelText;
	private Label _labelName;
	private AnimationPlayer _animationPlayer;
	private bool _canCloseDialogBox;

	public DialogBox(Sprite2D dialogBox, Label labelText, Label labelName, AnimationPlayer animationPlayer)
	{
		_dialogBox = dialogBox;
		_labelText = labelText;
		_labelName = labelName;
		_animationPlayer = animationPlayer;
		_canCloseDialogBox = false;
	}
	
	public void disable()
	{
		_dialogBox.Visible = false;
		_animationPlayer.Stop();
		Global.isDialogActive = false;
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
		Global.isDialogActive = true;
	}

	

	public bool isVisible()
	{
		return _dialogBox.IsVisibleInTree();
	}

	public void setTextOfLabel(String name, String text)
	{
		_labelName.Text = name;
		_labelText.Text = text;
	}

	public AnimationPlayer getAnimationPlayer()
	{
		return _animationPlayer;
	}

	public int closeDialogBox()
	{
		if (Input.IsActionPressed("closeDialog") && isVisible() && _canCloseDialogBox)
		{
			disable();
			return 0;
		}

		return 1;
	}
	
	public void setCanCloseDialogBox(bool canCloseDialogBox)
	{
		_canCloseDialogBox = canCloseDialogBox;
	}
	
}
