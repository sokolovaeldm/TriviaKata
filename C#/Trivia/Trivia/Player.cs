namespace Trivia;

public class Player
{
    public string Name { get; }
    public int Position { get; set; }
    
    public Player(string name)
    {
        Name = name;
        Position = 0;
    }

}