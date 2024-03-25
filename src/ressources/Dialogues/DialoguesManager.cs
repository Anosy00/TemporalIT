using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Collections.Generic;
using TemporalIT.Scripts.ScriptsMuseum;


public partial class DialoguesManager : Node
{
	private static string jsonString;
	private static Dictionary<string, LanguageDialogues> dialogues;
	public static List<Sentence> GetSequentialSentences(string jsonFilePath, string language)
	{
		jsonString = LoadJsonFromFile(jsonFilePath);
		if (jsonString != null)
		{
			dialogues = DeserializeJson(jsonString);
			if (dialogues != null && dialogues.ContainsKey(language))
			{
				List<Sentence> sequentialSentences = new List<Sentence>();
				foreach (var dialogue in dialogues[language].Dialogues)
				{
					sequentialSentences.Add(new Sentence(dialogue.Speaker, dialogue.Text, dialogue.Time));
				}
				return sequentialSentences;
			}
			else
			{
				GD.PrintErr("Dialogue non trouvé pour la langue : " + language);
			}
		}
		return null;
	}

	private static string LoadJsonFromFile(string filePath)
	{
		string jsonString = null;
		try
		{
			using (FileStream stream = new FileStream(filePath, FileMode.Open))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					jsonString = reader.ReadToEnd();
				}
			}
		}
		catch (System.Exception e)
		{
			GD.PrintErr("Erreur lors de la lecture du fichier JSON : " + e.Message);
		}
		return jsonString;
	}

	public class Dialogue
	{
		public string Speaker { get; set; }
		public string Text { get; set; }
		public float Time { get; set; }
	}

	public class LanguageDialogues
	{
		public List<Dialogue> Dialogues { get; set; }
	}

	private static Dictionary<string, LanguageDialogues> DeserializeJson(string jsonString)
	{
		try
		{
			return JsonSerializer.Deserialize<Dictionary<string, LanguageDialogues>>(jsonString);
		}
		catch (System.Exception e)
		{
			GD.PrintErr("Erreur lors de la désérialisation du JSON : " + e.Message);
			return null;
		}
	}
}
