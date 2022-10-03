using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public partial class Human_Form : Form
    {
        public int Result { get => _result; }
        private int _result;
        private Button[] _buttons;
        public Human_Form(string player_name)
        {
            InitializeComponent();
            Text = $"Игрок {player_name}";
            _buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
        }

        public DialogResult Play_Card(int[] cards)
        {
            for (int i = 1; i <= 10; i++)
            {
                _buttons[i-1].Enabled = cards.Contains(i) ? true : false;
            }
                
            return ShowDialog();
        }

        private void Card_Selected(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                _result = int.Parse(b.Tag.ToString());
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public void Set_History(RoundData[] history)
        {
            History_RTB.Text = "";
            for (int i = 0; i < history.Length; i++)
            {
                History_RTB.Text += $"Round {i + 1}:\n Playerd:\t";
                foreach (var card in history[i].Players_Cards)
                    History_RTB.Text += $"{card, 2} ";
                
                History_RTB.Text += "\n Result:\t";
                foreach (var card in history[i].Result_Cards)
                    History_RTB.Text += $"{card, 2} ";

                History_RTB.Text += "\n Winers: ";
                foreach (var id in history[i].Winers_ID)
                    History_RTB.Text += $"{id+1} ";

                History_RTB.Text += "\n\n";
            }
        }
    }
}
