using CodeTitans.JSon;
public partial class Pieces
{
    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        output.WriteMember("PieceName", PieceName);
        output.WriteMember("SomePieces");
        output.WriteArrayBegin();
        foreach (var piece in SomePieces)
        {
            output.WriteValue(piece);
        }
        output.WriteArrayEnd();
        output.WriteObjectEnd();
    }

    public void Read(IJSonObject input)
    {
        PieceName = input["PieceName"].StringValue;

        var SomePiecesArray = input["SomePieces"];
        SomePieces = new int[SomePiecesArray.Count];
        for (int i = 0; i < SomePiecesArray.Count; i++)
        {
            SomePieces[i] = SomePiecesArray[i].Int32Value;
        }
    }
}
