using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util_Debug
{
    public static void Log_StringFromList<T>(List<T> list, string prefix = "")// where T :
    {
        string deb = StringFromList(list);
        Debug.Log(prefix + ": " + deb);
    }

    public static string StringFromList<T>(List<T> list)// where T :
    {
        string deb = "";

        for (int i = 0; i < list.Count; i++)
            deb += list[i] + "/";

        return deb;
    }

    public static string StringFromArray<T>(T[] list)// where T :
    {
        string deb = "";

        for (int i = 0; i < list.Length; i++)
            deb += list[i] + "/";

        return deb;
    }

    public static string StringFromHashSet<T>(HashSet<T> hSet)// where T :
    {
        string deb = "";
        foreach (var item in hSet)
            deb += item.ToString() + "/";

        return deb;
    }


    public static string Get_FullPath_Hierarhy(GameObject go)
    {
        if (go == null)
        {
            Debug.LogWarning("No set argument in method: Get_FullPath_Hierarhy!!!");
            return "";
        }
           

        string deb = go.name;

        Transform target = go.transform;

        while (target.parent)
        {
            deb = target.parent.name + "/" + deb;
            target = target.parent;
        }

        deb = "rootScene/" + deb;

        return deb;
    }
}
