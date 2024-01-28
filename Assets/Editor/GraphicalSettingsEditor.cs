using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(KillMenuSystem.GraphicalSettings))]
public class GraphicalSettingsEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        KillMenuSystem.GraphicalSettings kmsgs = (KillMenuSystem.GraphicalSettings)target;

        /*GUILayout.BeginHorizontal();
        if (GUILayout.Button("Lower Graphics")) 
        {
            kmsgs.LowerGraphicsButton();
        }
        if (GUILayout.Button("Upper Graphics")) 
        {
            kmsgs.UpperGraphicsButton();
        }
        GUILayout.EndHorizontal();*/

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Lower Default")) 
        {
            kmsgs.LowerDefaultEditor();
        }
        if (GUILayout.Button("Upper Default")) 
        {
            kmsgs.UpperDefaultEditor();
        }
        GUILayout.EndHorizontal();
    }
}
