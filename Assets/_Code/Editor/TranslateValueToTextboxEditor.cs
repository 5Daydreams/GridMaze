using _Code.Toolbox;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(FloatTextboxObserver))]
    public class FloatTextboxObserverEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            FloatTextboxObserver translator = (FloatTextboxObserver) target;
        
            GUILayout.Label("Base Inspector", EditorStyles.boldLabel);
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
                base.OnInspectorGUI();
        
            GUILayout.Label("Custom Add-ons", EditorStyles.boldLabel);
            if (GUILayout.Button("Translate to time"))
            {
                translator.TranslateValueToTime();
            }
        }
    }
}