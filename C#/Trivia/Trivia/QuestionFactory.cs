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
        switch (CurrentCategory(place))
        {
            case "Pop":
                _popCategory.GetQuestion();
                break;
            case "Science":
                _scienceCategory.GetQuestion();
                break;
            case "Sports":
                _sportsCategory.GetQuestion();
                break;
            default:
                _rockCategory.GetQuestion();
                break;
        }
    }

    //Categories class (creator)
    public string CurrentCategory(int place)
    {

        switch (place)
        {
            case 0:
            case 4:
            case 8:
                return "Pop";
            case 1:
            case 5:
            case 9:
                return "Science";
            case 2:
            case 6:
            case 10:
                return "Sports";
            default:
                return "Rock";
        }
    }
}