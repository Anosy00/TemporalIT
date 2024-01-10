using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv;


namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.Arrow
{
	public partial class Arrow : CanvasGroup
	{
		//Elements
		private TextureButton _arrowUpButton;
		private TextureButton _arrowDownButton;
		private TextureButton _arrowLeftButton;
		private TextureButton _arrowRightButton;

		private AnimatedSprite2D _arrowRightImage;
		private AnimatedSprite2D _arrowLeftImage;
		private AnimatedSprite2D _arrowUpImage;
		private AnimatedSprite2D _arrowDownImage;

		private Timer _timer;

		private MazeResolv.MazeResolv _mazeResolv;
		
		//Const
		private const String _PATH_UP_BUTTON = "ArrowUpButton";
		private const String _PATH_DOWN_BUTTON = "ArrowDownButton";
		private const String _PATH_RIGHT_BUTTON = "ArrowRightButton";
		private const String _PATH_LEFT_BUTTON = "ArrowLeftButton";
		
		private const String _PATH_UP_ANIMATION = "AnimatedSpriteArrowUp";
		private const String _PATH_DOWN_ANIMATION = "AnimatedSpriteArrowDown";
		private const String _PATH_RIGHT_ANIMATION = "AnimatedSpriteArrowRight";
		private const String _PATH_LEFT_ANIMATION = "AnimatedSpriteArrowLeft";

		private const String _PATH_BACK_SCENE = "res://Morse's room/Rooms/FirstRoom/FirstRoom.tscn";
		
		private const String _PATH_TIMER = "Timer";
		

		public override void _Ready()
		{
			_arrowDownButton = GetNode<TextureButton>(_PATH_DOWN_BUTTON);
			_arrowUpButton = GetNode<TextureButton>(_PATH_UP_BUTTON);
			_arrowLeftButton = GetNode<TextureButton>(_PATH_LEFT_BUTTON);
			_arrowRightButton = GetNode<TextureButton>(_PATH_RIGHT_BUTTON);

			_arrowDownImage = GetNode<AnimatedSprite2D>(_PATH_DOWN_ANIMATION);
			_arrowLeftImage = GetNode<AnimatedSprite2D>(_PATH_LEFT_ANIMATION);
			_arrowRightImage = GetNode<AnimatedSprite2D>(_PATH_RIGHT_ANIMATION);
			_arrowUpImage = GetNode<AnimatedSprite2D>(_PATH_UP_ANIMATION);

			_timer = GetNode<Timer>(_PATH_TIMER);

			_mazeResolv = new MazeResolv.MazeResolv();
		}

		public override void _Process(double delta)
		{
			if (!_mazeResolv.verficationCase())
			{
				GetTree().ChangeSceneToFile(_PATH_BACK_SCENE);
			}
		}

		public void disableAllArrows(bool boolean)
		{
			_arrowDownButton.Disabled = boolean;
			_arrowDownImage.Visible = !boolean;

			_arrowLeftButton.Disabled = boolean;
			_arrowLeftImage.Visible = !boolean;

			_arrowRightButton.Disabled = boolean;
			_arrowRightImage.Visible = !boolean;

			_arrowUpButton.Disabled = boolean;
			_arrowUpImage.Visible = !boolean;
		}

		public void _on_arrow_left_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveLeft();
			Player.Player.moveLeftAnimation();
			_timer.Start();
		}
		public void _on_arrow_right_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveRight();
			Player.Player.moveRightAnimation();
			_timer.Start();
		}
		public void _on_arrow_up_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveUp();
			Player.Player.moveUpAnimation();
			_timer.Start();
		}
		public void _on_arrow_down_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveDown();
			Player.Player.moveDownAnimation();
			_timer.Start();
		}

		public void _on_timer_timeout()
		{
			disableAllArrows(false);
		}
	}
}
