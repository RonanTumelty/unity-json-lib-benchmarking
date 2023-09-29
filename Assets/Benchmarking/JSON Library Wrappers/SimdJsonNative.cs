using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Text;
using SimdJsonSharp;
using Debug = UnityEngine.Debug;

public class SimdJsonNative : IJsonLibrary
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
        return "Not implemented";
    }

    public string Deserialize(Stopwatch timer)
    {
        string notes = string.Empty;
        
        timer.Start();
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);

        unsafe
        {
            fixed (byte* ptr = bytes)
            {
                // SimdJsonN -- N stands for Native, it means we are using Bindings for simdjson native lib
                // SimdJson -- fully managed .NET Core 3.0 port
                using (ParsedJsonN doc = SimdJsonN.ParseJson(ptr, bytes.Length))
                {
                    if (!doc.IsValid())
                    {
                        Console.WriteLine("Error: " + doc.GetErrorCode());
                        return String.Empty;
                    }
                    
                    //open iterator:
                    using (var iterator = new ParsedJsonIteratorN(doc))
                    {
                        jsonData.Read(iterator);
                    }
                }
            }
        }

        return notes;
    }
}
