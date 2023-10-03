using System.Collections;
using System.Collections.Generic;
using CodeTitans.JSon;
using UnityEngine;

public partial class Pieces : IJSonSerializable
{
    public void SimpleJSONParse(SimpleJSON.JSONNode node)
    {
        PieceName = node["PieceName"];
        SimpleJSON.JSONNode arr = node["SomePieces"];
        int count = arr.Count;
        SomePieces = new int[count];
        for (int i = 0; i < count; i++)
        {
            SomePieces[i] = arr[i].AsInt;
        }
    }

    public SimpleJSON.JSONNode SimpleJSONPopulateNode()
    {
        SimpleJSON.JSONNode n = new SimpleJSON.JSONObject();
        n["PieceName"] = PieceName;

        SimpleJSON.JSONArray arr = new SimpleJSON.JSONArray();
        for (int i = 0; i < SomePieces.Length; i++)
        {
            arr[i] = SomePieces[i];
        }
        n["SomePieces"] = arr;

        return n;
    }
}
