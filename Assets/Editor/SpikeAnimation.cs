using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterSystem.Spikes))]
public class SpikeAnimation : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        if (Application.isPlaying)
        {
            CharacterSystem.Spikes css = (CharacterSystem.Spikes)target;

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

            if (!CharacterSystem.CharacterController.appeared)
            {
                if (GUILayout.Button("Appear")) 
                {
                    css.ButtonSpike();
                }
            }

            else
            {
                if (GUILayout.Button("Disappear")) 
                {
                    css.ButtonSpike();
                }
            }
        }

        else
        {
            DrawDefaultInspector();
        }
    }
}
