using CodeTitans.JSon;

public partial class Bits
{
    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        output.WriteMember("BitsName", BitsName);
        output.WriteMember("SomeBits");
        output.WriteArrayBegin();
        foreach (var bit in SomeBits)
        {
            output.WriteValue(bit);
        }
        output.WriteArrayEnd();
        output.WriteObjectEnd();
    }

    public void Read(IJSonObject input)
    {
        BitsName = input["BitsName"].StringValue;

        var SomeBitsArray = input["SomeBits"];
        SomeBits = new string[SomeBitsArray.Count];
        for (int i = 0; i < SomeBitsArray.Count; i++)
        {
            SomeBits[i] = SomeBitsArray[i].StringValue;
        }
    }
}
