using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public partial class Game_Form : Form
    {
        private const int _game_sleep = 400;

        private Game _game;
        private NewGame_Form _new_game_dialoge;
        private Label[] _names_labels;
        private Label[] _card_labels;
        private Label[] _score_labels;


        public Game_Form()
        {
            InitializeComponent();
            _new_game_dialoge = new NewGame_Form();
            _game = new Game(_game_sleep);
            _game.Game_Started += Clear_UI;
            _game.Round_Started += FlipCards;
            _game.Players_Played += Show_Played_Cards;
            _game.Round_Played += Show_Result_Cards;
            _game.Winer_Founded += Show_Winers;
            _game.Game_Finished += Show_Results;

            _names_labels = new Label[Game.PLAYERS_COUNT] { Name_Label1, Name_Label2, Name_Label3, Name_Label4 };
            _card_labels = new Label[Game.PLAYERS_COUNT] { Card1, Card2, Card3, Card4 };
            _score_labels = new Label[Game.PLAYERS_COUNT] { Score_Label1, Score_Label2, Score_Label3, Score_Label4 };
        }

        private void Clear_UI()
        {
            Invoke((MethodInvoker)delegate () { Text = "0"; });
            for (int i = 0; i < Game.PLAYERS_COUNT; i++)
            {
                _names_labels[i].Text = _game.Players[i].Name;
                _score_labels[i].Text = "0";
                Round_Label.Text = $"1 / {Game.ROUNDS_COUNT}";
            }
        }

        private void FlipCards()
        {
            Invoke((MethodInvoker)delegate () { Text = "1"; });
            Invoke((MethodInvoker)delegate () { Round_Label.Text = $"{_game.Round + 1} / {Game.ROUNDS_COUNT}"; });
            UpdateCards(new string[] { "G\nN", "G\nN", "G\nN", "G\nN" }, Color.Gray);
        }

        private void Show_Played_Cards(int[] cards)
        {
            Invoke((MethodInvoker)delegate () { Text = "2"; });
            UpdateCards(cards.Select(c => c.ToString()).ToArray(), Color.LightGray);
        }

        private void Show_Result_Cards(int[] cards)
        {
            Invoke((MethodInvoker)delegate () { Text = "3"; });
            UpdateCards(cards.Select(c => c.ToString()).ToArray(), Color.White);

        }

        private void Show_Winers(int[] ids)
        {
            Invoke((MethodInvoker)delegate () { Text = "4"; });
            foreach (int id in ids)
                _card_labels[id].BackColor = Color.Gold;
            UpdateScore();
        }

        private void UpdateCards(string[] data, Color color)
        {
            for (int i = 0; i < Game.PLAYERS_COUNT; i++)
            {
                Label label = _card_labels[i];
                Invoke((MethodInvoker)delegate () {
                    label.Text = data[i];
                    label.BackColor = color;
                });
            }
        }

        private void UpdateScore()
        {
            for (int i = 0; i < Game.PLAYERS_COUNT; i++)
            {
                Label label = _score_labels[i];
                Invoke((MethodInvoker)delegate () { label.Text = _game.Players[i].Score.ToString(); });
            }
        }

        private void Show_Results(int[] id)
        {
            Invoke((MethodInvoker)delegate () { Text = "5"; });
            string[] names = _game.Players.Where(p => id.Contains(p.ID)).Select(p => p.Name).ToArray();
            string winers_list = "";
            foreach (string name in names)
            {
                winers_list += name + ", ";
            }
            MessageBox.Show($"Game finished, winer(-s) {winers_list.Trim(new char[] { ' ', ','})}!");
        }

        private void NewGame_TSMI_Click(object sender, EventArgs e)
        {
            if (_new_game_dialoge.ShowDialog() == DialogResult.OK)
            {
                Player[] players = _new_game_dialoge.Result;
                _new_game_dialoge.ClearResult();
                _game.StartGame(players);
            }
        }

        private void RestartGame_TSMI_Click(object sender, EventArgs e)
        {
            _game.RestartGame();
        }
    }
}
