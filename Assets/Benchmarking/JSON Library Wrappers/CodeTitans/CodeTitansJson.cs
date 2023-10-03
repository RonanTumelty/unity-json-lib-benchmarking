using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using CodeTitans.JSon;

public class CodeTitansJson  : IJsonLibrary
{
    private string jsonText;
    private Holder jsonData;
    
    public void Setup(string t, Holder sourceData)
    {
        jsonText = t;
        jsonData = sourceData;
    }

    public string Serialize(Stopwatch timer)
    {
        timer.Start();
        JSonWriter jSonWriter = new JSonWriter();
        
        jsonData.Write(jSonWriter);
        string s = jSonWriter.ToString();

        return "Resulting json is " + s.Length.ToString("n0") + " characters";
    }

    public string Deserialize(Stopwatch timer)
    {
        timer.Start();

        JSonReader jsonReader = new JSonReader(jsonText);
        var item = jsonReader.ReadAsJSonObject();
        Holder list = new Holder();
        list.Read(item);

        return "Parsed list is " + list.junkList.Length + " entries long";
    }
}
