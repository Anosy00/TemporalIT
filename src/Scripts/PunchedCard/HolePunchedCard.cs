using Godot;
using System;

public partial class HolePunchedCard : Node
{
	private int numberOfHoles;
	private String nameOfPicture;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		initializing();
	}
	
	private void initializing() {
		
		//GD.Print(Global.getRoomNumber(),", ",numberOfHoles);
		Node ParentNode = GetNode("TheHoles");
		numberOfHoles = ParentNode.GetChildCount();
		int j = 0;
		
		if (Global.getRoomNumber() <= numberOfHoles)
		{
			while (j != numberOfHoles)
			{
				j = j + 1;
				//GD.Print(i);
				nameOfPicture = "TheHoles/HolePunchedCard" + j;
				Sprite2D nodeOfHole = (Sprite2D)GetNode(nameOfPicture);
				
				if (j <= Global.getRoomNumber() )
				{
					nodeOfHole.Visible = true;
					
				}else
				{
					nodeOfHole.Visible = false;
				}
				GD.Print(nameOfPicture,", ",j,", ",nodeOfHole.Visible);

			}
		}else
		{
			GD.Print("Erreur, Le numéro de la scène indiquée ne correspond pas au nombre de trous disponible");
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	
}




