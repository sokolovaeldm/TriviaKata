using System.Collections.Generic;

namespace Trivia;

public class QuestionFactory
{
    private readonly List<Category> _categories;
    
    public QuestionFactory()
    {
        _categories = new List<Category>()
        {
            new PopCategory(),
            new ScienceCategory(),
            new SportsCategory(),
            new RockCategory()
        };
    }

    public void GetQuestion(int place)
    {
        var currentCategory = CurrentCategory(place);
        
        currentCategory.GetQuestion();
    }

    private Category CurrentCategory(int place)
    {
        return _categories[(place % _categories.Count)];
    }
}
