using Godot;
using System;
using PausedMenu;

public partial class TitleScreen : Node
{
	private PausedMenu.PausedMenu _pausedMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pausedMenu = new PausedMenu.PausedMenu();
	}
}
