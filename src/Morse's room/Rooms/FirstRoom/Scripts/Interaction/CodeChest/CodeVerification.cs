

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest
{
    public class CodeVerification
    {
        private int _correcAnswer;
        private bool _isOpened = false;
        
        public CodeVerification(int correctAnswer)
        {
            this._correcAnswer = correctAnswer;
        }

        public bool verfication(int playerAnswer)
        {
            _isOpened = (_correcAnswer == playerAnswer);
            return _isOpened;
        }

        public bool chestIsOpened()
        {
            return _isOpened;
        }
        
    }
};

