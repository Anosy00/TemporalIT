using System;
using Godot;
namespace TemporalIT.Scripts.CreditsScene;

public partial class Player : CharacterBody2D
{
    private const float Speed = 6f;
    private Vector2I _screenSize;
    private AnimatedSprite2D _animateSprite;
    private RichTextLabel _label;
    private TextureRect _textureRect;
    private int _index = 0;
    private AnimationPlayer _animationPlayer;
    private readonly string[][] _text = 
    {
        new[]
        {
            "[font_size=70][center]Programming Team\n",
            "[font_size=40]Alexandre Billonnet\n",
            "Lucas Theodore\n",
            "Matias Deveze\n",
            "William Lefebvre\n",
            "Rémi Lhuissier"
        },
        new[]
        {
            "[center][font_size=70]Voice Actors\n",
            "[font_size=40]Logan Ferreira\n",
            "Sofia Aylal\n",
            "Matys Deschamps"
        },
        new []
        {
            "[center][font_size=70]TemporalIT\n",
            "[font_size=40]Thanks for playing!"
        }
    };
    
    public override void _Ready()
    {
        base._Ready();
        _screenSize = DisplayServer.WindowGetSize();
        _animateSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _label = GetParent().GetNode<RichTextLabel>("RichTextLabel");
        _textureRect = GetParent().GetNode<TextureRect>("TextureRect");
        _animationPlayer = _label.GetNode<AnimationPlayer>("AnimationPlayer");
        reset_position();
    }

    public override void _PhysicsProcess(double d)
    {
        var velocity = new Vector2
        {
            X = 1 * Speed
        };
        _animateSprite.Play("moveRight");
        MoveAndCollide(velocity);
        if (Position.X > _screenSize.X * 0.8)
        {
            GD.Print(Position.X);
            reset_position();
        }
    }

    private void reset_position()
    {
        reload_label(_index);
        _index += 1;
        Position = new Vector2((float)Math.Round(_screenSize.X * -0.3), (int)Math.Round(_screenSize.Y * 0.7));
    }
    
    private void reload_label(int index)
    {
        GD.Print(index);
        _label.Clear();
        foreach (var j in _text[index])
        {
            _label.AppendText(j);
            if (index is not 0 and not 1)
            {
                _textureRect.Show();
            }
        }
        _animationPlayer.Play("reset");
    }
}