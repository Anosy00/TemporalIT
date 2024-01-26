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
	private void _on_ready()
	{
		initializing();
	}
	public static void deleteInstance(){
		_instance=null;
	}
}




