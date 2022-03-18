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
                var randomNumber = GetRandomNumber();

                SelectedWord = SelectNewWord(randomNumber);
                _lastWordUpdateTime = DateTime.Now;
            }
            return _selectedWord;
        }
        set
        {
            _selectedWord = value;
        }
    }

    private Word SelectNewWord(int randomNumber)
    {
        var wordList = _wordProvider.GetWordList();

        var todaysWord = wordList[randomNumber];

        _previouslySelectedWords.Insert(0, todaysWord);
        wordList.Remove(randomNumber);

        return wordList[randomNumber];
    }

    private int GetRandomNumber()
    {
        var wordCount = _wordProvider.GetWordList().Count;

        var random = new Random();
        return random.Next(0, wordCount - 1);
    }
}