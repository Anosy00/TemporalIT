using Godot;

namespace TemporalIT;

public static class GlobalMuseum
{
	public static int nbOfInteractionWithNarrator = 0;
	
	public static void displayDialogBox(string name, string text, DialogBox dialogBox, Timer timer)
	{
		dialogBox.setTextOfLabel(name, text);
		dialogBox.available("display_text");
	}
}
