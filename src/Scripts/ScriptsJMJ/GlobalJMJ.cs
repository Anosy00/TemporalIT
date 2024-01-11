using Godot;

namespace TemporalIT;

public static class GlobalJMJ
{
    public static int nbOfInteractionWithJMJ = 0;
    public static bool hadInteractedWithNewsPaper = false;
    
    public static void displayDialogBox(string name, string text, DialogBox dialogBox, Timer timer)
    {
        dialogBox.setTextOfLabel(name, text);
        dialogBox.available("displayText");
    }
}