using UnityEngine;

[System.Serializable]
public partial class Stuff : ICrap
{
    public Bits MyBits;
    public Pieces MyPieces;

    public string StuffName;
    public string DescA;
    public string DescB;
    public string DescC;
    public string DescD;
    public string DescE;

    public int AttrA;
    public int AttrB;
    public int AttrC;


    public void RandomPopulate()
    {
        MyBits = new Bits();
        MyPieces = new Pieces();
        MyBits.RandomPopulate();
        MyPieces.RandomPopulate();

        StuffName = RandomTextGenerator.GetRandom();
        DescA = RandomTextGenerator.GetRandom();
        DescB = RandomTextGenerator.GetRandom();
        DescC = RandomTextGenerator.GetRandom();
        DescD = RandomTextGenerator.GetRandom();
        DescE = RandomTextGenerator.GetRandom();

        AttrA = Random.Range(0, int.MaxValue);
        AttrB = Random.Range(0, int.MaxValue);
        AttrC = Random.Range(0, int.MaxValue);
    }
}