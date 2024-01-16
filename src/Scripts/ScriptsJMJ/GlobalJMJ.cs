using Godot;

namespace TemporalIT;

public static class GlobalJMJ
{
    public static int nbOfInteractionWithJMJ = 0;
    public static bool hadInteractedWithNewsPaper = false;
    public static bool canInteractWithPlanks = false;
    public static int nbPlanks = 0;
    
    public static void displayDialogBox(string name, string text, DialogBox dialogBox, Godot.Timer timer)
    {
        dialogBox.setTextOfLabel(name, text);
        dialogBox.available("displayText");
    }
}