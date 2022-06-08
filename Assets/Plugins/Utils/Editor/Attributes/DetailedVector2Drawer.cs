using Extensions;
using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
    [CustomPropertyDrawer(typeof(DetailedVector2Attribute))]
    public class DetailedVector2Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            GUI.Box(position, string.Empty, GUI.skin.window);

            Rect effectRect = new Rect(position.x, position.y + 8,
                position.width - 18, 18);

            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(effectRect, property, label);

            Vector2 value = property.vector2Value;
            Rect magnitudeRect = new Rect(position.x, position.y + 26,
                position.width - 18, 18);

            EditorGUI.LabelField(magnitudeRect, "Magnitude: ",$"{value.magnitude}", EditorStyles.boldLabel);
            EditorGUI.indentLevel--;

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 3.0f;
        }
    }
}