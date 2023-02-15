using System;

namespace Trivia;

public class Player
{
    public string Name { get; }
    public int Position { get; set; }
    public int PurseCoins { get; set; }
    public bool IsInPenaltyBox { get; set; }
    
    public Player(string name)
    {
        Name = name;
        Position = 0;
        PurseCoins = 0;
        IsInPenaltyBox = false;
    }

    public void UpdatePosition(int roll, int boardSize)
    {
        Position = (Position + roll) % boardSize;
        Console.WriteLine(Name
                          + "'s new location is "
                          + Position);
    }
}