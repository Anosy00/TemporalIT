namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest
{
    public class CodeVerification
    {
        private readonly int _correctAnswer;
        private bool _isOpened = false;
        
        public CodeVerification(int correctAnswer)
        {
            _correctAnswer = correctAnswer;
        }

        public bool Verification(int playerAnswer)
        {
            _isOpened = (_correctAnswer == playerAnswer);
            return _isOpened;
        }

        public bool ChestIsOpened()
        {
            return _isOpened;
        }
        
    }
};

