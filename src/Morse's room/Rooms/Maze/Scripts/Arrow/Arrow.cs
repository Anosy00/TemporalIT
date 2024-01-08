using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class Arrow : CanvasGroup
{
	//Elements
	private AnimatedSprite2D arrowUp;
	private AnimatedSprite2D arrowDown;
	private AnimatedSprite2D arrowLeft;
	private AnimatedSprite2D arrowRight;
	private List<AnimatedSprite2D> listArrow;
	
	//Const
	private const String _ARROW_UP = "ArrowUp";
	private const String _ARROW_DOWN = "ArrowDown";
	private const String _ARROW_RIGHT = "ArrowRight";
	private const String _ARROW_LEFT = "ArrowLeft";
	private const String _NAME_OF_THE_ANIMATION = "default";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		arrowUp = GetNode<AnimatedSprite2D>(_ARROW_UP);
		arrowDown = GetNode<AnimatedSprite2D>(_ARROW_DOWN);
		arrowLeft = GetNode<AnimatedSprite2D>(_ARROW_LEFT);
		arrowRight = GetNode<AnimatedSprite2D>(_ARROW_RIGHT);
		
		arrowUp.Play(_NAME_OF_THE_ANIMATION);
		arrowDown.Play(_NAME_OF_THE_ANIMATION);
		arrowLeft.Play(_NAME_OF_THE_ANIMATION);
		arrowRight.Play(_NAME_OF_THE_ANIMATION);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
