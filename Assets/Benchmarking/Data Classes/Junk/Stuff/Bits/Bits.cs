using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeTitans.JSon;
using SimdJsonSharp;
using Random = UnityEngine.Random;

[System.Serializable]
public class Bits : ICrap
{
    public string BitsName;
    public string[] SomeBits;

    public void RandomPopulate()
    {
        BitsName = RandomTextGenerator.GetRandom();

        SomeBits = new string[Random.Range(1, 32)];

        for( int i =0; i < SomeBits.Length; i++)
        {
            SomeBits[i] = RandomTextGenerator.GetRandom();
        }
    }


    #region SimpleJSON
    public void SimpleJSONParse(SimpleJSON.JSONNode node)
    {
        BitsName = node["BitsName"];
        SimpleJSON.JSONNode arr = node["SomePieces"];
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
    #endregion

    #region CodeTitans
    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        output.WriteMember("BitsName", BitsName);
        output.WriteMember("SomeBits");
        output.WriteArrayBegin();
        foreach (var bit in SomeBits)
        {
            output.WriteValue(bit);
        }
        output.WriteArrayEnd();
        output.WriteObjectEnd();
    }

    public void Read(IJSonObject input)
    {
        BitsName = input["BitsName"].StringValue;

        var SomeBitsArray = input["SomeBits"];
        SomeBits = new string[SomeBitsArray.Count];
        for (int i = 0; i < SomeBitsArray.Count; i++)
        {
            SomeBits[i] = SomeBitsArray[i].StringValue;
        }
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
                    case "BitsName":
                    BitsName = iterator.GetUtf16String();
                    break;
                    case "SomeBits": 
                    iterator.MoveForward();
                    
                    List<string> bitsList = new List<string>();

                    while (iterator.IsString())
                    {
                        bitsList.Add(iterator.GetUtf16String());
                        iterator.MoveForward();
                    }

                    SomeBits = bitsList.ToArray();
                    break;
                }
            }
            iterator.MoveForward();
        }
    }
    #endregion
}
