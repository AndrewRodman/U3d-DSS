using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(TreeData))]
public class TreeDataEditor : Editor
{
    float c;
    float s;
    float a;

    public override void OnInspectorGUI()
    {
        TreeData script = (TreeData)target;


        script.Name = EditorGUILayout.TextField(new GUIContent("Name"), script.Name);
        c = EditorGUILayout.FloatField(new GUIContent("Carbon"), script.GetParam(TreeData.CARBON));
        s = EditorGUILayout.FloatField(new GUIContent("Stormwater"), script.GetParam(TreeData.STORMWATER));
        a = EditorGUILayout.FloatField(new GUIContent("Stormwater Savings"), script.GetParam(TreeData.STORMSAVINGS));
        script.SetParameter(new float[3] { c, s, a });

        SerializedProperty tps = serializedObject.FindProperty("Trees");
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(tps, true);
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        


       
        
    }
}

