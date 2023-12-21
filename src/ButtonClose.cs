using Godot;
using System;

public partial class ButtonClose : Button
{
	
	
	public override void _Ready()
	{
		DialogBox.disable();
	}
	public void _on_pressed()
	{
		NewsPaper.setInvisibleNewsPaper();
	}
}
