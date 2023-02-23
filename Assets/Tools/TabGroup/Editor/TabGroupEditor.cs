using System;
using UnityEditor;

namespace TabGroup
{
    [CustomEditor(typeof(TabGroup))]
    public class TabGroupEditor : Editor
    {
        #region SerializedProperty

        private SerializedProperty _tabButtons;
        private SerializedProperty _groupMode;
        private SerializedProperty _colorIdle;
        private SerializedProperty _colorHover;
        private SerializedProperty _colorActive;
        private SerializedProperty _tabIdle;
        private SerializedProperty _tabHover;
        private SerializedProperty _tabActive;
        private SerializedProperty _objectsToSwap;

        #endregion

        private void OnEnable()
        {
            _tabButtons = serializedObject.FindProperty("tabButtons");
            _groupMode = serializedObject.FindProperty("groupMode");
            _colorIdle = serializedObject.FindProperty("colorIdle");
            _colorHover = serializedObject.FindProperty("colorHover");
            _colorActive = serializedObject.FindProperty("colorActive");
            _tabIdle = serializedObject.FindProperty("tabIdle");
            _tabHover = serializedObject.FindProperty("tabHover");
            _tabActive = serializedObject.FindProperty("tabActive");
            _objectsToSwap = serializedObject.FindProperty("objectsToSwap");
        }

        public override void OnInspectorGUI()
        {
            var tabGroup = (TabGroup)target;

            serializedObject.Update();

            EditorGUILayout.PropertyField(_tabButtons);
            EditorGUILayout.PropertyField(_groupMode);
            switch (tabGroup.Mode)
            {
                case TabGroupMode.Color:
                    EditorGUILayout.PropertyField(_colorIdle);
                    EditorGUILayout.PropertyField(_colorHover);
                    EditorGUILayout.PropertyField(_colorActive);
                    break;
                case TabGroupMode.Image:
                    EditorGUILayout.PropertyField(_tabIdle);
                    EditorGUILayout.PropertyField(_tabHover);
                    EditorGUILayout.PropertyField(_tabActive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            EditorGUILayout.PropertyField(_objectsToSwap);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
