using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Log
{
    public static void Collection<T>(ICollection<T> list, string prefix = "Collection debug") where T : IConvertible
    {
        string deb = "";
        foreach (var item in list)
            deb += item.ToString() + "\n";

        Debug.Log(prefix + ": " + deb);
    }
}
