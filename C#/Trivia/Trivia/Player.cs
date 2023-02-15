using System;

namespace Trivia;

public class Player
{
    public string Name { get; }
    public int Position { get; private set; }
    public bool IsInPenaltyBox { get; private set; }
    private int PurseCoins { get; set; }
    
    public Player(string name)
    {
        Name = name;
        Position = 0;
        IsInPenaltyBox = false;
        PurseCoins = 0;
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

    public bool RewardPlayer()
    {
        Console.WriteLine("Answer was correct!!!!");
        PurseCoins++;
        Console.WriteLine(Name
                          + " now has "
                          + PurseCoins
                          + " Gold Coins.");
        return !DidPlayerWin();
    }

    public bool DidPlayerWin()
    {
        return PurseCoins == 6;
    }

    public void GoToPenaltyBox()
    {
        Console.WriteLine("Question was incorrectly answered");
        Console.WriteLine(this.Name + " was sent to the penalty box");
        this.IsInPenaltyBox = true;
    }
}