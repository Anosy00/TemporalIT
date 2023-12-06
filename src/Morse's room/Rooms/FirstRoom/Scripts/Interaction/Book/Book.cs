using Godot;
using System;
using TemporalIT.Scripts.EButton;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.Book
{
	public partial class Book : Node
	{
		// Called when the node enters the scene tree for the first time.
		private EButton _keyboardInteration;
		
		private const String _NEXT_SCENE_PATH = "res://Morse's room/Rooms/FirstRoom/InTheBook.tscn";
		private const String _E_BUTTON = "button_e";

		public override void _Ready()
		{
			_keyboardInteration = new EButton(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			_keyboardInteration.makeInteraction(_E_BUTTON,_NEXT_SCENE_PATH);
		}

		public void _on_body_entered(CharacterBody2D body)
		{
			_keyboardInteration.available("default");
		}

		public void _on_body_exited(CharacterBody2D body)
		{
			_keyboardInteration.disable();
		}
	}
}