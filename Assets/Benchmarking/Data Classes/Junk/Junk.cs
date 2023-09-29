using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using CodeTitans.JSon;
using SimdJsonSharp;
using UnityEditor.Experimental.GraphView;

[System.Serializable]
public class Junk : ICrap {
    public string JunkName;
    public string JunkData;
    public float FloatA;
    public float FloatD;
    public float FloatC;
    public float FloatB;

    public int IntA;
    public int IntB;

    public Stuff MyStuff;
    public Thing MyThing;

    public void RandomPopulate()
    {
        JunkName = RandomTextGenerator.GetRandom();
        JunkData = RandomTextGenerator.GetRandom();

        FloatA = Random.Range(0f, float.MaxValue);
        FloatB = Random.Range(0f, float.MaxValue);
        FloatC = Random.Range(0f, float.MaxValue);
        FloatD = Random.Range(0f, float.MaxValue);

        IntA = Random.Range(0, int.MaxValue);
        IntB = Random.Range(0, int.MaxValue);

        MyStuff = new Stuff();
        MyThing = new Thing();

        MyStuff.RandomPopulate();
        MyThing.RandomPopulate();
    }


    #region SimpleJSON
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
    #endregion

    #region CodeTitans
    public void Read(IJSonObject input)
    {
        JunkName = input["JunkName"].StringValue;
        JunkData = input["JunkData"].StringValue;

        FloatA = input["FloatA"].SingleValue;
        FloatB = input["FloatB"].SingleValue;
        FloatC = input["FloatC"].SingleValue;
        FloatD = input["FloatD"].SingleValue;
        
        IntA = input["IntA"].Int32Value;
        IntB = input["IntB"].Int32Value;

        MyStuff = new Stuff();
        MyStuff.Read(input["MyStuff"]);

        MyThing = new Thing();
        MyThing.Read(input["MyThing"]);
    }

    public void Write(IJSonWriter output)
    {
        output.WriteObjectBegin();
        
        output.WriteMember("JunkName", JunkName);
        output.WriteMember("JunkData", JunkData);
        
        output.WriteMember("FloatA", FloatA);
        output.WriteMember("FloatB", FloatB);
        output.WriteMember("FloatC", FloatC);
        output.WriteMember("FloatD", FloatD);
        
        output.WriteMember("IntA", IntA);
        output.WriteMember("IntB", IntB);

        output.WriteMember("MyStuff");
        MyStuff.Write(output);
        
        output.WriteMember("MyThing");
        MyThing.Write(output);

        output.WriteObjectEnd();
    }
    #endregion
    
    #region SimdJSON
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
                    case "JunkName":
                        JunkName = iterator.GetUtf16String();
                        iterator.MoveForward();
                        break;
                    case "JunkData":
                        JunkData = iterator.GetUtf16String();
                        iterator.MoveForward();
                        break;
                    case "FloatA":
                        FloatA = (float)iterator.GetDouble();
                        iterator.MoveForward();
                        break;
                    case "FloatB":
                        FloatB = (float)iterator.GetDouble();
                        iterator.MoveForward();
                        break;
                    case "FloatC":
                        FloatC = (float)iterator.GetDouble();
                        iterator.MoveForward();
                        break;
                    case "FloatD":
                        FloatD = (float)iterator.GetDouble();
                        iterator.MoveForward();
                        break;
                    case "IntA":
                        IntA = (int)iterator.GetInteger();
                        iterator.MoveForward();
                        break;
                    case "IntB":
                        IntB = (int)iterator.GetInteger();
                        iterator.MoveForward();
                        break;
                    case "MyStuff":
                        MyStuff = new Stuff();
                        MyStuff.Read(iterator);
                        break;
                    case "MyThing":
                        MyThing = new Thing();
                        MyThing.Read(iterator);
                        break;
                }
            }
            else
            {
                iterator.MoveForward();
            }
        }
    }
    #endregion
}
