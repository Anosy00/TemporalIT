using Godot;
using System;

public static class Global
{
	public static bool isDialogActive = false;
	public static string playerName = "[Player]";

	public struct Sentence
	{
		public string _name;
		public string _text;

		public Sentence(string name, string text){
			_name = name;
			_text = text;
		}
	}
}
