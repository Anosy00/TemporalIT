using Godot;
using System;

using TemporalIT.Scripts.EButton;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest
{
    public partial class Book : Node
    {
        private EButton _keyboardInteration;
		
        private const String _NEXT_SCENE_PATH = "res://Morse's room/Rooms/FirstRoom/CodeChest.tscn";
        private const String _E_BUTTON = "button_e";
        private const String _NAME_OF_THE_ANIMATION = "default";
        
        // Called when the node enters the scene tree for the first time.

        public override void _Ready()
        {
            _keyboardInteration = new EButton(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            if (Input.IsActionPressed(_E_BUTTON) && _keyboardInteration.isVisible())
            {
                GetTree().ChangeSceneToFile(_NEXT_SCENE_PATH);
            }
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