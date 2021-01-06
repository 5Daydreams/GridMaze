using System.Collections;
using System.Collections.Generic;
using _Code.MainCode;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MazeGenerator))]
public class MazeGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MazeGenerator mazeGenerator = (MazeGenerator) target;
        
        GUILayout.Label("Base Inspector", EditorStyles.boldLabel);
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            base.OnInspectorGUI();
        
        GUILayout.Label("Custom Add-ons", EditorStyles.boldLabel);
        if (GUILayout.Button("Generate new maze"))
        {
            mazeGenerator.NewMaze();
        }
    }
}