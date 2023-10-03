[System.Serializable]
public partial class Thing : ICrap {
    public string MyStringA;
    public string MyStringB;
    public string MyStringC;
    public string MyStringD;


    public void RandomPopulate()
    {
        MyStringA = RandomTextGenerator.GetRandom();
        MyStringB = RandomTextGenerator.GetRandom();
        MyStringC = RandomTextGenerator.GetRandom();
        MyStringD = RandomTextGenerator.GetRandom();
    }
}
