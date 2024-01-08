using System;
using Godot;

namespace TemporalIT.Scripts.TitleScreen;

public partial class ExitButton : Button
{
    public void _on_exit_button_pressed()
    {
        Console.WriteLine("Exit button pressed");
        GetTree().Quit();
    }
}