using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia;

//Categories - creator
public class QuestionFactory
{
    //ConcreteCreators
    
    private readonly Category _popCategory = new PopCategory();
    private readonly Category _scienceCategory = new ScienceCategory();
    private readonly Category _sportsCategory = new SportsCategory();
    private readonly Category _rockCategory = new RockCategory();
    
    // Concrete Question Type (Pop, Science...)


    //Creator method
    public void GetQuestion(int place)
    {
        var currentCategory = CurrentCategory(place);
        Console.WriteLine("The category is " + currentCategory.CategoryName);
        
        currentCategory.GetQuestion();
    }

    private Category CurrentCategory(int place)
    {
        return (place % 4) switch
        {
            0 => _popCategory,
            1 => _scienceCategory,
            2 => _sportsCategory,
            _ => _rockCategory
        };
    }
}
