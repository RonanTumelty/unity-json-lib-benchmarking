using System.Collections;
using System.Collections.Generic;
using CodeTitans.JSon;
using UnityEngine;

public partial class Thing : IJSonSerializable {
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
}
