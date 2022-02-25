public static class WordSelector
{
    private static Word _selectedWord = new Word();
    private static DateTime _lastWordUpdateTime;
    private static List<Word> _previouslySelectedWords = new List<Word>();
    public static Word SelectedWord
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

    private static Word SelectNewWord()
    {
        var random = new Random();
        var randomNumber = random.Next(0, WordList.AllWords.Count - 1);

        var todaysWord = WordList.AllWords[random.Next(0, WordList.AllWords.Count - 1)];

        _previouslySelectedWords.Insert(0, todaysWord);
        WordList.AllWords.Remove(randomNumber);

        return WordList.AllWords[random.Next(0, WordList.AllWords.Count - 1)];
    }
}