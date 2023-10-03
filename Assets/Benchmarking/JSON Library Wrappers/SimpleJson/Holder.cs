using System.Collections;
using System.Collections.Generic;
using Benchmarking.Logging;
using UnityEngine;
using CodeTitans.JSon;

public partial class Holder : IJSonSerializable
{
    // Helper for the SimpleJSON lib
    public void SimpleJSONParse(SimpleJSON.JSONNode node)
    {
        SimpleJSON.JSONArray arr = node.AsArray;
        junkList = new Junk[arr.Count];
        int i = 0;
        foreach ( var n in arr)
        {
            junkList[i] = new Junk();
            junkList[i].SimpleJSONParse(n);
            i++;
        }
    }

    public SimpleJSON.JSONNode SimpleJSONPopulateNode()
    {
        SimpleJSON.JSONArray arr = new SimpleJSON.JSONArray();

        for( int i = 0; i < junkList.Length; i++ )
        {
            arr[i] = junkList[i].SimpleJSONPopulateNode();
        }

        return arr;
    }
}
