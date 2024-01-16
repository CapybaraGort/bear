public static class RuntimeData
{
    public static int CurrentScore {  get; private set; }

    public static void AddScore()
    {
        CurrentScore++;
    }
    public static void ClearScore()
    {
        CurrentScore = 0;
    }
}