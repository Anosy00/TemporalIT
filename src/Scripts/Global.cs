using Godot;
using System;

public static class Global
{
	private static int roomNumber=0;
	public static bool isDialogActive = false;
	public static string playerName = "[Player]";

	public static string language = "fr";

	public struct Sentence
	{
		public string _name;
		public string _text;

		public Sentence(string name, string text){
			_name = name;
			_text = text;
		}
	}
	
	public static void setRoomNumber(int number){
		roomNumber=number;
	}
	public static int getRoomNumber(){
		return roomNumber;
	}
}
