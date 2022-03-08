using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonListWrapper<T>
{
    public List<T> list;
    public JsonListWrapper(List<T> list) => this.list = list;
}

[System.Serializable]
public class JsonArrayWrapper<T>
{
    public T[] array;
    public JsonArrayWrapper(T[] array) => this.array = array;
}
