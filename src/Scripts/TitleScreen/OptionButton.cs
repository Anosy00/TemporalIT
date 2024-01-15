using Godot;
namespace TemporalIT.Scripts.TitleScreen;

public partial class OptionButton : Button
{
    private void _on_options_button_pressed()
    {
        if (GetTree().ChangeSceneToFile("res://OptionMenu/OptionMenu.tscn") != Error.Ok)
            GD.PrintErr("Failed to change scene to OptionMenu.tscn");
        else
        {
            GetTree().ChangeSceneToFile("res://OptionMenu/OptionMenu.tscn");
        }
    }
}
