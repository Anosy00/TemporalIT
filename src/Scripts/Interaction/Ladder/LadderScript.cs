using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.KeyboardInteraction;
using Timer = Godot.Timer;

namespace TemporalIT.Scripts.Interaction.Ladder;

public partial class LadderScript : Node
{
	private EButton _keyInteration;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";
	private const String _NEXT_SCENE_PATH = "res://JMJ's Room/Room/Saddler.tscn";
	private Sprite2D _objectif;
	private DialogBox.DialogBox _dialogBox;
	private Timer _timer;

	private Camera2D _camera;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonLadderSprite"));
		_keyInteration.disable();
		_objectif = GetNode<Sprite2D>("../../Objectif");
		_dialogBox = new DialogBox.DialogBox(GetNode<Sprite2D>("../DialogBox"),
			GetNode<Label>("../DialogBox/LabelText"),
			GetNode<Label>("../DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../DialogBox/AnimationPlayer"));
		_dialogBox.disable();
		_dialogBox.setCanCloseDialogBox(false);
		_timer = GetNode<Timer>("../../Timer");
	}
	
	public void _on_area_2d_body_entered(CharacterBody2D body)
	{
		_keyInteration.available(_NAME_OF_THE_ANIMATION);
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_keyInteration.disable();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GlobalJMJ.nbPlanks == 2)
		{
			_keyInteration.makeInteraction(GetTree(), _E_BUTTON, _NEXT_SCENE_PATH);	
		}
		else
		{
			if (Input.IsActionPressed("button_e") && _keyInteration.isVisible() &&
			    GlobalJMJ.nbOfInteractionWithJMJ == 0)
			{
				_dialogBox.setTextOfLabel("[Player]","Je devrais aller parler à cet homme avant...");
				_dialogBox.available("displayText");
				_dialogBox.setCanCloseDialogBox(true);
				_dialogBox.closeDialogBox();
				_timer.Start(2);
			}
			else if (Input.IsActionPressed("button_e") && _keyInteration.isVisible())
			{
				_dialogBox.setTextOfLabel("[Player]","Je devrais récupérer les planches avant de remonter...");
				_dialogBox.available("displayText");
				_dialogBox.setCanCloseDialogBox(true);
				_timer.Start(2);
				
			}
		}
		
		if (GlobalJMJ.isObjActive)
		{
			_objectif.Visible = true;
		}
		else
		{
			_objectif.Visible = false;
		}
	}

	private void _on_timer_timeout()
	{
		_dialogBox.disable();
	}
	
}