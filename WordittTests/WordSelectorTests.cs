using NUnit.Framework;

namespace WordittTests;

public class WordSelectorTests
{
    private WordSelector _wordSelector;
    private IWordProvider _wordProvider;
    private string _testWordsPath = "..//..//WordittTests//testWords.txt";

    [SetUp]
    public void Setup()
    {
        _wordProvider = new TextFileWordProvider(_testWordsPath);
        _wordSelector = new WordSelector(_wordProvider);
    }

    [Test]
    public void SelectNewWord()
    {
        Assert.Pass();
    }
}