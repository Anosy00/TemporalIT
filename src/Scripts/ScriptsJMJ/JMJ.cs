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
		_objectif = GetNode<Sprite2D>("../TileMap/Objectif");
		_labelObjectif = GetNode<Label>("../TileMap/Objectif/Label");
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
		if (nbTimer == DialogJMJ._dialog1.Count || nbTimer == 4 && GlobalJMJ.nbPlanks < 2 || nbTimer == 6 && !GlobalJMJ.hasString) {
			_timer.Stop();
			_dialogBox.disable();
			if (nbTimer == 6)
			{
				_labelObjectif.Text = "Trouver du fil \n Indice : Date de décès dans le journal";
			}
			_objectif.Visible = true;
		} else {
			
			if (nbTimer != 4)
			{
				_timer.Start(3);
				
			}
			if (nbTimer == 6)
			{
				_dialogBox.setCanCloseDialogBox(true);
			}
			GlobalJMJ.displayDialogBox(DialogJMJ._dialog1[nbTimer]._name, DialogJMJ._dialog1[nbTimer]._text, _dialogBox);
			nbTimer ++;
		}
		

	}

	
}
