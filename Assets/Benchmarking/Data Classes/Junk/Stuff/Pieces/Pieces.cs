using UnityEngine;

[System.Serializable]
public partial class Pieces : ICrap
{
    public string PieceName;
    public int[] SomePieces;

    public void RandomPopulate()
    {
        PieceName = RandomTextGenerator.GetRandom();

        SomePieces = new int[Random.Range(1, 32)];

        for (int i = 0; i < SomePieces.Length; i++)
        {
            SomePieces[i] = Random.Range(0, int.MaxValue);
        }
    }
}
