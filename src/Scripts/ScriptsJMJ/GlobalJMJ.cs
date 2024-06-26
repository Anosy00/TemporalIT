
namespace TemporalIT;
using TemporalIT.Scripts.DialogBox;

public static class GlobalJMJ
{
	public static int nbOfInteractionWithJMJ = 0;
	public static bool hadInteractedWithNewsPaper = false;
	public static bool canInteractWithPlanks = false;
	public static int nbPlanks = 0;
	public static bool hasString = false;
	public static bool isObjActive = false;
	public static bool firstEntryInSaddler = true;
	public static bool objectifStringActive = false;
	public static bool objectifPlankActive = false;
	public static bool canInteractWithMachine = false;
	
	public static void displayDialogBox(string name, string text, DialogBox dialogBox)
	{
		dialogBox.setTextOfLabel(name, text);
		dialogBox.available("displayText");
	}
}
