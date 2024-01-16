namespace TemporalITTest;
using TemporalIT.Morse_s_room.Rooms.Maze.Scripts.MazeResolv;

public class Tests
{
    private MazeResolv _mazeResolv;

    [SetUp]
    public void SetUp()
    {
        _mazeResolv = new MazeResolv();
    }

    [Test]
    public void MoveUpOneTime()
    {
        _mazeResolv.setStrategy(new MazeMovementUp());
        _mazeResolv.move();

        int indexX = _mazeResolv.getIndexPlayerX();
        int indexY = _mazeResolv.getIndexPlayerY();

        Assert.AreEqual(2, indexX);
        Assert.AreEqual(1, indexY);
    }
    [Test]
    public void MoveDownOneTime()
    {
        _mazeResolv.setStrategy(new MazeMovementDown());
        _mazeResolv.move();

        int indexX = _mazeResolv.getIndexPlayerX();
        int indexY = _mazeResolv.getIndexPlayerY();

        Assert.AreEqual(0, indexX);
        Assert.AreEqual(1, indexY);
    }
    [Test]
    public void MoveRightOneTime()
    {
        _mazeResolv.setStrategy(new MazeMovementRight());
        _mazeResolv.move();

        int indexX = _mazeResolv.getIndexPlayerX();
        int indexY = _mazeResolv.getIndexPlayerY();

        Assert.AreEqual(1, indexX);
        Assert.AreEqual(2, indexY);
    }
    [Test]
    public void MoveLeftOneTime()
    {
        _mazeResolv.setStrategy(new MazeMovementLeft());
        _mazeResolv.move();

        int indexX = _mazeResolv.getIndexPlayerX();
        int indexY = _mazeResolv.getIndexPlayerY();
        
        Assert.AreEqual(1, indexX);
        Assert.AreEqual(0, indexY);
    }
    
    [Test]
    public void MoveInLeftAndTheConditionSaysIsNotAFreeCase()
    {
        _mazeResolv.setStrategy(new MazeMovementLeft());
        _mazeResolv.move();

        bool freeCase = _mazeResolv.verficationCase(MazeConstants.MONSTER_CASE);

        Assert.AreEqual(freeCase, false);
    }
    [Test]
    public void MoveInRightAndTheConditionSaysIsAFreeCase()
    {
        _mazeResolv.setStrategy(new MazeMovementRight());
        _mazeResolv.move();

        bool freeCase = _mazeResolv.verficationCase(MazeConstants.MONSTER_CASE);
        
        Assert.AreEqual(freeCase, true);
    }
}