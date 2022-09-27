
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioEvent), true)]
public class AudioEventEditor : Editor
{
    [SerializeField]
    private AudioSource _previewer;

    public void OnEnable()
    {
        _previewer = EditorUtility.CreateGameObjectWithHideFlags(
            "Audio preview",
            HideFlags.HideAndDontSave,
            typeof(AudioSource)).GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        DestroyImmediate(_previewer.gameObject);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("Preview"))
        {
            ((AudioEvent)target).Play(_previewer);
        }
        if (GUILayout.Button("LHurt"))
        {
            ((SimpleAudioEvent)target).LPlayHurt(_previewer);
        }
        if (GUILayout.Button("LLaught"))
        {
            ((SimpleAudioEvent)target).LPlayLaught(_previewer);
        }
        if (GUILayout.Button("VHurt"))
        {
            ((SimpleAudioEvent)target).VPlayHurt(_previewer);
        }
        if (GUILayout.Button("VLaught"))
        {
            ((SimpleAudioEvent)target).VPlayLaught(_previewer);
        }
        EditorGUI.EndDisabledGroup();
    }

}
