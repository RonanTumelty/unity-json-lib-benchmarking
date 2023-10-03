using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeTitans.JSon;

public partial class Stuff : ICrap, IJSonSerializable
{
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
}