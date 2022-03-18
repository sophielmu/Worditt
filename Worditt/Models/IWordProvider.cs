public interface IWordProvider
{
    public Dictionary<int, Word> GetWordList();

    public void RemoveWord(int key);
}