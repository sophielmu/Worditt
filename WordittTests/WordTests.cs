using NUnit.Framework;

namespace WordittTests;

public class WordTests
{
    private Word _word;

    [SetUp]
    public void Setup()
    {
        _word = new Word("CRANE");
    }

    [Test]
    public void GetCorrectLetters_NoneCorrect_ExpectArrayOfZeros()
    {
        string guess = "SPOUT";
        var result = _word.GetCorrectLetters(guess.ToCharArray());

        Assert.AreEqual(new int[]{0, 0, 0, 0, 0}, result);
    }

    [Test]
    public void GetCorrectLetters_AllCorrect_ExpectArrayOfOnes()
    {
        string guess = "CRANE";
        var result = _word.GetCorrectLetters(guess.ToCharArray());

        Assert.AreEqual(new int[]{1, 1, 1, 1, 1}, result);
    }

    [Test]
    public void GetCorrectLetters_AllCorrectButInWrongPlaces_ExpectArrayOfTwos()
    {
        string guess = "ECRAN";

        var result = _word.GetCorrectLetters(guess.ToCharArray());

        Assert.AreEqual(new int[]{2, 2, 2, 2, 2}, result);
    }

    [Test]
    public void GetCorrectLetters_SomeCorrect_ExpectMixedArray()
    {
        string guess = "TRAIN";

        var result = _word.GetCorrectLetters(guess.ToCharArray());

        Assert.AreEqual(new int[]{0, 1, 1, 0, 2}, result);
    }
}