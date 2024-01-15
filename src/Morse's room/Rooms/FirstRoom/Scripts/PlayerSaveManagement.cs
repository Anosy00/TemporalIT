using System;
using System.IO;


public class PlayerSaveManager
{
    private float postionX;
    private float positionY;
    private const String _NAME_FILE = "firstRoomSavePostionPlayer.txt";
    
    public void save(float valueX, float valueY)
    {
        string[] valueToInsert = new string[] {Convert.ToString(valueX),Convert.ToString(valueY),};
        File.WriteAllLines(_NAME_FILE,valueToInsert);
    }

    public void load()
    {
        string[] lignes = File.ReadAllLines(_NAME_FILE);

        postionX = Convert.ToSingle(lignes[0]);
        positionY = Convert.ToSingle(lignes[1]);
    }

    public float getX()
    {
        return postionX;
    }

    public float getY()
    {
        return positionY;
    }
}