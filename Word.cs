public class Word
{
    public Word()
    {
        
    }
    public Word(string word)
    {
        CharArray = word.ToCharArray();
    }
    public char[] CharArray {get; set;}
    public static int Length => 5;

    public int[] GetCorrectLetters(char[] guess)
    {
        int[] result = new int[Length];
        for(int i = 0; i < Length; i++)
        {
            if (CharArray.Contains(guess[i]))
            {
                result[i] = CharArray[i] == guess[i] ? 1 : 2;
            }
            else
            {
                result[i] = 0;
            }
        }

        return result;
    }
}