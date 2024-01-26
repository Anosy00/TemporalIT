using Godot;
using System;

public partial class HolePunchedCard : Node
{
	private int numberOfHoles;
	private String nameOfPicture;
	
	// Instance du singleton
	private static HolePunchedCard _instance;


	// Méthode statique pour émettre le signal
	public static void EmitMySignal()
	{
		// Émettre le signal à partir de l'instance du singleton
		//GD.Print("La Méthode EmitMySignal() à bien été appelée");
		_instance.EmitSignal("script_changed");
		
	}


	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		initializing();
	}
	
	private void initializing() {
		
		if (_instance == null)
		{
			_instance = this;
			GD.Print("Singleton initialized.");
		}
		else
		{
			GD.Print("Singleton already exists.");
		}
		Node ParentNode = GetNode("TheHoles");
		numberOfHoles = ParentNode.GetChildCount();
		for (int i = 1; i< numberOfHoles+1; i++) {
			nameOfPicture = "TheHoles/HolePunchedCard" + i;
			//GD.Print(nameOfPicture);
			Sprite2D nodeOfHole = (Sprite2D)GetNode(nameOfPicture);
			nodeOfHole.Visible = false;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		/*if (Input.IsActionPressed("closeDialog"))
		{
			Input.ActionRelease("closeDialog");
			
		}*/
	}
	
	
	 public void _addHole()
	{
		bool ok = false;
		int i=0;
		while (ok==false && i != numberOfHoles) {
			i=i+1;
			//GD.Print(i);
			nameOfPicture = "TheHoles/HolePunchedCard" + i;
			Sprite2D nodeOfHole = (Sprite2D)GetNode(nameOfPicture);
			if (nodeOfHole.Visible == false){
				nodeOfHole.Visible=true;
				ok=true;
			}
			
		}
		//GD.Print("Le signal s'est bien lancé");
	}
}

/*using Godot;
using System;

public class ScriptDeSceneB : Node
{
	public override void _Ready()
	{
		// Récupérer la référence au nœud du bouton PunchedCard dans la hiérarchie
		Button punchedCardButton = GetNodeOrNull<Button>("/root/PunchedCard/ButtonPunchedCard");

		// Vérifier si le nœud du bouton PunchedCard existe et le connecter au signal si c'est le cas
		if (punchedCardButton != null)
		{
			// Connecter le signal "add_a_hole" du bouton à la méthode de gestion "_addHole" dans SceneB
			punchedCardButton.Connect("add_a_hole", this, "_addHole");
		}
		else
		{
			GD.Print("Nœud du bouton PunchedCard non trouvé dans la hiérarchie.");
		}
	}

	// Méthode appelée en réponse au signal "add_a_hole"
	private void _addHole(uint holeIndex)
	{
		GD.Print("SceneB a reçu le signal 'add_a_hole' du bouton PunchedCard avec un trou à l'index :", holeIndex);
	}
}
*/

