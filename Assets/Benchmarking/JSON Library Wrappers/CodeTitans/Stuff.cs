using CodeTitans.JSon;

public partial class Stuff 
{
    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        
        output.WriteMember("StuffName", StuffName);
        
        output.WriteMember("DescA", DescA);
        output.WriteMember("DescB", DescB);
        output.WriteMember("DescC", DescC);
        output.WriteMember("DescD", DescD);
        output.WriteMember("DescE", DescE);
        
        output.WriteMember("AttrA", AttrA);
        output.WriteMember("AttrB", AttrB);
        output.WriteMember("AttrC", AttrC);

        output.WriteMember("MyBits");
        MyBits.Write(output);
        
        output.WriteMember("MyPieces");
        MyPieces.Write(output);
        
        output.WriteObjectEnd();
    }

    public void Read(IJSonObject input)
    {
        StuffName = input["StuffName"].StringValue;

        DescA = input["DescA"].StringValue;
        DescB = input["DescB"].StringValue;
        DescC = input["DescC"].StringValue;
        DescD = input["DescD"].StringValue;
        DescE = input["DescE"].StringValue;
        
        AttrA = input["AttrA"].Int32Value;
        AttrB = input["AttrB"].Int32Value;
        AttrC = input["AttrC"].Int32Value;

        MyBits = new Bits();
        MyBits.Read(input["MyBits"]);

        MyPieces = new Pieces();
        MyPieces.Read(input["MyPieces"]);
    }
}