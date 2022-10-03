using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    public class Random_Player: Player
    {
        private Random _random;

        public Random_Player(string name) : base(name)
        {
            _random = Game.Randomizer;
        }

        public override void Game_Result(int[] winers)
        {   }

        public override void LastRound_Result(RoundData result, int _)
        {   }

        public override void Play_Card(RoundData[] history)
        {
            Play_Card(_cards[_random.Next(0, _cards.Length)]);
        }
    }
}
