public class WordSelector
{
    private static Word _selectedWord = new Word();
    private static DateTime _lastWordUpdateTime;
    private static List<Word> _previouslySelectedWords = new List<Word>();
    private IWordProvider _wordProvider;

    public WordSelector(IWordProvider wordProvider)
    {
        _wordProvider = wordProvider;
    }
    public Word SelectedWord
    {
        get
        {
            if (_lastWordUpdateTime.Date != DateTime.Now.Date || _lastWordUpdateTime == default(DateTime))
            {
                SelectedWord = SelectNewWord();
                _lastWordUpdateTime = DateTime.Now;
            }
            return _selectedWord;
        }
        set
        {
            _selectedWord = value;
        }
    }

    private Word SelectNewWord()
    {
        var wordList = _wordProvider.GetWordList();

        var random = new Random();
        var randomNumber = random.Next(0, wordList.Count - 1);

        var todaysWord = wordList[random.Next(0, wordList.Count - 1)];

        _previouslySelectedWords.Insert(0, todaysWord);
        wordList.Remove(randomNumber);

        return wordList[random.Next(0, wordList.Count - 1)];
    }
}