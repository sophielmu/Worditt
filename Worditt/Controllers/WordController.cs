using Microsoft.AspNetCore.Mvc;
namespace Worditt.Controllers;

[ApiController]
[Route("[controller]")]
public class WordController : ControllerBase
{
    private readonly ILogger<WordController> _logger;

    public WordController()
    {
        // _logger = logger;
    }

    [HttpGet(Name = "GetWord")]
    public int[] Get(string guess)
    {
        Word guessWord = new Word(guess);
        return WordSelector.SelectedWord.GetCorrectLetters(guessWord.CharArray);
    }    
}
