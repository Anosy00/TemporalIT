using Godot;
using TemporalIT.Scripts.KeyboardInteraction;
namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest
{
    public partial class CodeChest : Node
    {
        private KeyboardInteraction _keyboardInteraction;
		
        private const string NextScenePath = "res://Morse's room/Rooms/FirstRoom/CodeChest.tscn";
        private const string EButton = "button_e";
        private const string NameOfTheAnimation = "default";
        
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _keyboardInteraction = new KeyboardInteraction(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
            _keyboardInteraction.disable();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            _keyboardInteraction.makeInteraction(GetTree(),EButton, NextScenePath);
        }

        private void _on_body_entered(CharacterBody2D body)
        {
            _keyboardInteraction.available(NameOfTheAnimation);
        }

        private void _on_body_exited(CharacterBody2D body)
        {
            _keyboardInteraction.disable();
        }
    }
    
    
}