using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util_array
{

    public static void ResizeArray_ofGameObject(ref List<GameObject> list, int count, GameObject prefab, Transform parent = null)
    {
        if (prefab == null)
            return;

        if (list == null) list = new List<GameObject>();

        int reminded = count - list.Count;
        if (reminded > 0)
        {
            for (int i = 0; i < reminded; i++)
                list.Add(MonoBehaviour.Instantiate(prefab, parent));
        }
        reminded = 0;
        for (int i = 0; i < count; i++)
        {
            list[i].transform.SetSiblingIndex(i);
            if (!list[i].gameObject.activeSelf) list[i].gameObject.SetActive(true);
            reminded++;
        }

        if (list.Count > reminded)
        {
            for (int i = reminded; i < list.Count; i++)
                list[i].gameObject.SetActive(false);
        }
    }

    public static void ResizeArray_ofMonoBehaviour<T>(ref List<T> list, int count, GameObject prefab, Transform parent = null) where T : MonoBehaviour
    {
        if (prefab == null)
            return;

        if (list == null) list = new List<T>();

        int reminded = count - list.Count;
        if (reminded > 0)
        {
            for (int i = 0; i < reminded; i++)
                list.Add(MonoBehaviour.Instantiate(prefab, parent).GetComponent<T>());
        }
        reminded = 0;
        for (int i = 0; i < count; i++)
        {
            list[i].transform.SetSiblingIndex(i);
            if (!list[i].gameObject.activeSelf) list[i].gameObject.SetActive(true);
            reminded++;
        }

        if (list.Count > reminded)
        {
            for (int i = reminded; i < list.Count; i++)
                list[i].gameObject.SetActive(false);
        }
    }
}
