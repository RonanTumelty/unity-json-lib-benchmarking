using System.Collections;
using System.Collections.Generic;
using Benchmarking.Logging;
using UnityEngine;
using CodeTitans.JSon;

public partial class Holder
{
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
}
