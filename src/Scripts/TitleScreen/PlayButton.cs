using Godot;

namespace TemporalIT.Scripts.TitleScreen;

public partial class PlayButton : Button
{
	private void _on_start_button_pressed()
	{
		if (GetTree().ChangeSceneToFile("res://Museum/MuseumMap.tscn") != Error.Ok)
			GD.PrintErr("Failed to change scene to MuseumMap.tscn");
		else
		{
			GetTree().ChangeSceneToFile("res://Museum/MuseumMap.tscn");
		}
	}
}
