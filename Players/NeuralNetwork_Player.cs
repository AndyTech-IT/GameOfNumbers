using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    class NeuralNetwork_Player : Player
    {
        public double Fitnes => _brain.Fitnes;

        public void ClearFitness()
        {
            _brain.Chainge_Fitnes(Fitnes_Chainging.Clear);
        }

        public void ClearBrain()
        {
            _brain = new NeuralNetwork(NeuralNetwork.STRUCT);
        }

        private NeuralNetwork _brain;
        private bool _training;
        private string _save_file;

        // Init new network ready to train
        public NeuralNetwork_Player(string name) : base(name)
        {
            _training = true;
            _save_file = $"{name}.{NeuralNetwork.FILE_EXSTANTION}";
            _brain = new NeuralNetwork(NeuralNetwork.STRUCT);
        }

        // Load Net from file
        public static NeuralNetwork_Player From_File(string filename = null, bool training = false, string name = null, int index = 0)
        {
            if (filename is null)
            {
                filename = Directory.GetFiles(Training_Form.Result_Folder)[index];
            }
            if (name is null)
                name = filename.Split('.')[0];

            NeuralNetwork_Player result = new NeuralNetwork_Player(name) { _training = training };
            result._brain.Load(filename);
            return result;
        }

        public void Mutate(double chaince, double value)
        {
            _brain.Mutate(chaince, value);
        }

        public void Union(NeuralNetwork_Player other, double chaince)
        {
            _brain.Union(chaince, other._brain);
        }

        public void Save(string filename = null)
        {
            if (filename is null)
                filename = _save_file;

            _brain.Save(filename);
        }

        public override void Game_Result(int[] winers)
        {
            if (_training == false)
                return;

            if (winers.Contains(ID))
                _brain.Chainge_Fitnes(Fitnes_Chainging.Game_Win);

        }

        public override void LastRound_Result(RoundData result, int round)
        {
            if (_training == false)
                return;

            if (result.Players_Cards[ID] == 1 && result.Result_Cards[ID] == 10)
                _brain.Chainge_Fitnes(Fitnes_Chainging.One_To_Ten);

            if (result.Result_Cards[ID] == 0)
            {
                _brain.Chainge_Fitnes(Fitnes_Chainging.Repiat_To_Zero);

                if (result.Players_Cards[ID] == 10)
                    _brain.Chainge_Fitnes(Fitnes_Chainging.Ten_To_Zero);
            }

            if (result.Players_Cards[ID] == 2 && result.Players_Cards.Where(c => c == 2).Count() > 1)
                _brain.Chainge_Fitnes(Fitnes_Chainging.Two_Not_Zero);

            if (result.Winers_ID.Contains(ID))
            {
                _brain.Chainge_Fitnes(Fitnes_Chainging.Round_Win);
                if (round == Game.ROUNDS_COUNT)
                {
                    _brain.Chainge_Fitnes(Fitnes_Chainging.LastRound_Win);
                }
            }

            if (round == Game.ROUNDS_COUNT && false)
                new Task(delegate () { MessageBox.Show($"{ID} - {_brain.Fitnes}"); }).Start();
        }

        public override void Play_Card(RoundData[] history)
        {
            double[] input = new double[NeuralNetwork.STRUCT[0]];
            for (int i = 0; i < input.Length; i++)
                input[i] = 0;

            // Curent Round
            input[history.Length] = 1;
            int index = Game.ROUNDS_COUNT;

            // My Cards
            for (int i = 0; i < Game.CARDS_SET.Length; i++)
            {
                input[i+ index] = _cards.Contains(Game.CARDS_SET[i]) ? 1 : 0;
            }
            index += Game.CARDS_SET.Length;

            // Oppenent Cards
            for (int i = 0; i < history.Length; i++)
            {
                for(int j  = 0; j < history[i].Players_Cards.Length; j++)
                {
                    if (j == ID)
                        continue;
                    input[index + history[i].Players_Cards[j] - 1]++;
                }
            }
            for (int i = index; i < input.Length; i++)
                input[i] = 1 - input[i] / (Game.PLAYERS_COUNT - 1);

            double[] result = _brain.FeedForward(input);

            double min = -2;
            for (int _ = 0; _ < result.Length; _++)
            {
                double max = min;
                int max_i = 0;
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] > max)
                    {
                        max_i = i;
                        max = result[i];
                    }
                }
                int card = Game.CARDS_SET[max_i];
                if (Validate_Card(card))
                {
                    Play_Card(card);
                    return;
                }
                result[max_i] = min;

                if (_training)
                    _brain.Chainge_Fitnes(Fitnes_Chainging.Wrong_Select);
            }

            throw new Exception("Card not selected!");
        }
    }
}
