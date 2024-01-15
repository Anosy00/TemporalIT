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
	private int nbTimer = -1;
	private CollisionShape2D player;
	private Vector2 playerPosition;

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
		GD.Print("",get_PosX_player());
		GD.Print("",get_PosY_player());
		_timer.EmitSignal("timeout");
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
	
	private Vector2 posPlayer()
	{
		player = GetNode<CollisionShape2D>("Player/CollisionShape2D");
		if (player != null)
		{
			// Obtenez les coordonnées globales de l'élément
			playerPosition = player.GlobalPosition;

			// Affichez les coordonnées
			GD.Print("Coordonnées du joueur : (", playerPosition[0]-323,", ", playerPosition[1]-323,")");
			return playerPosition;
		}
		else
		{
			GD.Print("L'élément n'a pas été correctement référencé.");
			return new Vector2(-1f ,-1f);
			
		}
	}
	public float get_PosX_player()
	{
		Vector2 coordinate = posPlayer();
		return coordinate[0]-323;
	}
		
	public float get_PosY_player()
	{
		return posPlayer()[1]-323;
	}
}



