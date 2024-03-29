using System.Collections.Generic;
using TemporalIT.Scripts.ScriptsMuseum;

namespace TemporalIT;

public static class DialogJMJ
{
	public static List<Sentence> _dialog1 = LanguageManager.GetSequentialSentences("JMJ's Room/Texts/DialoguesBottomRoom.json");

	/*
	public static List<Sentence> _dialog1 = new List<Sentence>
	{
		new Sentence(Global.playerName, "Je m'appelle " + Global.playerName + " il me semble que j'ai voyagé dans le temps !", 0),
		new Sentence("???", "Le voyage dans le temps ?! C'est impossible, mais bon passons j'ai un problème plus important... ", 0),
		new Sentence("Jacquard", "Je m'appelle Jean Marie Jacquard et j'ai un problème dans la construction de ma machine, aide moi à la construire !...", 0),
		new Sentence("Jacquard", "Récupère moi les deux planches qui traînent dans mon atelier s'il te plaït", 0),
		new Sentence("Jacquard", "Merci, il nous manque uniquement du fil, tu peux en trouver dans mon coffre en haut...", 0),
		new Sentence("Jacquard", "Le code du coffre se réfère à la date de décès d'un ami très cher à mes yeux...", 0),
		new Sentence("Jacquard", "La date de son décès est parue dans le journal, je l'ai rangé là haut !", 0),
		new Sentence("Jacquard", "Merci beaucoup ! Tu peux maintenant aller utiliser ma machine !", 0),
	};
	*/
}
