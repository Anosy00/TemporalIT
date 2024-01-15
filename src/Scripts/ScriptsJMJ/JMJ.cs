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
			
		}
	}

	private void _on_timer_timeout()
	{
		_dialogBox.disable();
		nbTimer++;
		switch (nbTimer)
		{
			case 1:
				if (GlobalJMJ.nbPlanks < 2)
				{
					GlobalJMJ.displayDialogBox(Global.playerName, "Je m'appelle " + Global.playerName + " il me semble que j'ai voyagé dans le temps !", _dialogBox, _timer);
					_timer.Start();
				}
				else
				{
					nbTimer = 4;
					_timer.EmitSignal("timeout");
				}
				break;
			case 2:
				GlobalJMJ.displayDialogBox("???", "Le voyage dans le temps ?! C'est impossible, mais bon passons j'ai un problème plus important... ", _dialogBox, _timer);
				_timer.Start();
				break;
			case 3:
				GlobalJMJ.displayDialogBox("Jacquard", "Je m'appelle Jean Marie Jacquard et j'ai un problème dans la construction de ma machine, aide moi à la construire !...", _dialogBox, _timer);
				_timer.Start();
				break;
			case 4:
				GlobalJMJ.displayDialogBox("Jacquard", "Récupère moi les deux planches qui traînent dans mon atelier s'il te plaït", _dialogBox, _timer);
				nbTimer = 0;
				GlobalJMJ.canInteractWithPlanks = true;
				break;
			case 5:
				GlobalJMJ.displayDialogBox("Jacquard", "Merci, il nous manque uniquement du fil, tu peux en trouver dans mon coffre en haut...", _dialogBox, _timer);
				_timer.Start();
				break;
			case 6:
				GlobalJMJ.displayDialogBox("Jacquard", "Merci, il nous manque uniquement du fil, tu peux en trouver dans mon coffre en haut...", _dialogBox, _timer);
				break;
		}
		
	}

	
}
