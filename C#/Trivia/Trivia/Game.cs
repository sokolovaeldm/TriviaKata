using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> _players = new();

        private readonly int[] _places = new int[6];
        private readonly int[] _purses = new int[6];

        private readonly bool[] _inPenaltyBox = new bool[6];

        private int _currentPlayer;
        private readonly Category _category;

        public Game()
        {
            _category = new Category();
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= 2);
        }

        public bool Add(string playerName)
        {
            _players.Add(new Player(playerName));
            _places[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            var playerName = _players[_currentPlayer].Name;
            Console.WriteLine(playerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_inPenaltyBox[_currentPlayer])
            {
                if (IsEven(roll))
                {
                    Console.WriteLine(playerName + " is not getting out of the penalty box");
                    _inPenaltyBox[_currentPlayer] = true;
                }
                else
                {
                    _inPenaltyBox[_currentPlayer] = false;
                    Console.WriteLine(playerName + " is getting out of the penalty box");
                    UpdatePosition(roll);
                    Console.WriteLine("The category is " + _category.CurrentCategory(_places[_currentPlayer]));
                    AskQuestion();
                }
            }
            else
            {
                UpdatePosition(roll);
                Console.WriteLine("The category is " + _category.CurrentCategory(_places[_currentPlayer]));
                AskQuestion();
            }
        }

        private static bool IsEven(int roll)
        {
            return roll % 2 == 0;
        }

        private void UpdatePosition(int roll)
        {
            _places[_currentPlayer] = _places[_currentPlayer] + roll;
            if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

            Console.WriteLine(_players[_currentPlayer].Name
                              + "'s new location is "
                              + _places[_currentPlayer]);
        }

        private void AskQuestion()
        {
            _category.GetQuestions(_places[_currentPlayer]);
        }

        public bool WasCorrectlyAnswered()
        {
            RewardPlayer();
            var winner = DidPlayerNotWin();
            NextPlayer();
            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer].Name + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            NextPlayer();
            return true;
        }

        private void RewardPlayer()
        {
            Console.WriteLine("Answer was correct!!!!");
            _purses[_currentPlayer]++;
            Console.WriteLine(_players[_currentPlayer].Name
                              + " now has "
                              + _purses[_currentPlayer]
                              + " Gold Coins.");
        }

        private void NextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }


        private bool DidPlayerNotWin()
        {
            return _purses[_currentPlayer] != 6;
        }
    }

}
