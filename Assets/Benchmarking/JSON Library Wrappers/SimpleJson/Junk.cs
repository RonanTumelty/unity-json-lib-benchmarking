using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using CodeTitans.JSon;

public partial class Junk : IJSonSerializable {
    public void SimpleJSONParse(SimpleJSON.JSONNode node)
    {
        JunkName = node["JunkName"].ToString();
        JunkData = node["JunkData"].ToString();

        FloatA = node["FloatA"].AsFloat;
        FloatB = node["FloatB"].AsFloat;
        FloatC = node["FloatC"].AsFloat;
        FloatD = node["FloatD"].AsFloat;

        IntA = node["IntA"].AsInt;
        IntB = node["IntB"].AsInt;

        MyStuff = new Stuff();
        MyThing = new Thing();

        MyStuff.SimpleJSONParse(node["MyStuff"]);
        MyThing.SimpleJSONParse(node["MyThing"]);
    }

    public SimpleJSON.JSONNode SimpleJSONPopulateNode()
    {
        SimpleJSON.JSONNode n = new SimpleJSON.JSONObject();
        n["JunkName"] = JunkName;
        n["JunkData"] = JunkData;

        n["FloatA"] = FloatA;
        n["FloatB"] = FloatB;
        n["FloatC"] = FloatC;
        n["FloatD"] = FloatD;

        n["IntA"] = IntA;
        n["IntB"] = IntB;

        n["MyStuff"] = MyStuff.SimpleJSONPopulateNode();
        n["MyThing"] = MyThing.SimpleJSONPopulateNode();

        return n;
    }
}
