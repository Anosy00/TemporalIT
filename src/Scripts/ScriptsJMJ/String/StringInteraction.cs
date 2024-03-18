using System;using Godot;

public enum Color { blue, red, yellow, green}
;
public partial class StringInteraction : CharacterBody2D
{
    public bool movable = false;
    public bool moving = false;
    public Vector2 startPosition;
    public Color objectColor;

    public override void _Ready()
    {
        startPosition = Position;
    }
}