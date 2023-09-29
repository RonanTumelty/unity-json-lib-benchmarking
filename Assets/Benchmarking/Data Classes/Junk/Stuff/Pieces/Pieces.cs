using System.Collections;
using System.Collections.Generic;
using CodeTitans.JSon;
using SimdJsonSharp;
using UnityEngine;

[System.Serializable]
public class Pieces : ICrap
{
    public string PieceName;
    public int[] SomePieces;

    public void RandomPopulate()
    {
        PieceName = RandomTextGenerator.GetRandom();

        SomePieces = new int[Random.Range(1, 32)];

        for (int i = 0; i < SomePieces.Length; i++)
        {
            SomePieces[i] = Random.Range(0, int.MaxValue);
        }
    }


    #region SimpleJSON
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
    #endregion

    #region CodeTitans
    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        output.WriteMember("PieceName", PieceName);
        output.WriteMember("SomePieces");
        output.WriteArrayBegin();
        foreach (var piece in SomePieces)
        {
            output.WriteValue(piece);
        }
        output.WriteArrayEnd();
        output.WriteObjectEnd();
    }

    public void Read(IJSonObject input)
    {
        PieceName = input["PieceName"].StringValue;

        var SomePiecesArray = input["SomePieces"];
        SomePieces = new int[SomePiecesArray.Count];
        for (int i = 0; i < SomePiecesArray.Count; i++)
        {
            SomePieces[i] = SomePiecesArray[i].Int32Value;
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
                    case "PieceName":
                        PieceName = iterator.GetUtf16String();
                        break;
                    case "SomePieces":
                        iterator.MoveForward();
                        
                        List<int> pieceList = new List<int>();

                        while (iterator.IsInteger())
                        {
                            pieceList.Add((int)iterator.GetInteger());
                            iterator.MoveForward();
                        }

                        SomePieces = pieceList.ToArray();
                        break;
                }
            }
            iterator.MoveForward();
        }
    }
    #endregion
}
