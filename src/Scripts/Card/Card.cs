using Godot;
using System;

namespace TemporalIT.Scripts.Card
{
	public partial class Card : Node
	{
		// Called when the node enters the scene tree for the first time.
		public AnimatedSprite2D _keyboardInteration;
		
		

		public override void _Ready()
		{
			_keyboardInteration = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			_keyboardInteration.Visible = false;
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (Input.IsActionPressed("button_e") && _keyboardInteration.IsVisibleInTree())
			{
				GetTree().ChangeSceneToFile("res://TilesMapMusee/PunshedCard.tscn");
				
			}
		}

		public void _on_interactive_zone_of_the_punched_card_body_entered(CharacterBody2D body)
		{
			// Replace with function body.
			_keyboardInteration.Visible = true;
			_keyboardInteration.Play("default");
		}

		public void _on_interactive_zone_of_the_punched_card_body_exited(CharacterBody2D body)
		{
			// Replace with function body.
			_keyboardInteration.Visible = false;
			_keyboardInteration.Stop();
		}



		
	}
}


