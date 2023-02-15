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

    public void ShouldStayPenaltyBox(bool isEven)
    {
        
        
        if (isEven)
        {
            Console.WriteLine(Name + " is not getting out of the penalty box");
            IsInPenaltyBox = true;
        }
        else
        {
            IsInPenaltyBox = false;
            Console.WriteLine(Name + " is getting out of the penalty box");
        }
    }

    public void RewardPlayer()
    {
        Console.WriteLine("Answer was correct!!!!");
        PurseCoins++;
        Console.WriteLine(Name
                          + " now has "
                          + PurseCoins
                          + " Gold Coins.");
    }

    public bool DidPlayerNotWin()
    {
        return PurseCoins != 6;
    }
}