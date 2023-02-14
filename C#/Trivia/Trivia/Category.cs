using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia;

public class Category
{
    private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
    private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
    private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
    private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

    
    public Category()
    {
        for (var i = 0; i < 50; i++)
        {
            _popQuestions.AddLast("Pop Question " + i);
            _scienceQuestions.AddLast(("Science Question " + i));
            _sportsQuestions.AddLast(("Sports Question " + i));
            _rockQuestions.AddLast("Rock Question " + i);
        }
    }

    public void GetQuestions(int place)
    {
        switch (CurrentCategory(place))
        {
            case "Pop":
                Console.WriteLine(_popQuestions.First?.Value);
                _popQuestions.RemoveFirst();
                break;
            case "Science":
                Console.WriteLine(_scienceQuestions.First?.Value);
                _scienceQuestions.RemoveFirst();
                break;
            case "Sports":
                Console.WriteLine(_sportsQuestions.First?.Value);
                _sportsQuestions.RemoveFirst();
                break;
            default:
                Console.WriteLine(_rockQuestions.First?.Value);
                _rockQuestions.RemoveFirst();
                break;
        }
    }

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