using Godot;
using System;

public partial class player : CharacterBody2D
{
    private const float SPEED = 1.5f;

    private AnimatedSprite2D animateSprite;
    private Sprite2D firstPlank;
    private bool canInteractWithNPC = false;
    private bool canInteractWithPlank = false;
    private bool isInPlankArea = false;

    public override void _Ready()
    {
        base._Ready();
        animateSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        firstPlank = GetNode<Sprite2D>("RigidBody2D/FirstPlank/SpriteFirstPlank");
    }

    public override void _PhysicsProcess(double d)
    {
        Vector2 velocity = new Vector2();
        float directionX = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        float directionY = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");

        if (Input.IsActionPressed("ui_down"))
        {
            velocity.Y = directionY * SPEED;
            animateSprite.Play("moveDown");
        }
        else if (Input.IsActionPressed("ui_up"))
        {
            velocity.Y -= SPEED;
            animateSprite.Play("moveUp");
        }
        else if (Input.IsActionPressed("ui_right"))
        {
            velocity.X = directionX * SPEED;
            animateSprite.Play("moveRight");
        }
        else if (Input.IsActionPressed("ui_left"))
        {
            velocity.X -= SPEED;
            animateSprite.Play("moveLeft");
        }
        else
        {
            animateSprite.Stop();
        }

        MoveAndCollide(velocity);
    }

    private void _on_area_2d_body_entered()
    {
        Console.Write("yo");
    }
}