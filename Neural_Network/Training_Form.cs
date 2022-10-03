using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public partial class Training_Form : Form
    {
        public const string Networks_Folder = "Training_Networks";
        public const string Result_Folder = "Redy_Networks";
        private const int _randoms_in_game = 2;
        private const int _refresh_score = 50;
        private int _refresh_counter;

        private Random_Player[] _random_pool;
        private NeuralNetwork_Player[] _ai_pool;
        private Game[] _game_pool;

        private bool _training_in_process;

        private bool Training
        {
            get => _training_in_process;
            set
            {
                _training_in_process = value;
                Invoke((MethodInvoker) delegate() { BeginTraining_B.Enabled = !value; });
            }
        }

        private int _games_repiats;
        private object _locker;

        public Training_Form()
        {
            InitializeComponent();
            _locker = new object();
        }

        private void BeginTraining_B_Click(object sender, EventArgs e)
        {
            if (_training_in_process)
                return;

            Training = true;
            _games_repiats = (int)GameRepiats_NUD.Value;
            int count = (int)GamesCount_NUD.Value;
            int ai_count = count * (Game.PLAYERS_COUNT- _randoms_in_game);
            int repiats_count = (int)GameRepiats_NUD.Value;
            string[] ai_files;
            if (Directory.Exists(Networks_Folder))
            {
                ai_files = Directory.GetFiles(Networks_Folder).Where(
                    f => f.EndsWith("." + NeuralNetwork.FILE_EXSTANTION
                    )).ToArray();
            }
            else
            {
                ai_files = new string[0];
                Directory.CreateDirectory(Networks_Folder);
            }
            _random_pool = new Random_Player[count * _randoms_in_game];
            for (int i = 0; i < count * _randoms_in_game; i++)
            {
                _random_pool[i] = new Random_Player("Random");
            }

            _ai_pool = new NeuralNetwork_Player[ai_count];
            for (int i = 0; i < ai_count; i++)
            {
                string name = Game.Randomizer.Next(1_000_000_000).ToString();
                if (i < ai_files.Length)
                    _ai_pool[i] = NeuralNetwork_Player.From_File(ai_files[i], name: name, training: true);
                else
                {
                    _ai_pool[i] = new NeuralNetwork_Player(name);
                    _ai_pool[i].Union(_ai_pool[Game.Randomizer.Next(ai_files.Length)], .9);
                }
            }

            _game_pool = new Game[count];
            for (int i = 0; i < count; i++)
            {
                _game_pool[i] = new Game(0);
                Game game = _game_pool[i];
                game.Game_Finished += On_GameFinish;
                game.Game_Aborted += On_GameFinish;
            }

            _refresh_counter = 0;
            Start_TrainGames();
        }


        private void Start_TrainGames()
        {
            Player[][] players = Shuffle_Players();
            for (int i = 0; i < _game_pool.Length; i++)
            {
                Game game = _game_pool[i];
                game.StartGame(players[i]);
            }
        }

        private Player[][] Shuffle_Players()
        {
            Player[][] result = new Player[_game_pool.Length][];
            List<Player> temp = _ai_pool.Cast<Player>().ToList();
            int random_id = 0;

            for (int i = 0; i < _game_pool.Length; i++)
            {
                result[i] = new Player[Game.PLAYERS_COUNT];
                for (int j = 0; j < Game.PLAYERS_COUNT; j++)
                {
                    if (j < Game.PLAYERS_COUNT - _randoms_in_game)
                    {
                        int id = Game.Randomizer.Next(temp.Count);
                        result[i][j] = temp[id];
                        temp.RemoveAt(id);
                    }
                    else
                    {
                        result[i][j] = _random_pool[random_id++];
                    }
                }
            }
            return result;
        }

        private void On_GameFinish(object _)
        {
            lock(_locker)
            {
                if (_game_pool.All(g => g.Is_Redy))
                {
                    _games_repiats--;
                    Invoke((MethodInvoker) delegate() { UpcommingGames_L.Text = _games_repiats.ToString(); });
                    if (_games_repiats <= 0)
                        Finish_Training();
                    else
                    {
                        Invoke((MethodInvoker)Genetic_Selection);
                        Start_TrainGames();
                    }
                }
            }
        }

        private void Genetic_Selection()
        {
            _refresh_counter++;
            if (_refresh_counter >= _refresh_score)
            {
                _refresh_counter = 0;
                _ai_pool = _ai_pool.OrderBy(ai => -ai.Fitnes).ToArray();
                int group_size = _ai_pool.Length / 4;
                int index = group_size;

                double summ_fitness = 0;
                double max_fitness = _ai_pool[0].Fitnes;
                double min_fitness = _ai_pool.Last().Fitnes;
                for (int i = 0; i < _ai_pool.Length; i++)
                {
                    summ_fitness += _ai_pool[i].Fitnes;
                    if (_games_repiats > _refresh_score + 1)
                        _ai_pool[i].ClearFitness();
                }

                ScoreBoard_RTB.Text =
                    $"Avarage: {summ_fitness / _ai_pool.Length,2}\n" +
                    $"Max:     {max_fitness}\n" +
                    $"Min:     {min_fitness}";

                // Group 2
                for (int i = index; i < index + group_size; i++)
                {
                    _ai_pool[i].Mutate(.0001, .0001);
                }
                index += group_size;

                // Group 3
                for (int i = index; i < index + group_size; i++)
                {
                    _ai_pool[i].Union(_ai_pool[Game.Randomizer.Next(Game.PLAYERS_COUNT * 4)], .5);
                }
                index += group_size;

                // Group 4
                for (int i = index; i < _ai_pool.Length; i++)
                {
                    _ai_pool[i].Union(_ai_pool[Game.Randomizer.Next(Game.PLAYERS_COUNT * 4)], .8);
                    _ai_pool[i].Mutate(.02, .003);
                }

                // Group 1
                for (int i = 0; i < group_size; i++)
                {
                    //_ai_pool[i].Mutate(.0001, .00001);
                }
            }
        }

        private void Finish_Training()
        {
            _ai_pool = _ai_pool.OrderBy(ai => -ai.Fitnes).ToArray();

            if (Directory.Exists(Result_Folder))
                Directory.Delete(Result_Folder, true);
            Directory.CreateDirectory(Result_Folder);

            if (Directory.Exists(Networks_Folder))
                Directory.Delete(Networks_Folder, true);
            Directory.CreateDirectory(Networks_Folder);


            for (int i = 0; i < Game.PLAYERS_COUNT; i++)
                _ai_pool[i].Save($"{Result_Folder}\\Network {i}.{NeuralNetwork.FILE_EXSTANTION}");


            for (int i = 0; i < _ai_pool.Length * 0.75; i++)
            {
                _ai_pool[i].Save($"{Networks_Folder}\\{i + 1} {_ai_pool[i].Name}.{NeuralNetwork.FILE_EXSTANTION}");
            }
            Training = false;
            //MessageBox.Show("Training complited!");
        }

        private void AbortTraining_B_Click(object sender, EventArgs e)
        {
            _games_repiats = _games_repiats % _refresh_score;
            foreach (Game game in _game_pool)
            {
                game.AbortGame();
            }
        }
    }
}
