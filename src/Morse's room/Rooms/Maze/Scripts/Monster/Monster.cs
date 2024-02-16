using Godot;
using System;

namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.Monster
{
	public partial class Monster : CanvasGroup
	{
		//Elements
		private static AnimatedSprite2D _monsterUp;
		private static AnimatedSprite2D _monsterDown;
		private static AnimatedSprite2D _monsterRight;
		private static AnimatedSprite2D _monsterLeft;
		private static Godot.Timer _timer;
		private static AudioStreamPlayer _screamMonster;
		private AnimationPlayer _transition;
		
		//Consts
		private const String _PATH_MONSTER_UP_ANIMATION = "MonsterUp";
		private const String _PATH_MONSTER_DOWN_ANIMATION = "MonsterDown";
		private const String _PATH_MONSTER_RIGHT_ANIMATION = "MonsterRight";
		private const String _PATH_MONSTER_LEFT_ANIMATION = "MonsterLeft";
		private const String _NAME_OF_THE_ANIMATION = "default";
		
		private const String _PATH_TIMER = "TimerMonster";

		private const String _PATH_SCREAM_MONSTER = "MonsterScream";
		
		private const String _PATH_BACK_SCENE = "res://Morse's room/Rooms/Maze/FirstLooseMaze.tscn";

		private const String _PATH_ANIMATION_TRANSITION = "../Transition";
		private const String _NAME_ANIMATION_TRANSITION = "transition-monster";
		
		
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_monsterUp = GetNode<AnimatedSprite2D>(_PATH_MONSTER_UP_ANIMATION);
			_monsterDown = GetNode<AnimatedSprite2D>(_PATH_MONSTER_DOWN_ANIMATION);
			_monsterRight = GetNode<AnimatedSprite2D>(_PATH_MONSTER_RIGHT_ANIMATION);
			_monsterLeft = GetNode<AnimatedSprite2D>(_PATH_MONSTER_LEFT_ANIMATION);
			_timer = GetNode<Godot.Timer>(_PATH_TIMER);
			_screamMonster = GetNode<AudioStreamPlayer>(_PATH_SCREAM_MONSTER);
			_transition = GetNode<AnimationPlayer>(_PATH_ANIMATION_TRANSITION);

			_monsterUp.Visible = false;
			_monsterDown.Visible = false;
			_monsterLeft.Visible = false;
			_monsterRight.Visible = false;
		}
		
		public static void activeMonsterUpAnimation()
		{
			_monsterUp.Visible = true;
			_screamMonster.Play();
			_monsterUp.Play(_NAME_OF_THE_ANIMATION);
			Player.Player.scaredAnimation();
			_timer.Start();
		}
		public static void activeMonsterDownAnimation()
		{
			_monsterDown.Visible = true;
			_screamMonster.Play();
			_monsterDown.Play(_NAME_OF_THE_ANIMATION);
			Player.Player.scaredAnimation();
			_timer.Start();
		}
		public static void activeMonsterRightAnimation()
		{
			_monsterRight.Visible = true;
			_screamMonster.Play();
			_monsterRight.Play(_NAME_OF_THE_ANIMATION);
			Player.Player.scaredAnimation();
			_timer.Start();
		}
		public static void activeMonsterLeftAnimation()
		{
			_monsterLeft.Visible = true;
			_screamMonster.Play();
			_monsterLeft.Play(_NAME_OF_THE_ANIMATION);
			Player.Player.scaredAnimation();
			_timer.Start();
		}

		public void _on_timer_monster_timeout()
		{
			_transition.Play(_NAME_ANIMATION_TRANSITION);
		}
	}
}