using System;
using System.IO;
using System.Numerics;
using Vector2 = Godot.Vector2;

namespace TemporalIT.JMJ_s_Room.Room.SaverManagement;

public class PlayerSaveManager
{
    private float _positionX;
    private float _positionY;
    private const string NameFile = "SaddlerSavePositionPlayer.txt";
    
    public void save(float valueX, float valueY)
    {
        var valueToInsert = new string[] {Convert.ToString(valueX),Convert.ToString(valueY),};
        File.WriteAllLines(NameFile,valueToInsert);
    }

    public Vector2 load()
    {
        string[] lines = File.ReadAllLines(NameFile);

        _positionX = Convert.ToSingle(lines[0]);
        _positionY = Convert.ToSingle(lines[1]);
        
        return new Godot.Vector2(_positionX, _positionY);
    }

    public float getX()
    {
        return _positionX;
    }

    public float getY()
    {
        return _positionY;
    }
    
    public void reset()
    {
        File.Delete(NameFile);
    }
}