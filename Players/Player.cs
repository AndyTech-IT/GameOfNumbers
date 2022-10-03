using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public abstract class Player
    {
        protected int[] _cards;

        private int _id;
        private string _name;
        private int _score;

        public int ID => _id;
        public string Name => _name;
        public int[] Cards => _cards;
        public int Score => _score;
        

        public void Add_Score(int value)
        {
            _score += value;
        }

        public Action<int, int> Card_Played;

        public Player(string name)
        {
            _name = name;
        }

        public void Init(int id, int blocked_card)
        {
            _id = id;
            _cards = Game.CARDS_SET.Where(c => c != blocked_card).ToArray();
            _score = 0;
        }

        public abstract void Play_Card(RoundData[] history);
        public abstract void LastRound_Result(RoundData result, int round);
        public abstract void Game_Result(int[] winers);

        protected void Play_Card(int card)
        {
            if (Validate_Card(card) == false)
                throw new Exception("You have no this card!");

            _cards = _cards.Where(c => c != card).ToArray();
            Card_Played?.Invoke(_id, card);
        }

        protected bool Validate_Card(int card)
        {
            return _cards.Contains(card);
        }
    }
}
