using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public static class UtilsEditor
{
    //[MenuItem("GameObject/UI/Extensions/NonDrawingGraphic")]
    public static void CreateCustomGameObject<T>(MenuCommand menuCommand) where T: MonoBehaviour
    {
        GameObject go = new GameObject(typeof(T).Name);
        go.AddComponent<T>();
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

  
    public static void OnGUI_DrawDictionary<T, K>(
       ref Dictionary<T, K> dictionary, string label, ref bool foldout, bool isCanDelete = false,
       Action<Dictionary<T, K>, T> callbackButtonAction = null, Action<Dictionary<T, K>, T> callbackButtonAction2 = null, 
       string labelButt0 = "0", string labelButt1 = "1")
    {
        if (dictionary == null || dictionary.Count == 0)
        {
            EditorGUILayout.LabelField("dictionary is Null or zero");
            return;
        }

        foldout = EditorGUILayout.Foldout(foldout, label);
        if (!foldout)
            return;

        List<T> key_forDelete = new List<T>();

        EditorGUILayout.BeginVertical("Helpbox");
        foreach (var item in dictionary)
        {
            EditorGUILayout.BeginHorizontal();
            if (isCanDelete)
            {
                GUI.color = Color.red;
                if (GUILayout.Button("x", GUILayout.Width(20))) //delete
                    key_forDelete.Add(item.Key);
            }
            
            GUI.color = Color.white;
            if(callbackButtonAction != null)
            {
                GUI.color = Color.white;
                if (GUILayout.Button(labelButt0, GUILayout.Width(35)))
                    callbackButtonAction?.Invoke(dictionary, item.Key);
            }
            GUI.color = Color.white;
            if (callbackButtonAction2 != null)
            {
                GUI.color = Color.white;
                if (GUILayout.Button(labelButt1, GUILayout.Width(35)))
                    callbackButtonAction2?.Invoke(dictionary, item.Key);
            }

            GUI.color = Color.white;

            EditorGUILayout.LabelField(item.Key.ToString(), GUILayout.ExpandWidth(false));
            EditorGUILayout.LabelField(item.Value.ToString());
            EditorGUILayout.EndHorizontal();
        }

        foreach (var item in key_forDelete)
            dictionary.Remove(item);

        EditorGUILayout.EndVertical();
    }
}
