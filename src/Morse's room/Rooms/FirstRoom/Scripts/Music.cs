using Godot;
using System;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts
{
	public partial class Music : Node
	{
		public static AudioStreamPlayer backgroundMusic;
		private static float _seconds;

		private const String _PATH_MUSIC = "Music";

		public override void _Ready()
		{
			backgroundMusic = GetNode<AudioStreamPlayer>(_PATH_MUSIC);
			backgroundMusic.Autoplay = true;
		}

		public override void _Process(double delta)
		{
			_seconds = backgroundMusic.GetPlaybackPosition();
		}

		public static void playMusic()
		{
			backgroundMusic.Play(_seconds);
		}
		
		public static void stopMusic()
		{
			backgroundMusic.Stop();
		}

		public void _on_music_finished()
		{
			backgroundMusic.Play();
		}
	}
}