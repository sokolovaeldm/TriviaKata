using System;
using System.Collections.Generic;

namespace Trivia;

public abstract class Category
{
    private readonly LinkedList<string> _questions = new();
    private readonly string _categoryName;

    protected Category(string categoryName)
    {
        _categoryName = categoryName;
        for (var i = 0; i < 50; i++)
        {
            _questions.AddLast($"{categoryName} Question {i}");
        }
    }
    
    public void GetQuestion()
    {
        Console.WriteLine("The category is " + _categoryName);
        Console.WriteLine(_questions.First?.Value);
        _questions.RemoveFirst();
    }
}

public class PopCategory : Category
{
    public PopCategory() : base("Pop")
    {
    }
}

public class ScienceCategory : Category
{
    public ScienceCategory() : base("Science")
    {
    }
}

public class SportsCategory : Category
{
    public SportsCategory() : base("Sports")
    {
    }
}

public class RockCategory : Category
{
    public RockCategory() : base("Rock")
    {
    }
}