using Godot;
using System;
using System.Collections.Generic;
using TemporalIT;

public struct Sentence
{
	public string _name;
	public string _text;
	
	public Sentence(string name, string text){
		_name = name;
		_text = text;
	}
}

public partial class Museum : TileMap
{
	private DialogBox _dialogBox;
	private Timer _timer;
	private int nbTimer = 0;

	private List<Sentence>_dialog1 = new List<Sentence>
	{
		new Sentence("Narrateur", "Bienvenue au Musée de l’informatique ! Dans ce jeu, les dialogues passent automatiquement au suivant au bout de quelques secondes."),
		new Sentence("Narrateur", "Dans ce jeu, tu devras résoudre des énigmes pour avancer dans l'histoire, donc prête attention à tous les détails."),
		new Sentence("Narrateur", "Commence par lire les descriptions des différentes machines qui ont marqué l'histoire de l'informatique."),
		new Sentence("Narrateur", "Utilise les flèches de ton clavier pour bouger ton personnage, et la touche E pour intéragir avec les éléments."),
	};
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_dialogBox = new DialogBox(GetNode<Sprite2D>("Player/DialogBox"),
			GetNode<Label>("Player/DialogBox/LabelText2"),
			GetNode<Label>("Player/DialogBox/LabelName"),
			GetNode<AnimationPlayer>("Player/DialogBox/AnimationPlayer"));
		_dialogBox.disable();
		_timer = GetNode<Timer>("Timer");
		
		/*GD.Print(""+_dialog1[0]._name);
		GD.Print(""+_dialog1[0]._text);
		GD.Print(""+_dialogBox, _timer);*/
		
		GlobalMuseum.displayDialogBox(_dialog1[0]._name, _dialog1[0]._text, _dialogBox, _timer);
		_timer.Start(6);
	}

	private void _on_timer_timeout()
	{
		nbTimer++;
		switch (nbTimer)
		{
			case 1:
				GlobalMuseum.displayDialogBox(_dialog1[1]._name, _dialog1[1]._text, _dialogBox, _timer);
				_timer.Start(6);
				break;
			case 2:
				GlobalMuseum.displayDialogBox(_dialog1[2]._name, _dialog1[2]._text, _dialogBox, _timer);
				_timer.Start(6);
				break;
			case 3:
				GlobalMuseum.displayDialogBox(_dialog1[3]._name, _dialog1[3]._text, _dialogBox, _timer);
				_timer.Start(6);
				break;
			case 4:
				_timer.Stop();
				_dialogBox.disable();
				break;
	}
		
	}
}



