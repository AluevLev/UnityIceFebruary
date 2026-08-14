namespace UnityIceFebruary.HelpTools
{
    using System.ComponentModel;
    using UnityEditor;
    using UnityEngine;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class AnimatorNameToHashConverter : EditorWindow
    {
        private string _inputText;
        private int _calculatedHash;

        [MenuItem("Tools/Animator name to hash converter")]
        private static void ShowWindow()
        {
            AnimatorNameToHashConverter window = GetWindow<AnimatorNameToHashConverter>("Animator name to hash converter");
            window.minSize = new(300, 100);
        }
        private void OnGUI()
        {
            _inputText = EditorGUILayout.TextField("Field name:", _inputText);
            _calculatedHash = Animator.StringToHash(_inputText);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Result:", EditorStyles.boldLabel, GUILayout.Width(110));
            EditorGUILayout.SelectableLabel(_calculatedHash.ToString(), EditorStyles.textField, GUILayout.Height(18));
        }
    }
}
