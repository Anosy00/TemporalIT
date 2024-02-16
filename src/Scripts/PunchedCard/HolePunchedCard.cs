using Godot;
using System;

public partial class HolePunchedCard : Node
{
	private int numberOfHoles;
	private String nameOfPicture;
	private AnimatedSprite2D nodeOfHole;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		initializing();
	}
	
	private void initializing() {
		
		
		Node ParentNode = GetNode("TheHoles");
		numberOfHoles = ParentNode.GetChildCount();
		int j = 0;
		//GD.Print(Global.getRoomNumber(),", ",numberOfHoles);
		if (Global.getRoomNumber() <= numberOfHoles)
		{
			while (j != numberOfHoles)
			{
				j = j + 1;
				//GD.Print(i);
				nameOfPicture = "TheHoles/AnimatedSprite2D" + j; //HolePunchedCard
				nodeOfHole = (AnimatedSprite2D)GetNode(nameOfPicture);
				
				if (j <= Global.getRoomNumber() )
				{
					nodeOfHole.Visible = true;
					if (j == Global.getRoomNumber()){
						nodeOfHole.Stop();
						nodeOfHole.Play("default");
					}
					
				}else
				{
					nodeOfHole.Visible = false;
				}
				//GD.Print(nameOfPicture,", ",j,", ",nodeOfHole.Visible);

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
	private void _on_animated_sprite_2d_animation_finished()
	{
		nodeOfHole.Stop();
	}
	
}

