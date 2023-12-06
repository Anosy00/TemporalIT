

namespace TemporalIT.Morse_s_room.Rooms.FirstRoom.Scripts.Interaction.CodeChest
{
    public class CodeVerfication
    {
        private int _correcAnswer;
        private int _playerAnswer;
        private bool _isOpened = false;
        
        public CodeVerfication(int correctAnswer, int playerAnswer)
        {
            this._correcAnswer = correctAnswer;
            this._playerAnswer = playerAnswer;
        }

        public bool verfication()
        {
            this._isOpened = false;
            return _correcAnswer==_playerAnswer;
        }

        public bool chestIsOpened()
        {
            return _isOpened;
        }
        
    }
};

