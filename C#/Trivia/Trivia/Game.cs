using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> _players = new();

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
            var activePlayer = _players[_currentPlayer];
            var playerName = activePlayer.Name;
            Console.WriteLine(playerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (activePlayer.IsInPenaltyBox)
            {
                if (IsEven(roll))
                {
                    Console.WriteLine(playerName + " is not getting out of the penalty box");
                    activePlayer.IsInPenaltyBox = true;
                }
                else
                {
                    activePlayer.IsInPenaltyBox = false;
                    Console.WriteLine(playerName + " is getting out of the penalty box");
                    UpdatePosition(activePlayer, roll);
                    Console.WriteLine("The category is " + _category.CurrentCategory(activePlayer.Position));
                    AskQuestion(activePlayer);
                }
            }
            else
            {
                UpdatePosition(activePlayer, roll);
                Console.WriteLine("The category is " + _category.CurrentCategory(activePlayer.Position));
                AskQuestion(activePlayer);
            }
        }

        private static bool IsEven(int roll)
        {
            return roll % 2 == 0;
        }

        private void UpdatePosition(Player activePlayer, int roll)
        {
            activePlayer.Position = (activePlayer.Position + roll) % 12;

            Console.WriteLine(activePlayer.Name
                              + "'s new location is "
                              + activePlayer.Position);
        }

        private void AskQuestion(Player activePlayer)
        {
            _category.GetQuestions(activePlayer.Position);
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
            _players[_currentPlayer].IsInPenaltyBox = true;

            NextPlayer();
            return true;
        }

        private void RewardPlayer()
        {
            var activePlayer = _players[_currentPlayer];
            Console.WriteLine("Answer was correct!!!!");
            activePlayer.PurseCoins++;
            Console.WriteLine(activePlayer.Name
                              + " now has "
                              + activePlayer.PurseCoins
                              + " Gold Coins.");
        }

        private void NextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }


        private bool DidPlayerNotWin()
        {
            return _players[_currentPlayer].PurseCoins != 6;
        }
        
    }

}
