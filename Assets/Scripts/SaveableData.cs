public static class SaveableData
{
    public static long Record { get; private set; }

    public static void AddScore()
    {
        Record++;
    }
}
