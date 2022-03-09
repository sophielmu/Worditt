using Microsoft.AspNetCore.Mvc;
namespace Worditt.Controllers;

[ApiController]
[Route("[controller]")]
public class WordController : ControllerBase
{
    private readonly ILogger<WordController> _logger;
    private WordSelector _wordSelector;

    public WordController()
    {
        // _logger = logger;
        var filePath = "..//Worditt//sgb-words.txt";
        var textFileWordProvider = new TextFileWordProvider(filePath);
        _wordSelector = new WordSelector(textFileWordProvider);
    }

    [HttpGet(Name = "GetWord")]
    public int[] Get(string guess)
    {
        Word guessWord = new Word(guess);
        return _wordSelector.SelectedWord.GetCorrectLetters(guessWord.CharArray);
    }    
}
