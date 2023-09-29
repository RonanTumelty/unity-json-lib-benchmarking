using System.Collections;
using System.Collections.Generic;
using CodeTitans.JSon;
using SimdJsonSharp;
using UnityEngine;

[System.Serializable]
public class Thing : ICrap {
    public string MyStringA;
    public string MyStringB;
    public string MyStringC;
    public string MyStringD;


    public void RandomPopulate()
    {
        MyStringA = RandomTextGenerator.GetRandom();
        MyStringB = RandomTextGenerator.GetRandom();
        MyStringC = RandomTextGenerator.GetRandom();
        MyStringD = RandomTextGenerator.GetRandom();
    }


    #region SimpleJSON
    public void SimpleJSONParse(SimpleJSON.JSONNode node)
    {
        MyStringA = node["MyStringA"].ToString();
        MyStringB = node["MyStringB"].ToString();
        MyStringC = node["MyStringC"].ToString();
        MyStringD = node["MyStringD"].ToString();
    }

    public SimpleJSON.JSONNode SimpleJSONPopulateNode()
    {
        SimpleJSON.JSONNode n = new SimpleJSON.JSONObject();

        n["MyStringA"] = MyStringA;
        n["MyStringB"] = MyStringB;
        n["MyStringC"] = MyStringC;
        n["MyStringD"] = MyStringD;

        return n;
    }
    #endregion

    #region CodeTitans
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
    #endregion

    #region SimdJsonNative
    public void Read(ParsedJsonIteratorN iterator)
    {
        iterator.MoveForward();
        long depth = iterator.GetDepth();
        while (iterator.GetDepth() >= depth)
        {
            if (iterator.IsString())
            {
                string label = iterator.GetUtf16String();
                iterator.MoveForward();
                switch (label)
                {
                    case "MyStringA":
                        MyStringA = iterator.GetUtf16String();
                        break;
                    case "MyStringB":
                        MyStringA = iterator.GetUtf16String();
                        break;
                    case "MyStringC":
                        MyStringA = iterator.GetUtf16String();
                        break;
                    case "MyStringD":
                        MyStringA = iterator.GetUtf16String();
                        break;
                }
            }

            iterator.MoveForward();
        }
    }
    #endregion
}
