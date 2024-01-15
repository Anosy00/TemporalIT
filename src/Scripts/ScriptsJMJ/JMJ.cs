using Godot;
using System;
using TemporalIT;

public partial class JMJ : Area2D
{
	private EButton _keyboardInteration;
	private const String _E_BUTTON = "button_e";
	private const String _NAME_OF_THE_ANIMATION = "default";
	private DialogBox _dialogBox;
	private Timer _timer;
	private int nbTimer = 0;

	private const String _nextScene = "res://JMJ's Room/Room/Saddler.tscn";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_keyboardInteration = new EButton(GetNode<AnimatedSprite2D>("EButtonJMJSprite"));
		_keyboardInteration.disable();
		_dialogBox = new DialogBox(GetNode<Sprite2D>("../TileMap/DialogBox"),
			GetNode<Label>("../TileMap/DialogBox/LabelText"),
			GetNode<Label>("../TileMap/DialogBox/LabelName"),
			GetNode<AnimationPlayer>("../TileMap/DialogBox/AnimationPlayer"));
		_dialogBox.disable();
		_timer = GetNode<Timer>("Timer");
		_dialogBox.setCanCloseDialogBox(false);
	}
	
	public void _on_area_2d_body_entered(CharacterBody2D body)
	{
		_keyboardInteration.available(_NAME_OF_THE_ANIMATION);
	}
	
	public void _on_body_exited(CharacterBody2D body)
	{
		_keyboardInteration.disable();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_keyboardInteration.makeTalking() == 0)
		{
			if (GlobalJMJ.nbOfInteractionWithJMJ == 0)
			{
				_dialogBox.setTextOfLabel("???", "Mais qui êtes vous ? Que faites vous ici ?");
				_dialogBox.available("displayText");
				_timer.Start();
				GlobalJMJ.nbOfInteractionWithJMJ++;
			}

			else
			{
				_timer.EmitSignal("timeout");
			}
			
		}
	}


	
	private void _on_timer_timeout()
	{
		GlobalJMJ.canInteractWithPlanks = true;
		if (nbTimer == DialogJMJ._dialog1.Count ) {
			_timer.Stop();
			_dialogBox.disable();
		} else {
			
			if (nbTimer == 5 && GlobalJMJ.nbPlanks < 2)
			{
				nbTimer--;
			}
			else if (nbTimer != 4)
			{
				_timer.Start(3);
				
			}
			GlobalJMJ.displayDialogBox(DialogJMJ._dialog1[nbTimer]._name, DialogJMJ._dialog1[nbTimer]._text, _dialogBox);
		}
		nbTimer ++;

	}

	
}
