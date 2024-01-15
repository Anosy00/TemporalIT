using Godot;
namespace TemporalIT.Scripts.TitleScreen;

public partial class ExitButton : Button
{
    public void _on_exit_button_pressed()
    {
        GetTree().Quit();
    }
}