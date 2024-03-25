using Godot;
using System;
using TemporalIT;
using TemporalIT.Scripts.DialogBox;
using Timer = Godot.Timer;

public partial class JMJ : Area2D
{
	private EButton _keyboardInteration;
	private const String _NAME_OF_THE_ANIMATION = "default";
	private DialogBox _dialogBox;
	private Timer _timer;
	private static int nbTimer = 0;
	private Sprite2D _objectif;
	private Label _labelObjectif;
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
		_objectif = GetNode<Sprite2D>("../Objectif");
		_labelObjectif = GetNode<Label>("../Objectif/LabelText");
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
		_dialogBox.disable();
		GlobalJMJ.canInteractWithPlanks = true;
		if (nbTimer == DialogJMJ._dialog1.Count || nbTimer == 4 && GlobalJMJ.nbPlanks < 2 || nbTimer == 7 && !GlobalJMJ.hasString) {
			_timer.Stop();
			_dialogBox.disable();
			GlobalJMJ.isObjActive = false;
			if (nbTimer == 7)
			{
				
				_labelObjectif.Text = "Trouver du fil \n Indice : Date de décès dans le journal";
				_labelObjectif.AddThemeFontSizeOverride("font_size", 35);
				GlobalJMJ.isObjActive = true;
				GlobalJMJ.objectifPlankActive = false;
				GlobalJMJ.objectifStringActive = true;
			}
			else
			{
				GlobalJMJ.isObjActive = true;
				GlobalJMJ.objectifPlankActive = true;
			}
			
		} else {

			if (GlobalJMJ.nbPlanks < 2)
			{
				if (nbTimer != 3)
				{
					_timer.Start(3);
				
				}
				if (nbTimer == 6)
				{
					_dialogBox.setCanCloseDialogBox(true);
				}
			}
			
			

			else
			{
				_dialogBox.setCanCloseDialogBox(false);
				_timer.Start();
				
			}
			
			
			GlobalJMJ.displayDialogBox(DialogJMJ._dialog1[nbTimer].Name, DialogJMJ._dialog1[nbTimer].Text, _dialogBox);
			nbTimer ++;
		}
		

	}

	
}
