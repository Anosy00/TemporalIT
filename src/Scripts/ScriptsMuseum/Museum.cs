using Godot;

namespace TemporalIT.Scripts.ScriptsMuseum;

public struct Sentence
{
	public readonly string Name;
	public readonly string Text;
	
	public Sentence(string name, string text){
		Name = name;
		Text = text;
	}
}

public partial class Museum : TileMap
{
	private DialogBox.DialogBox _dialogBox;
	private Godot.Timer _timer;
	private int _nbTimer;

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
		_dialogBox = new DialogBox.DialogBox(GetNode<Sprite2D>("Player/DialogBox"),
			GetNode<Label>("Player/DialogBox/LabelText2"),
			GetNode<Label>("Player/DialogBox/LabelName"),
			GetNode<AnimationPlayer>("Player/DialogBox/AnimationPlayer"));
		_dialogBox.disable();
		_timer = GetNode<Godot.Timer>("Timer");
		
		/*GD.Print(""+_dialog1[0]._name);
		GD.Print(""+_dialog1[0]._text);
		GD.Print(""+_dialogBox, _timer);*/
		
		SetIndex(0);
		//GD.Print("Le ZIndex de la scene est "+getZIndex());
		DisplayDialogBox(_dialog1[0].Name, _dialog1[0].Text, _dialogBox);
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
	
	
	
	
	public static void DisplayDialogBox(string name, string text, DialogBox.DialogBox dialogBox)
	{
		dialogBox.setTextOfLabel(name, text);
		dialogBox.available("display_text");
	}
	private void _on_timer_timeout()
	{
		_nbTimer ++;
		if (_nbTimer == _dialog1.Count ) {
			_timer.Stop();
			_dialogBox.disable();
		} else {
			DisplayDialogBox(_dialog1[_nbTimer].Name, _dialog1[_nbTimer].Text, _dialogBox);
			_timer.Start(6);
		}
		
	}
	
	public static CollisionShape2D GetCollisionShapePlayer(Node rootNode, string path)
	{
		// Utilisez la référence rootNode pour accéder au sous-noeud
		return rootNode.GetNode<CollisionShape2D>(path);
	}
	public static CharacterBody2D GetCharacterBody2D(Node rootNode, string path)
	{
		// Utilisez la référence rootNode pour accéder au sous-noeud
		return rootNode.GetNode<CharacterBody2D>(path);
	}
	private int GetIndex()
	{
		return ZIndex;
	}
	private void SetIndex(int number)
	{
		ZIndex = number;
	}
	
}