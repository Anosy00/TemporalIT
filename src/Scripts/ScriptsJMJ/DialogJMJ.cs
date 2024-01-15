using System.Collections.Generic;

namespace TemporalIT;

public static class DialogJMJ
{
    public static List<Sentence> _dialog1 = new List<Sentence>
    {
        new Sentence(Global.playerName, "Je m'appelle " + Global.playerName + " il me semble que j'ai voyagé dans le temps !"),
        new Sentence("???", "Le voyage dans le temps ?! C'est impossible, mais bon passons j'ai un problème plus important... "),
        new Sentence("Jacquard", "Je m'appelle Jean Marie Jacquard et j'ai un problème dans la construction de ma machine, aide moi à la construire !..."),
        new Sentence("Jacquard", "Récupère moi les deux planches qui traînent dans mon atelier s'il te plaït"),
        new Sentence("Jacquard", "Il me manque encore des planches.."),
        new Sentence("Jacquard", "Merci, il nous manque uniquement du fil, tu peux en trouver dans mon coffre en haut..."),
    };
}