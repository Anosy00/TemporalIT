using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.ScriptsJMJ;

public partial class NewsPaper : Node
{
	private EButton _keyboardInteration;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";
	private static Sprite2D _newsPaper;
	private static Button _button;

	public override void _Ready()
	{
		_keyboardInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonPaperSprite"));
		_keyboardInteration.disable();
		_newsPaper = GetNode<Sprite2D>("NewsPaper");
		_button = GetNode<Button>("ButtonClose");
	}

	public void _on_area_2d_body_entered(CharacterBody2D body)
	{
		_keyboardInteration.available(_NAME_OF_THE_ANIMATION);
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_keyboardInteration.disable();
	}

	public static void setInvisibleNewsPaper()
	{
		_newsPaper.Visible = false;
		_button.Visible = false;
	}
	
	public override void _Process(double delta)
	{
		
		if (Input.IsActionPressed(_E_BUTTON) && _keyboardInteration.isVisible())
		{
			_newsPaper.Visible = true;
			_button.Visible = true;
			Global.isDialogActive = true;
			GlobalJmj.hadInteractedWithNewsPaper = true;
		}
		
		
	}
}
