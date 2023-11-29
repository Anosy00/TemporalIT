using Godot;
using System;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.Book
{
	public partial class Book : Node
	{
		// Called when the node enters the scene tree for the first time.
		public AnimatedSprite2D _keyboardInteration;

		public override void _Ready()
		{
			_keyboardInteration = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (Input.IsActionPressed("button_e") && _keyboardInteration.IsVisibleInTree())
			{
				GetTree().ChangeSceneToFile("res://Morse's room/Rooms/FirstRoom/InTheBook.tscn");
			}
		}

		public void _on_body_entered(CharacterBody2D body)
		{
			// Replace with function body.
			_keyboardInteration.Visible = true;
			_keyboardInteration.Play("default");
		}

		public void _on_body_exited(CharacterBody2D body)
		{
			// Replace with function body.
			_keyboardInteration.Visible = false;
			_keyboardInteration.Stop();
		}
	}
}