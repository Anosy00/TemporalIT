using Godot;
using System;

public static class Global
{
	public static bool hadInteractedWithNewsPaper = false;
	public static bool isDialogActive = false;

	public static void changeToTruehadInteractedWithNewsPaper()
	{
		hadInteractedWithNewsPaper = true;
	}

	
}
