using Godot;
namespace TemporalIT.Scripts.OptionMenu;

public partial class ReturnButton : Button
{
    private void _on_pressed()
    {
        if (GetTree().ChangeSceneToFile("res://TitleScreen/TitleScreen.tscn") != Error.Ok)
            GD.PrintErr("Failed to change scene to TitleScreen.tscn");
        else
        {
            GetTree().ChangeSceneToFile("res://TitleScreen/TitleScreen.tscn");
        }
    }
}
