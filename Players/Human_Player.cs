using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public class Human_Player : Player
    {
        private Human_Form _my_form;


        public Human_Player(string name): base(name)
        {
            _my_form = new Human_Form(name);
        }

        public override void Game_Result(int[] winers)
        {   }

        public override void LastRound_Result(RoundData result, int _)
        {   }

        public override void Play_Card(RoundData[] history)
        {
            _my_form.Set_History(history);
            while (true)
            {
                if (_my_form.Play_Card(_cards) == DialogResult.OK)
                {
                    Play_Card(_my_form.Result);
                    return;
                }
            }
        }
    }
}
