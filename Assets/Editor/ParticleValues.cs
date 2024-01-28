using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(particleSystem.Particles))]
public class ParticleValues : UnityEditor.Editor
{
    private SerializedProperty particle;
    private SerializedProperty particleType;
    
    private SerializedProperty posX;
    private SerializedProperty limit;

    private SerializedProperty scale;
    private SerializedProperty minScale;
    private SerializedProperty maxScale;

    private SerializedProperty time;
    private SerializedProperty spawn;

    void OnEnable()
    {
        particle = serializedObject.FindProperty("particle");
        particleType = serializedObject.FindProperty("particleType");

        posX = serializedObject.FindProperty("posX");
        limit = serializedObject.FindProperty("limit");

        scale = serializedObject.FindProperty("scale");
        minScale = serializedObject.FindProperty("minScale");
        maxScale = serializedObject.FindProperty("maxScale");

        time = serializedObject.FindProperty("time");
        spawn = serializedObject.FindProperty("spawn");
    }

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        serializedObject.Update();

        EditorGUILayout.PropertyField(particle);
        EditorGUILayout.PropertyField(particleType);

        //Position
        EditorGUILayout.PropertyField(posX);
        EditorGUILayout.PropertyField(limit);

        particleSystem.Particles psp = (particleSystem.Particles)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Set Min Pos")) 
        {
            psp.SetMinPos();
        }
        if (GUILayout.Button("Set Max Pos")) 
        {
            psp.SetMaxPos();
        }
        GUILayout.EndHorizontal();

        //Scale
        particleSystem.Particles.Type selectedMode = (particleSystem.Particles.Type)particleType.enumValueIndex;

        if (selectedMode == particleSystem.Particles.Type.Background)
        {
            EditorGUILayout.PropertyField(scale);
        }

        if (selectedMode == particleSystem.Particles.Type.Player)
        {
            EditorGUILayout.PropertyField(minScale);
            EditorGUILayout.PropertyField(maxScale);
        }

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Set Min Scale")) 
        {
            psp.SetMinScale();
        }
        if (GUILayout.Button("Set Max Scale")) 
        {
            psp.SetMaxScale();
        }
        GUILayout.EndHorizontal();



        EditorGUILayout.PropertyField(time);
        EditorGUILayout.PropertyField(spawn);

        serializedObject.ApplyModifiedProperties();
    }
}
