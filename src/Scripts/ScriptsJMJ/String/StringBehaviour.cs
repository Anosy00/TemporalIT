using System;
using Godot;

public partial class StringBehaviour : CharacterBody2D
{
    private float _draggingDistance;
    private Vector2 _dir;
    private bool _dragging;
    private Vector2 _newPosition;
    private bool _mouseIn = false;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            if (@event.IsPressed() && _mouseIn)
            {
                _draggingDistance = Position.DistanceTo(GetViewport().GetMousePosition());
                _dir = (GetViewport().GetMousePosition() - Position).Normalized();
                _dragging = true;
                _newPosition = GetViewport().GetMousePosition() - _draggingDistance * _dir;
            }
            else
            {
                _dragging = false;
            }
        }
        else if (@event is InputEventMouseMotion)
        {
            if (_dragging)
            {
                _newPosition = GetViewport().GetMousePosition() - _draggingDistance * _dir;
            }
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_dragging)
        {
            Velocity = (_newPosition - Position) * new Vector2(30, 30);
            MoveAndSlide();
    
        }
    }

    public void _on_mouse_entered() 
    {
        _mouseIn = true;
        GD.Print("ff");
    }

    public void _on_mouse_exited()
    {
        _mouseIn = false;
    }
}
