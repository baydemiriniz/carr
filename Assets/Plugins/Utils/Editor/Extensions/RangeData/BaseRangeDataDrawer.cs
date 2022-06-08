using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
    public class BaseRangeDataDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            GUI.Box(position, label, GUI.skin.window);

            Rect minRect = new Rect(position.x, position.y + 24,
                position.width - 18, 18);

            Rect maxRect = new Rect(position.x, position.y + 48,
                position.width - 18, 18);

            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(minRect, property.FindPropertyRelative("min"), new GUIContent("Min: "));
            EditorGUI.PropertyField(maxRect, property.FindPropertyRelative("max"), new GUIContent("Max: "));

            EditorGUI.indentLevel--;

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 4.0f;
        }
    }
}