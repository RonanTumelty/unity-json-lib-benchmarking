using UnityEngine;

[System.Serializable]
public partial class Junk : ICrap {
    public string JunkName;
    public string JunkData;
    public float FloatA;
    public float FloatD;
    public float FloatC;
    public float FloatB;

    public int IntA;
    public int IntB;

    public Stuff MyStuff;
    public Thing MyThing;

    public void RandomPopulate()
    {
        JunkName = RandomTextGenerator.GetRandom();
        JunkData = RandomTextGenerator.GetRandom();

        FloatA = Random.Range(0f, float.MaxValue);
        FloatB = Random.Range(0f, float.MaxValue);
        FloatC = Random.Range(0f, float.MaxValue);
        FloatD = Random.Range(0f, float.MaxValue);

        IntA = Random.Range(0, int.MaxValue);
        IntB = Random.Range(0, int.MaxValue);

        MyStuff = new Stuff();
        MyThing = new Thing();

        MyStuff.RandomPopulate();
        MyThing.RandomPopulate();
    }
}
