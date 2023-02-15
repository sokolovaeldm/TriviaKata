using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private const int BoardSize = 12;

        private readonly List<Player> _players = new();
        private readonly Category _category;
        private Player _activePlayer;

        public Game(List<string> playersName)
        {
            IsPlayable(playersName);
            
            _category = new Category();
            foreach (var playerName in playersName)
            {
                Add(playerName);
            }

            _activePlayer = _players.First();
        }

        private void IsPlayable(List<string> playersName)
        {
            if(playersName.Count < 2)
                throw new ValidationException("Players should be more than 2");
        }

        private void Add(string playerName)
        {
            _players.Add(new Player(playerName));
            
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
        }

        public void Roll(int roll)
        {
            var playerName = _activePlayer.Name;
            Console.WriteLine(playerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_activePlayer.IsInPenaltyBox)
            {
                if (IsEven(roll))
                {
                    Console.WriteLine(playerName + " is not getting out of the penalty box");
                    _activePlayer.IsInPenaltyBox = true;
                }
                else
                {
                    _activePlayer.IsInPenaltyBox = false;
                    Console.WriteLine(playerName + " is getting out of the penalty box");
                    _activePlayer.UpdatePosition(roll, BoardSize);
                    Console.WriteLine("The category is " + _category.CurrentCategory(_activePlayer.Position));
                    AskQuestion();
                }
            }
            else
            {
                _activePlayer.UpdatePosition(roll, BoardSize);
                Console.WriteLine("The category is " + _category.CurrentCategory(_activePlayer.Position));
                AskQuestion();
            }
        }

        private static bool IsEven(int roll)
        {
            return roll % 2 == 0;
        }

        private void AskQuestion()
        {
            _category.GetQuestions(_activePlayer.Position);
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
            Console.WriteLine(_activePlayer.Name + " was sent to the penalty box");
            _activePlayer.IsInPenaltyBox = true;

            NextPlayer();
            return true;
        }

        private void RewardPlayer()
        {
            Console.WriteLine("Answer was correct!!!!");
            _activePlayer.PurseCoins++;
            Console.WriteLine(_activePlayer.Name
                              + " now has "
                              + _activePlayer.PurseCoins
                              + " Gold Coins.");
        }

        private void NextPlayer()
        {
            var currentIndex = _players.IndexOf(_activePlayer);
            var nextIndex = (currentIndex + 1) % _players.Count;
            _activePlayer = _players[nextIndex];
        }
        
        private bool DidPlayerNotWin()
        {
            return _activePlayer.PurseCoins != 6;
        }
    }
}
