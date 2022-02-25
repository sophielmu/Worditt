using System.Text;

public static class WordList 
{
    public static Dictionary<int, Word> AllWords {get; set;} = new();

    public static void PopulateWordList()
    {
        var filePath = "/home/slacey/Worditt/sgb-words.txt";
        // TODO replace this with something better ^^^
        var sb = new StringBuilder();
        int counter = 0;
        
        foreach(var line in System.IO.File.ReadLines(filePath))
        {
            AllWords.Add(counter, new Word(line));
            counter++;
        }
    }
}