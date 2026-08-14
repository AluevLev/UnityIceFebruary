namespace UnityIceFebruary.HelpTools
{
    using IceFebruary.Space;
    using System.ComponentModel;
    using UnityEditor;
    using UnityEngine;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class AngleToRotorConverter : EditorWindow
    {
        private float _inputAngle;
        private Rotor2 _carculatedRotor;

        [MenuItem("Tools/Angle to rotor converter")]
        private static void ShowWindow()
        {
            AngleToRotorConverter window = GetWindow<AngleToRotorConverter>("Angle to rotor converter");
            window.minSize = new(300, 150);
        }
        private void OnGUI()
        {
            _inputAngle = EditorGUILayout.FloatField("Angle:", _inputAngle);
            _carculatedRotor = new(_inputAngle, false);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Result:", EditorStyles.boldLabel, GUILayout.Width(110));
            EditorGUILayout.SelectableLabel($"Scalar: {_carculatedRotor.Scalar}", EditorStyles.textField, GUILayout.Height(18));
            EditorGUILayout.SelectableLabel($"XY: {_carculatedRotor.XY}", EditorStyles.textField, GUILayout.Height(18));
        }
    }
}
