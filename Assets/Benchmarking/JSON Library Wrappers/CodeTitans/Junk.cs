using CodeTitans.JSon;

public partial class Junk {
    public void Read(IJSonObject input)
    {
        JunkName = input["JunkName"].StringValue;
        JunkData = input["JunkData"].StringValue;

        FloatA = input["FloatA"].SingleValue;
        FloatB = input["FloatB"].SingleValue;
        FloatC = input["FloatC"].SingleValue;
        FloatD = input["FloatD"].SingleValue;
        
        IntA = input["IntA"].Int32Value;
        IntB = input["IntB"].Int32Value;

        MyStuff = new Stuff();
        MyStuff.Read(input["MyStuff"]);

        MyThing = new Thing();
        MyThing.Read(input["MyThing"]);
    }

    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        
        output.WriteMember("JunkName", JunkName);
        output.WriteMember("JunkData", JunkData);
        
        output.WriteMember("FloatA", FloatA);
        output.WriteMember("FloatB", FloatB);
        output.WriteMember("FloatC", FloatC);
        output.WriteMember("FloatD", FloatD);
        
        output.WriteMember("IntA", IntA);
        output.WriteMember("IntB", IntB);

        output.WriteMember("MyStuff");
        MyStuff.Write(output);
        
        output.WriteMember("MyThing");
        MyThing.Write(output);

        output.WriteObjectEnd();
    }
}
