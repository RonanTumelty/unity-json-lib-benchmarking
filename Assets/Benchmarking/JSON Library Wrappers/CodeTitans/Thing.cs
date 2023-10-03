using CodeTitans.JSon;

public partial class Thing {
    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        
        output.WriteMember("MyStringA", MyStringA);
        output.WriteMember("MyStringB", MyStringB);
        output.WriteMember("MyStringC", MyStringC);
        output.WriteMember("MyStringD", MyStringD);
        
        output.WriteObjectEnd();
    }

    public void Read(IJSonObject input)
    {
        MyStringA = input["MyStringA"].StringValue;
        MyStringB = input["MyStringB"].StringValue;
        MyStringC = input["MyStringC"].StringValue;
        MyStringD = input["MyStringD"].StringValue;
    }
}
