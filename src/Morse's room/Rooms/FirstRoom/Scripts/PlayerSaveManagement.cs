using System;
using System.IO;
using Godot;


public class PlayerSaveManagerJMJ
{
    private float positionX;
    private float positionY;
    private Vector2 _START_POSITION_X = new Vector2(32, 58);
    private const String _NAME_FILE = "firstRoomSavePostionPlayer.txt";
    
    public void save(float valueX, float valueY)
    {
        string[] valueToInsert = new string[] {Convert.ToString(valueX),Convert.ToString(valueY),};
        File.WriteAllLines(_NAME_FILE,valueToInsert);
    }

    public Vector2 launchingPosition()
    {
        return _START_POSITION_X;
    }

    public void load()
    {
        string[] lignes = File.ReadAllLines(_NAME_FILE);

        positionX = Convert.ToSingle(lignes[0]);
        positionY = Convert.ToSingle(lignes[1]);
    }

    public float getX()
    {
        return positionX;
    }

    public float getY()
    {
        return positionY;
    }
    public void reset()
    {
        File.Delete(_NAME_FILE);
    }
    
}