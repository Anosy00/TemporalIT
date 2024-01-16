using Godot;
using System;

using TemporalIT.Scripts.KeyboardInteraction;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest
{
    public partial class CodeChestJMJ : Node
    {
        private KeyboardInteraction _keyboardInteration;
		
        private Control _INTERFACE_TO_SHOW;
        private const String _E_BUTTON = "button_e";
        private const String _NAME_OF_THE_ANIMATION = "default";
        
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _keyboardInteration = new KeyboardInteraction(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
            _keyboardInteration.disable();
            _INTERFACE_TO_SHOW = GetNode<Control>("../../CodeChest");
            _INTERFACE_TO_SHOW.Visible = false;
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            _keyboardInteration.onButtonPress(_INTERFACE_TO_SHOW);
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