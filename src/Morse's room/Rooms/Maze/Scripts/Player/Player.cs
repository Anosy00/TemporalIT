using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv;

namespace TemporalIT.Morse_s_room.Rooms.Maze.Scripts.Player
{
	public partial class Player : CharacterBody2D
	{
		private static AnimationPlayer _animationPlayer;
		private static AudioStreamPlayer _playerScream;

		private const String _PATH_ANIMATION_PLAYER = "AnimatedSprite2D/AnimationPlayer";
		private const String _PATH_PLAYER_SCREAM = "PlayerScream";

		public override void _Ready()
		{
			_animationPlayer = GetNode<AnimationPlayer>(_PATH_ANIMATION_PLAYER);
			_playerScream = GetNode<AudioStreamPlayer>(_PATH_PLAYER_SCREAM);
		}

		public static void moveRightAnimation()
		{
			_animationPlayer.Play("moveRight");
		}
		public static void moveLeftAnimation()
		{
			_animationPlayer.Play("moveLeft");
		}
		public static void moveUpAnimation()
		{
			_animationPlayer.Play("moveUp");
		}
		public static void moveDownAnimation()
		{
			_animationPlayer.Play("moveDown");
		}
		
		public static void scaredAnimation()
		{
			_animationPlayer.Play("scared");
			_playerScream.Play();
		}
		
	}
}