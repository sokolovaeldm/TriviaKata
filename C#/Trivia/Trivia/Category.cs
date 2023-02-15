using System;
using System.Collections.Generic;

namespace Trivia;

public abstract class Category
{
    protected LinkedList<string> _questions = new();
    
    public Category(string categoryName)
    {
        for (var i = 0; i < 50; i++)
        {
            _questions.AddLast($"{categoryName} Question {i}");
        }
    }
    
    public void GetQuestion()
    {
        Console.WriteLine(_questions.First?.Value);
        _questions.RemoveFirst();
    }
}

public class PopCategory : Category
{
    private const string CategoryName = "Pop";
    public PopCategory() : base(CategoryName)
    {
    }
}

public class ScienceCategory : Category
{
    private const string CategoryName = "Science";
    public ScienceCategory() : base(CategoryName)
    {
    }
}

public class SportsCategory : Category
{
    private const string CategoryName = "Sports";
    public SportsCategory() : base(CategoryName)
    {
    }
}

public class RockCategory : Category
{
    private const string CategoryName = "Rock";
    public RockCategory() : base(CategoryName)
    {
    }
}