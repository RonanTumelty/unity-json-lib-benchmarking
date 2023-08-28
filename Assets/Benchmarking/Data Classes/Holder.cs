using System.Collections;
using System.Collections.Generic;
using Benchmarking.Logging;
using UnityEngine;
using CodeTitans.JSon;

[System.Serializable]
public class Holder : ICrap, IJSonSerializable
{
    public int Capacity = 0;
    public Junk[] junkList;

    public void RandomPopulate()
    {
        junkList = new Junk[Capacity];
        for ( int i = 0; i < Capacity; i++)
        {
            junkList[i] = new Junk();
            junkList[i].RandomPopulate();
        }
    }

    #region SimpleJSON
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
    #endregion

    #region CodeTitans
    public void Read(IJSonObject input)
    {
        Capacity = input["Capacity"].Int32Value;
        var junkListArray = input["junkList"];
        junkList = new Junk[junkListArray.Count];
        for (int i = 0; i < junkListArray.Count; i++)
        {
            junkList[i] = new Junk();
            junkList[i].Read(junkListArray[i]);
        }
    }

    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        
        output.WriteMember("Capacity", Capacity);
        
        output.WriteMember("junkList");
        output.WriteArrayBegin();
        foreach (var junk in junkList)
        {
            junk.Write(output);
        }
        output.WriteArrayEnd();
        
        output.WriteObjectEnd();
    }
    #endregion
}
