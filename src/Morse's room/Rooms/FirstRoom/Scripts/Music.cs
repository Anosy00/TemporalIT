using Godot;
using System;

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts
{
	public partial class Music : Node
	{
		private static AudioStreamPlayer _music;
		private static float _seconds;

		private const String _PATH_MUSIC = "Music";

		public override void _Ready()
		{
			_music = GetNode<AudioStreamPlayer>(_PATH_MUSIC);
			_music.Autoplay = true;
		}

		public override void _Process(double delta)
		{
			_seconds = _music.GetPlaybackPosition();
		}

		public static void playMusic()
		{
			_music.Play(_seconds);
		}
		
		public static void stopMusic()
		{
			_music.Stop();
		}

		public void finished()
		{
			_music.Play();
		}
	}
}