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
	private Godot.Timer _timer;
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
		_timer = GetNode<Godot.Timer>("Timer");
		
		/*GD.Print(""+_dialog1[0]._name);
		GD.Print(""+_dialog1[0]._text);
		GD.Print(""+_dialogBox, _timer);*/
		
		setZIndex(0);
		//GD.Print("Le ZIndex de la scene est "+getZIndex());
		GlobalMuseum.displayDialogBox(_dialog1[0]._name, _dialog1[0]._text, _dialogBox, _timer);
		_timer.Start(6);
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("closeDialog") && _dialogBox.isVisible())
		{
			_timer.Stop();
			Input.ActionRelease("closeDialog");
			_timer.EmitSignal("timeout");
		}
	}
	
	
	
	
	public static void displayDialogBox(string name, string text, DialogBox dialogBox)
	{
		dialogBox.setTextOfLabel(name, text);
		dialogBox.available("display_text");
	}
	private void _on_timer_timeout()
	{
		nbTimer ++;
		if (nbTimer == _dialog1.Count ) {
			_timer.Stop();
			_dialogBox.disable();
		} else {
			displayDialogBox(_dialog1[nbTimer]._name, _dialog1[nbTimer]._text, _dialogBox);
			_timer.Start(6);
		}
		
	}
	
	public static CollisionShape2D getCollisionShapePlayer(Node rootNode, string path)
	{
		// Utilisez la référence rootNode pour accéder au sous-noeud
		return rootNode.GetNode<CollisionShape2D>(path);
	}
	public static CharacterBody2D getCharacterBody2D(Node rootNode, string path)
	{
		// Utilisez la référence rootNode pour accéder au sous-noeud
		return rootNode.GetNode<CharacterBody2D>(path);
	}
	private int getZIndex()
	{
		return this.ZIndex;
	}
	private void setZIndex(int number)
	{
		this.ZIndex = number;
	}
	
}



