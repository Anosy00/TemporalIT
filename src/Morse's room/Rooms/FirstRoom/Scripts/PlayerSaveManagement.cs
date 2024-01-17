namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts;

public class PlayerSaveManager
{
    private float _positionX;
    private float _positionY;
    private const string NameFile = "firstRoomSavePostionPlayer.txt";
    
    public void Save(float valueX, float valueY)
    {
        var valueToInsert = new string[] {Convert.ToString(valueX),Convert.ToString(valueY),};
        File.WriteAllLines(NameFile,valueToInsert);
    }

    public void Load()
    {
        string[] lines = File.ReadAllLines(NameFile);

        _positionX = Convert.ToSingle(lines[0]);
        _positionY = Convert.ToSingle(lines[1]);
    }

    public float GetX()
    {
        return _positionX;
    }

    public float GetY()
    {
        return _positionY;
    }
    
    public void Reset()
    {
        File.Delete(NameFile);
    }
}