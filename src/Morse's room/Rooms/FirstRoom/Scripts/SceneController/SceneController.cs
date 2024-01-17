using Godot;
namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.SceneController;

public partial class SceneController : Node
{
	private const string NextScenePath = "res://Morse's room/Rooms/Maze/Maze.tscn";

	private void _on_body_entered(CharacterBody2D player)
	{
		GetTree().ChangeSceneToFile(NextScenePath);
	}
}