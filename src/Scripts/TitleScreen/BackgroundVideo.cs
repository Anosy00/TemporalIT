using Godot;
namespace TemporalIT.Scripts.TitleScreen;

public partial class BackgroundVideo : VideoStreamPlayer
{
    private void _on_finished()
    {
        Play();
    }
}
