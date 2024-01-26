using Godot;
using System;

public static class Global
{
	private static int roomNumber=0;
	public static bool isDialogActive = false;
	public static string playerName = "[Player]";
	
	public static void setRoomNumber(int number){
		roomNumber=number;
	}
	public static int getRoomNumber(){
		return roomNumber;
	}
}
