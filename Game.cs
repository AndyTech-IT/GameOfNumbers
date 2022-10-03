using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    class Game
    {
        public const int PLAYERS_COUNT = 4;
        public const int ROUNDS_COUNT = 8;
        public static readonly int[] CARDS_SET = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static Random Randomizer
        {
            get
            {
                lock (_random_locker)
                {
                    if (++_random_geted > 1000)
                    {
                        _randomizer = new Random();
                        _random_geted = 0;
                    }
                    return _randomizer;
                }
            }
        }
        private static object _random_locker = new object();
        private static int _random_geted = 0;
        private static Random _randomizer = new Random();

        public Player[] Players => _players;
        public int Round => _round;
        public bool Is_Redy => _redy_for_new_game;

        public Action Game_Started;
        public Action<int[]> Game_Finished;
        public Action<int[]> Game_Aborted;
        public Action<int[]> Players_Played;
        public Action<int[]> Round_Played;
        public Action Round_Started;
        public Action<int[]> Winer_Founded;

        public Action<RoundData, int> Give_Round_Results;

        private bool _redy_for_new_game;

        private RoundData[] _history;
        private int _round;
        private Player[] _players;

        private int[] _players_cards;
        private bool[] _players_played;

        private int _sleep;
        private object _locker;
        private bool _abort;

        private Player[] _winers
        {
            get
            {
                int max = 0;
                foreach (Player p in _players)
                    if (p.Score > max)
                        max = p.Score;
                return _players.Where(p => p.Score == max).ToArray();
            }
        }

        public Game(int sleep_delay)
        {
            _locker = new object();
            _sleep = sleep_delay;
            _history = new RoundData[0];
            Round_Started += On_Round_Started;
            Winer_Founded += Add_Score;
            Game_Finished += ClearSubscribers;
            Game_Aborted += ClearSubscribers;
            _redy_for_new_game = true;
            _abort = false;
        }

        public void StartGame(Player[] players)
        {
            if (_redy_for_new_game == false)
                return;
            if (players.Length != PLAYERS_COUNT)
                throw new Exception($"Players count mast be {PLAYERS_COUNT}!");

            _players_cards = new int[PLAYERS_COUNT];
            _players_played = new bool[PLAYERS_COUNT];
            _players = players;

            BeginGame();
        }

        public void AbortGame()
        {
            if (_redy_for_new_game == false)
                _abort = true;
        }

        private void ClearSubscribers(int[] _)
        {
            foreach (Player p in _players)
            {
                p.Card_Played -= On_Player_Played;
                Give_Round_Results -= p.LastRound_Result;
                Game_Finished -= p.Game_Result;
            }

            _redy_for_new_game = true;
            _abort = false;
        }

        public void RestartGame()
        {
            if (_players != null && _redy_for_new_game)
            {
                BeginGame();
            }
        }

        private void Add_Score(int[] winres)
        {
            foreach (int id in winres)
                _players[id].Add_Score(_round < ROUNDS_COUNT - 1 ? 1 : 2);
        }

        private void BeginGame()
        {
            _history = new RoundData[0];
            _redy_for_new_game = false;
            _round = 0;

            for (int i = 0; i < PLAYERS_COUNT; i++)
            {
                Player player = _players[i];
                player.Card_Played += On_Player_Played;
                Give_Round_Results += player.LastRound_Result;
                Game_Finished += player.Game_Result;
                player.Init(i, CARDS_SET[Randomizer.Next(CARDS_SET.Length)]);
            }

            // Game was start
            Game_Started?.Invoke();

            // Invoke first round
            Round_Started?.Invoke();
        }

        private void Clear()
        {
            for (int i = 0; i < PLAYERS_COUNT; i++)
            {
                _players_played[i] = false;
            }
        }

        private void On_Round_Started()
        {
            // Whait some time
            Thread.Sleep(_sleep);

            Clear();
            foreach (var player in _players)
            {
                new Task(delegate() { player.Play_Card(_history); }).Start();
            }
        }
        private void On_Player_Played(int id, int card)
        {
            lock (_locker)
            {
                // Write play data
                _players_cards[id] = card;
                _players_played[id] = true;

                // All is played
                if (_players_played.All(p => p == true))
                {
                    if (_abort)
                    {
                        Game_Aborted?.Invoke(null);
                        return;
                    }

                    RoundData data = new RoundData();

                    // Whait some time
                    Thread.Sleep(_sleep);

                    // Show what players are played
                    Players_Played?.Invoke(_players_cards);
                    data.Players_Cards = _players_cards.ToArray();

                    // Whait some time
                    Thread.Sleep(_sleep);

                    // Show what hepend
                    Use_GameRules();
                    data.Result_Cards = _players_cards.ToArray();

                    // Whait some time
                    Thread.Sleep(_sleep);

                    // Who is win?
                    int[] winers = Find_Round_Winer();

                    Winer_Founded?.Invoke(winers);
                    data.Winers_ID = winers;

                    _history = _history.Append(data).ToArray();
                    _round++;

                    Give_Round_Results?.Invoke(data, _round);

                    // If not final invoke next one
                    if (_round < ROUNDS_COUNT)
                        Round_Started?.Invoke();
                    else
                        Game_Finished?.Invoke(_winers.Select(w => w.ID).ToArray());
                }
            }
        }

        private int[] Find_Round_Winer()
        {
            int max = 0;
            foreach (int card in _players_cards)
                if (card > max)
                    max = card;

            int[] result = new int[0];
            if (max == 0)
            {
                return result;
            }

            for (int i = 0; i < PLAYERS_COUNT; i++)
            {
                if (_players_cards[i] == max)
                    result = result.Append(i).ToArray();
            }
            return result;
        }

        private void Use_GameRules()
        {
            if (_players_cards.Contains(10) && _players_cards.Contains(1))
            {
                // All 10 to 0 and all 1 to 10
                _players_cards = _players_cards.Select(c => c == 10 ? 0 : c == 1 ? 10 : c).ToArray();
            }

            // All copys to 0 except 2
            _players_cards = _players_cards.Select(card => card == 2 ? 2 : _players_cards.Where(c => c == card).Count() != 1 ? 0 : card).ToArray();

            Round_Played?.Invoke(_players_cards);
        }
    }
}
