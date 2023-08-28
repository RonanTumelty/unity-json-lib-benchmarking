using System.Collections;
using System.Collections.Generic;
using CodeTitans.JSon;
using UnityEngine;

[System.Serializable]
public class Thing : ICrap, IJSonSerializable {
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

    #region SimpleJson
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
}
