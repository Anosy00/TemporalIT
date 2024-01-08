using Godot;
using System;
using TemporalIT.Scripts.KeyboardInteraction;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.Radio
{
	public partial class Radio : Area2D
	{
		private KeyboardInteraction _keyboardInteration;
		private const String _NEXT_SCENE_PATH = "res://Morse's room/Rooms/FirstRoom/RadioMorse.tscn";
		private const String _E_BUTTON = "button_e";
		private const String _NAME_OF_THE_ANIMATION = "default";

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_keyboardInteration = new KeyboardInteraction(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
			_keyboardInteration.disable();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			_keyboardInteration.makeInteraction(GetTree(),_E_BUTTON, _NEXT_SCENE_PATH);
		}
		
		public void _on_body_entered(CharacterBody2D body)
		{
			_keyboardInteration.available(_NAME_OF_THE_ANIMATION);
		}

		public void _on_body_exited(CharacterBody2D body)
		{
			_keyboardInteration.disable();
		}
	}
}