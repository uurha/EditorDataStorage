using System;
using System.Reflection;
using EditorDataStorage.Editor;
using Samples.Scripts;
using UnityEditor;
using UnityEngine;

namespace Samples.Editor.Scripts
{
    [CustomEditor(typeof(SampleController))]
    public class SampleControllerEditor : UnityEditor.Editor
    {
        private Color _someColorEditorField;
        private bool _someBoolEditorField;
        private float _someFloatEditorField;

        private void OnEnable()
        {
            EditorData.GetData(this, nameof(_someColorEditorField));

            EditorData.GetData(this, nameof(_someColorEditorField));

            EditorData.GetData(this, nameof(_someFloatEditorField));
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var bufferBool =
                EditorGUI.Toggle(EditorGUILayout.GetControlRect(), new GUIContent("Some Bool Editor Field"),
                                 _someBoolEditorField);

            if (!_someBoolEditorField.Equals(bufferBool))
            {
                _someBoolEditorField = bufferBool;
                EditorData.SetData(this, nameof(_someBoolEditorField));
            }
            if (!_someBoolEditorField) return;

            var bufferColor = EditorGUI.ColorField(EditorGUILayout.GetControlRect(),
                                                   new GUIContent("Some Color Editor Field"),
                                                   _someColorEditorField);

            if (!_someColorEditorField.Equals(bufferColor))
            {
                _someColorEditorField = bufferColor;
                EditorData.SetData(this, nameof(_someColorEditorField));
            }

            var bufferFloat = EditorGUI.Slider(EditorGUILayout.GetControlRect(),
                                               new GUIContent("Some Float Editor Field"),
                                               _someFloatEditorField, 0f, 1f);

            if (!_someFloatEditorField.Equals(bufferFloat))
            {
                _someFloatEditorField = bufferFloat;
                EditorData.SetData(this, nameof(_someFloatEditorField));
            }
        }
    }
}
