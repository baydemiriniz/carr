using System;
using UnityEditor;
using UnityEngine;

namespace Project
{
    [CustomPropertyDrawer(typeof(BoxHeaderAttribute))]
    public class BoxAttributeEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, prop);
            GUI.Box(position, string.Empty, GUI.skin.window);
            EditorGUI.indentLevel++;
            position.y += EditorGUIUtility.singleLineHeight * 0.5f;
            position.width -= EditorGUIUtility.singleLineHeight * 0.5f;
            EditorGUI.PropertyField(position, prop);
            EditorGUI.indentLevel--;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight +base.GetPropertyHeight(property, label);
        }
    }
}