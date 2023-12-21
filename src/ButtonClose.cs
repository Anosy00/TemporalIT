using Godot;
using System;

public partial class ButtonClose : Button
{
	public void _on_pressed()
	{
		EButtonPaper.closeNewsPaper();
	}
}
