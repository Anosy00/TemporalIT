using Godot;
using System;
using NUnit.Framework.Constraints;
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

		private Sprite2D _computerMouse;

		private int direction;

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

		private const String _PATH_COMPUTER_MOUSE = "../ComputerMouse";
		
		private const String _PATH_TIMER = "TimerDeplacement";
		
		private const int _DIRECTION_UP = 1;
		private const int _DIRECTION_DOWN = 2;
		private const int _DIRECTION_LEFT = 3;
		private const int _DIRECTION_RIGHT = 4;

		private const String _PATH_LAST_SCENE = "res://Morse's room/Rooms/LastScene/LastScene.tscn";

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
			
			_computerMouse = GetNode<Sprite2D>(_PATH_COMPUTER_MOUSE);

			_timer = GetNode<Timer>(_PATH_TIMER);

			_mazeResolv = new MazeResolv.MazeResolv();
		}

		public void disableAllArrows(bool boolean)
		{
			_computerMouse.Visible = !boolean;
			
			_arrowDownButton.Disabled = boolean;
			_arrowDownImage.Visible = !boolean;

			_arrowLeftButton.Disabled = boolean;
			_arrowLeftImage.Visible = !boolean;

			_arrowRightButton.Disabled = boolean;
			_arrowRightImage.Visible = !boolean;

			_arrowUpButton.Disabled = boolean;
			_arrowUpImage.Visible = !boolean;
		}

		private void _setDirection(int value)
		{
			direction = value;
		}
		
		private int _getDirection()
		{
			return direction;
		}

		public void _on_arrow_left_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveLeft();
			Player.Player.moveLeftAnimation();
			_setDirection(_DIRECTION_LEFT);
			_timer.Start();
		}
		public void _on_arrow_right_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveRight();
			Player.Player.moveRightAnimation();
			_setDirection(_DIRECTION_RIGHT);
			_timer.Start();
		}
		public void _on_arrow_up_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveUp();
			Player.Player.moveUpAnimation();
			_setDirection(_DIRECTION_UP);
			_timer.Start();
		}
		public void _on_arrow_down_button_pressed()
		{
			disableAllArrows(true);
			_mazeResolv.moveDown();
			Player.Player.moveDownAnimation();
			_setDirection(_DIRECTION_DOWN);
			_timer.Start();
		}

		public void _on_timer_deplacement_timeout()
		{
			if (!_mazeResolv.verficationCase(MazeConstants.MONSTER_CASE))
			{
				switch (_getDirection())
				{
					case _DIRECTION_UP:
						Monster.Monster.activeMonsterUpAnimation();
						break;
					case _DIRECTION_DOWN:
						Monster.Monster.activeMonsterDownAnimation();
						break;
					case _DIRECTION_LEFT:
						Monster.Monster.activeMonsterLeftAnimation();
						break;
					case _DIRECTION_RIGHT:
						Monster.Monster.activeMonsterRightAnimation();
						break;
					default:
						GD.Print("Error");
						break;
				}
			}
			else if (!_mazeResolv.verficationCase(MazeConstants.EXIT_CASE))
			{
				GetTree().ChangeSceneToFile(_PATH_LAST_SCENE);
			}
			else
			{
				disableAllArrows(false);
			}
		}
	}
}
