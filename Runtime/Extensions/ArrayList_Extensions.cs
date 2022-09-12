using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayList_Extensions
{
    public static bool Exist<T>(this ICollection<T> list) => list != null && list.Count > 0;
    public static bool InRange<T>(this ICollection<T> list, int id) => list != null && id >= 0 && id < list.Count;

  //  public static bool InRange<T>(this List<T> list, int id) => list != null && id >= 0 && id < list.Count;
  //
  //  public static bool InRange(this Array array, int id) => array != null && id >= 0 && id < array.Length;
}
