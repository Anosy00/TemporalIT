using Godot;
using System;

namespace TemporalIT.Scripts.ScriptsMuseum.Card
{
	public partial class Card : Node
	{
		// Called when the node enters the scene tree for the first time.
		public AnimatedSprite2D KeyboardInteration;
		
		

		public override void _Ready()
		{
			KeyboardInteration = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			KeyboardInteration.Visible = false;
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (Input.IsActionPressed("button_e") && KeyboardInteration.IsVisibleInTree())
			{
				Global.setRoomNumber(1);//à changer en 1
				GetTree().ChangeSceneToFile("res://Museum/PunchedCard.tscn");
				//GD.Print("La scene a été changée");
				
			}
		}

		public void _on_interactive_zone_of_the_punched_card_body_entered(CharacterBody2D body)
		{
			// Replace with function body.
			KeyboardInteration.Visible = true;
			KeyboardInteration.Play("default");
		}

		public void _on_interactive_zone_of_the_punched_card_body_exited(CharacterBody2D body)
		{
			// Replace with function body.
			KeyboardInteration.Visible = false;
			KeyboardInteration.Stop();
		}



		
	}
}


