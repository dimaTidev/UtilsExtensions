using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class StringExtensions
{

    public static bool IsContainKeys(this string value)
    {
        if (value != null && value.Length > 0)
        {
            int idEnd = value.LastIndexOf("]");
            int idStart = value.LastIndexOf("[");
            if (idStart < 0 || idEnd < 0)
                return false;
            else
                return true;
        }

        return false;
    }
    public static bool ExportKeys(this string value, out string line, out string[] outKeys) 
    {
        line = value;
        List<string> keys = new List<string>();
        int idEnd = -1;
        int idStart = -1;

        if (value != null && value.Length > 0)
        {
            idEnd = line.LastIndexOf("]");
            idStart = line.LastIndexOf("[");
        }

        if(idStart < 0 || idEnd < 0)
        {
            outKeys = keys.ToArray();
            return false;
        }   

        int recursive = 0;

        idStart = line.Length;

        while (line.LastIndexOf("]", idStart) > 0)
        {
            idEnd = line.LastIndexOf("]", idStart);
            idStart = line.LastIndexOf("[", idStart);

           // Debug.Log("idStart: " + idStart + "idEnd: " + idEnd);

            if (idStart == -1 || idEnd == -1 || idStart == idEnd)
                break;

            string key = line.Substring(idStart + 1, idEnd - idStart - 1);
            keys.Add(key);

            //line = line.Remove(idStart, idEnd - idStart+1);
            line = line.Replace($"[{key}]", $"{{{keys.Count - 1}}}");

            idStart--;

            if (idStart < 0)
                break;

            recursive++;
            if (recursive > 100)
            {
                Debug.Log("recursive!!!");
                break;
            }
        }
        outKeys = keys.ToArray();
        return true;
    }
}
