using System.Collections;
using System.Collections.Generic;
using Benchmarking.Logging;
using UnityEngine;
using CodeTitans.JSon;

[System.Serializable]
public partial class Holder : ICrap
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
}
