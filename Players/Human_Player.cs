using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public class Human_Player: Player
    {
        private Human_Form _my_form;


        public Human_Player(int id, string name): base(id, name)
        {
            _my_form = new Human_Form(name);
        }

        public override void Play_Card()
        {
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
