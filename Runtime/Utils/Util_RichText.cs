using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util_RichText : MonoBehaviour
{
    public static string Color(string text, Color color) => $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>";
    public static string Size(string text, int size) => $"<size={size}>{text}</size>";
    public static string Bold(string text) => $"<b>{text}</b>";
    public static string Italic(string text) => $"<i>{text}</i>";

    /// <summary>
    /// A/a
    /// </summary>
    public static string CountFrom(string countA, string countB, int size) => CountFrom(countA, countB, size);
    /// <summary>
    /// A/a
    /// </summary>
    public static string CountFrom(string countA, string countB, int size, Color col) => Size(countA, size) + Color(Size("/" + countB, size / 2), col / 2);
}
