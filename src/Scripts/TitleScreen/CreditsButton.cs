using Godot;
namespace TemporalIT.Scripts.TitleScreen;

public partial class CreditsButton : Button
{
	private void _on_pressed()
	{
		if (GetTree().ChangeSceneToFile("res://Credits/CreditsScene.tscn") != Error.Ok)
			GD.PrintErr("Failed to change scene to CreditsScene.tscn");
		else
		{
			GetTree().ChangeSceneToFile("res://Credits/CreditsScene.tscn");
		}
	}
}
