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

        public Random_Player(int id, string name) : base(id, name)
        {
            _random = Game.Randomizer;
        }

        public override void Play_Card()
        {
            Play_Card(_cards[_random.Next(0, _cards.Length)]);
        }
    }
}
