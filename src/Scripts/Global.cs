using Godot;
using System;

public static partial class Global 
{
	public static bool canInteractWithJean = false;

	public static void changeValueOfCanInteraciWithJean()
	{
		canInteractWithJean = !canInteractWithJean;
	}
}
