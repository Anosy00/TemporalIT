using Godot;

namespace TemporalIT.Scripts;

public partial class Timer : Container
{
	public static double time;

	public static void _start()
	{
		time = Time.GetTicksMsec()/1000;
	}
	public static void _stop()
	{
		time = Time.GetTicksMsec()/1000 - time;
		GD.Print("Time spent in the game: " + time);	
	}
}