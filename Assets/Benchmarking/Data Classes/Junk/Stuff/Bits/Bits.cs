using UnityEngine;

[System.Serializable]
public partial class Bits : ICrap
{
    public string BitsName;
    public string[] SomeBits;

    public void RandomPopulate()
    {
        BitsName = RandomTextGenerator.GetRandom();

        SomeBits = new string[Random.Range(1, 32)];

        for( int i =0; i < SomeBits.Length; i++)
        {
            SomeBits[i] = RandomTextGenerator.GetRandom();
        }
    }
}
