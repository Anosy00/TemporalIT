using Godot;
using System;

public partial class EButtonPaper : EButtonAbstract
{
	private AnimatedSprite2D _eButton;
	private static Sprite2D _newsPaper;
	private static Button _buttonClose;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_eButton = GetNode<AnimatedSprite2D>("EButtonPaperSprite");
		_newsPaper = GetNode<Sprite2D>("NewsPaper");
		_buttonClose = GetNode<Button>("ButtonClose");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact") && _eButton.IsVisibleInTree())
		{
			Global.hadInteractedWithNewsPaper = true;
			_newsPaper.Visible = true;
			_buttonClose.Visible = true;
		}
		
	}
	
	void _on_area_2d_body_entered(CharacterBody2D body)
	{
		_eButton.Visible = true;
		_eButton.Play("animation");
	}

	void _on_body_exited(CharacterBody2D body)
	{
		_eButton.Visible = false;
		_eButton.Stop();
	}

	public static void closeNewsPaper()
	{
		_newsPaper.Visible = false;
		_buttonClose.Visible = false;
	}
}
