using System.Text;

public class TextFileWordProvider : IWordProvider
{
    private string _filePath;
    private Dictionary<int, Word> _wordList { get; init; } = new();
    public TextFileWordProvider(string filePath)
    {
        _filePath = filePath;
        PopulateWordList();
    }

    public Dictionary<int, Word> GetWordList()
    {
        return _wordList;
    }

    internal void PopulateWordList()
    {
        var sb = new StringBuilder();
        int counter = 0;
        
        foreach(var line in System.IO.File.ReadLines(_filePath))
        {
            _wordList.Add(counter, new Word(line));
            counter++;
        }
    }

    public void RemoveWord(int key)
    {
        _wordList.Remove(key);
    }
}