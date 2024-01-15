using Godot;
namespace TemporalIT.Scripts.OptionMenu;

public partial class WindowMenu : OptionButton
{
    private void Fullscreen()
    {
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
        OptionButtonDisabled(true);
    }
    
    private void Maximized()
    {
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Maximized);
        OptionButtonDisabled(true);
    }
    
    private void Windowed()
    {
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
        OptionButtonDisabled(false);
    }
    
    private void ConfigureFullscreenMode()
    {
        Select(0);
        OptionButtonDisabled(true);
    }

    private void ConfigureMaximizedMode()
    {
        Select(1);
        OptionButtonDisabled(true);
    }

    private void ConfigureWindowedMode()
    {
        Select(2);
        OptionButtonDisabled(false);
    }

    public override void _Ready()
    {
        DisplayServer.WindowMode currentWindowMode = DisplayServer.WindowGetMode();
        switch (currentWindowMode)
        {
            case DisplayServer.WindowMode.Fullscreen:
                ConfigureFullscreenMode();
                break;
            case DisplayServer.WindowMode.Maximized:
                ConfigureMaximizedMode();
                break;
            case DisplayServer.WindowMode.Windowed:
                ConfigureWindowedMode();
                break;
            default:
                GD.PrintErr("Invalid window mode");
                break;
        }
    }

    private void OptionButtonDisabled(bool value)
    {
        GetParent().GetNode<OptionButton>("ResolutionMenu").Disabled = value;
    }

    private void _on_item_selected(int index)
    {
        switch (index)
        {
            case 0:
                Fullscreen();
                break;
            case 1:
                Maximized();
                break;
            case 2:
                Windowed();
                break;
            default:
                GD.PrintErr("Invalid fullscreen index");
                break;
        }
    }
}
