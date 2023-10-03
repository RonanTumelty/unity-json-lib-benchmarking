using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeTitans.JSon;

public partial class Bits : IJSonSerializable
{
    public void SimpleJSONParse(SimpleJSON.JSONNode node)
    {
        BitsName = node["BitsName"];
        SimpleJSON.JSONNode arr = node["SomeBits"];
        int count = arr.Count;
        SomeBits = new string[count];
        for (int i = 0; i < count; i++)
        {
            SomeBits[i] = arr[i].ToString();
        }
    }

    public SimpleJSON.JSONNode SimpleJSONPopulateNode()
    {
        SimpleJSON.JSONNode n = new SimpleJSON.JSONObject();
        n["BitsName"] = BitsName;

        SimpleJSON.JSONArray arr = new SimpleJSON.JSONArray();
        for (int i = 0; i < SomeBits.Length; i++)
        {
            arr[i] = SomeBits[i];
        }
        n["SomeBits"] = arr;

        return n;
    }
}
