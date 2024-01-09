using Godot;
using System;


namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.Arrow
{
	public partial class Arrow : CanvasGroup
	{
		//Elements
		private AnimatedSprite2D _arrowUp;
		private AnimatedSprite2D _arrowDown;
		private AnimatedSprite2D _arrowLeft;
		private AnimatedSprite2D _arrowRight;

		//Const
		private const String _ARROW_UP = "ArrowUp";
		private const String _ARROW_DOWN = "ArrowDown";
		private const String _ARROW_RIGHT = "ArrowRight";
		private const String _ARROW_LEFT = "ArrowLeft";

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_arrowUp = GetNode<AnimatedSprite2D>(_ARROW_UP);
			_arrowDown = GetNode<AnimatedSprite2D>(_ARROW_DOWN);
			_arrowLeft = GetNode<AnimatedSprite2D>(_ARROW_LEFT);
			_arrowRight = GetNode<AnimatedSprite2D>(_ARROW_RIGHT);


		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}
