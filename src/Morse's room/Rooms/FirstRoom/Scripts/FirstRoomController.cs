using Godot;
using System;
using TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

public partial class FirstRoomController : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Music.playMusic();
	}
}
