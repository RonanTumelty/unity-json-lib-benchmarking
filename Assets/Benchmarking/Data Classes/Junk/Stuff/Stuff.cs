using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeTitans.JSon;

[System.Serializable]
public class Stuff : ICrap, IJSonSerializable
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

    #region SimpleJson
    public void SimpleJSONParse(SimpleJSON.JSONNode node)
    {
        StuffName = node["StuffName"].ToString();
        DescA = node["DescA"].ToString();
        DescB = node["DescB"].ToString();
        DescC = node["DescC"].ToString();
        DescD = node["DescD"].ToString();
        DescE = node["DescE"].ToString();

        AttrA = node["AttrA"].AsInt;
        AttrB = node["AttrB"].AsInt;
        AttrC = node["AttrC"].AsInt;

        MyBits = new Bits();
        MyPieces = new Pieces();

        MyBits.SimpleJSONParse(node["MyBits"]);
        MyPieces.SimpleJSONParse(node["MyPieces"]);
    }

    public SimpleJSON.JSONNode SimpleJSONPopulateNode()
    {
        SimpleJSON.JSONNode n = new SimpleJSON.JSONObject();
        n["StuffName"] = StuffName;

        n["DescA"] = DescA;
        n["DescB"] = DescB;
        n["DescC"] = DescC;
        n["DescD"] = DescD;
        n["DescE"] = DescE;

        n["AttrA"] = AttrA;
        n["AttrB"] = AttrB;
        n["AttrC"] = AttrC;

        n["MyBits"] = MyBits.SimpleJSONPopulateNode();
        n["MyPieces"] = MyPieces.SimpleJSONPopulateNode();

        return n;
    }
    #endregion

    #region CodeTitans
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
    #endregion
}