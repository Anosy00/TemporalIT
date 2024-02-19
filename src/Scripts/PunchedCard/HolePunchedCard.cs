using Godot;
using System;

public partial class HolePunchedCard : Node
{
	private int numberOfHoles;
	private String nameOfPicture;
	private AnimatedSprite2D nodeOfHolePlayed;
	private int frame;
	int nbFrame=17;
	
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
				frame=0;
				//GD.Print(i);
				nameOfPicture = "TheHoles/AnimatedSprite2D" + j; //HolePunchedCard
				AnimatedSprite2D nodeOfHole = (AnimatedSprite2D)GetNode(nameOfPicture);
				//GD.Print("j = "+j+", nodeOfHole= "+nodeOfHole.Name+" nbframe= "+nbFrame+" Global.getRoomNumber()= "+Global.getRoomNumber()+" numberOfHoles= "+numberOfHoles);
				if (j < Global.getRoomNumber() )
				{
					//GD.Print("inferieur");
					nodeOfHole.Visible = true;
					nodeOfHole.Frame = nbFrame - 1;
					
				}else  if (j == Global.getRoomNumber()){
					//GD.Print("egale");
					nodeOfHole.Visible = true;
					nodeOfHole.Stop();
					nodeOfHole.Play("default");
					nodeOfHolePlayed = nodeOfHole;
					//nbFrame=nodeOfHolePlayed.Frames;
						
				} else 
				{
					//GD.Print("superieur");
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
	
	/*private void _on_animated_sprite_2d_animation_looped()
	{
		int nombreFrames = nodeOfHolePlayed.Frames.GetFrameCount();
		
		GD.Print("annimation looped");
		GD.Print(nodeOfHolePlayed.Name);
		nodeOfHolePlayed.Stop();
		//nodeOfHolePlayed.Frame = nombreFrames - 1;
	}*/
	private void _on_animated_sprite_2d_frame_changed()
	{
		
		//GD.Print(nodeOfHolePlayed.Name);
		//GD.Print(frame+", "+nbFrame);
		if (frame == nbFrame){
			//GD.Print("egale");
			nodeOfHolePlayed.Pause();
			//nodeOfHolePlayed.Frame = nbFrame;
			
		}
		frame +=1;
	}
}
