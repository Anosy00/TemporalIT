using Godot;
using System;
using TemporalIT;

public partial class BackButtonJMJ : Button
{
	private Control _INTERFACE_TO_CLOSE;

	public override void _Ready()
	{
		_INTERFACE_TO_CLOSE = GetNode<Control>("../../../../CodeChest");
	}

	public void _on_back_button_pressed()
	{
		_INTERFACE_TO_CLOSE.Visible = false;
	}
}
