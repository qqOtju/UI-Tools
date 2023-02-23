using System;
using UnityEditor;
using UnityEngine;

namespace FlexibleGridLayout
{
    [CustomEditor(typeof(FlexibleGridLayout))]
    public class FlexibleGridLayoutEditor : Editor
    {
        #region SerializedProperty

        private SerializedProperty _childAlignment;
        private SerializedProperty _padding;
        private SerializedProperty _fitType;
        private SerializedProperty _spacing;
        private SerializedProperty _columns;
        private SerializedProperty _rows;

        #endregion

        private bool _cellSizeGroup = false;
        
        private void OnEnable()
        {
            _childAlignment = serializedObject.FindProperty("m_ChildAlignment");
            _padding = serializedObject.FindProperty("m_Padding");
            _fitType = serializedObject.FindProperty("fitType");
            _spacing = serializedObject.FindProperty("spacing");
            _columns = serializedObject.FindProperty("columns");
            _rows = serializedObject.FindProperty("rows");
        }

        public override void OnInspectorGUI()
        {
            var layout = (FlexibleGridLayout)target;
            
            serializedObject.Update();

            EditorGUILayout.PropertyField(_childAlignment);
            EditorGUILayout.PropertyField(_padding);
            EditorGUILayout.PropertyField(_fitType);
            EditorGUILayout.PropertyField(_spacing);

            switch (layout.FitType)
            {
                case FitType.FixedColumns:
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Rows: ");
                    EditorGUILayout.LabelField($"{layout.Rows}");
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.PropertyField(_columns);
                    break;
                case FitType.FixedRows:
                    EditorGUILayout.PropertyField(_rows);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Columns: ");
                    EditorGUILayout.LabelField($"{layout.Columns}");
                    EditorGUILayout.EndHorizontal();
                    break;
                case FitType.Uniform:
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Rows: ");
                    EditorGUILayout.LabelField($"{layout.Rows}");
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Columns: ");
                    EditorGUILayout.LabelField($"{layout.Columns}");
                    EditorGUILayout.EndHorizontal();
                    break;
                case FitType.Width:
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Rows: ");
                    EditorGUILayout.LabelField($"{layout.Rows}");
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Columns: ");
                    EditorGUILayout.LabelField($"{layout.Columns}");
                    EditorGUILayout.EndHorizontal();
                    break;
                case FitType.Height:
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Rows: ");
                    EditorGUILayout.LabelField($"{layout.Rows}");
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Columns: ");
                    EditorGUILayout.LabelField($"{layout.Columns}");
                    EditorGUILayout.EndHorizontal();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _cellSizeGroup = EditorGUILayout.BeginFoldoutHeaderGroup(_cellSizeGroup,"Cell Size");
            if(_cellSizeGroup)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Y");
                EditorGUILayout.LabelField($"{layout.CellSize.y}");
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("X");
                EditorGUILayout.LabelField($"{layout.CellSize.x}");
                EditorGUILayout.EndHorizontal();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}