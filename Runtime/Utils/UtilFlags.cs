//Info reference https://stackoverflow.com/questions/3261451/using-a-bitmask-in-c-sharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilFlags
{
   // [Flags]
   // public enum Names
   // {
   //     None = 0,
   //     Susan = 1,
   //     Bob = 2,
   //     Karen = 4
   // }

    public static bool IsSet<T>(T flags, T flag) where T : struct
    {
        int flagsValue = (int)(object)flags;
        int flagValue = (int)(object)flag;

        return (flagsValue & flagValue) != 0;
    }

    public static void Set<T>(ref T flags, T flag) where T : struct
    {
        int flagsValue = (int)(object)flags;
        int flagValue = (int)(object)flag;

        flags = (T)(object)(flagsValue | flagValue);
    }
  
    public static void Unset<T>(ref T flags, T flag) where T : struct
    {
        int flagsValue = (int)(object)flags;
        int flagValue = (int)(object)flag;

        flags = (T)(object)(flagsValue & (~flagValue));
    }

    /// <summary>
    ///Do a opposite action (bool isTrue = !isTrue)
    /// </summary>
    public static bool NegativeSet<T>(ref T flags, T flag) where T : struct
    {
        if (IsSet(flags, flag))
        {
            Unset(ref flags, flag);
            return false;
        }
        else
        {
            Set(ref flags, flag);
            return true;
        }    
    }

}
