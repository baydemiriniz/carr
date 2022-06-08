using Extensions;
using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
    [CustomPropertyDrawer(typeof(ParticleData))]
    public class ParticleDataPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            GUI.Box(position, label, GUI.skin.window);

            Rect effectRect = new Rect(position.x, position.y + 24,
                position.width - 18, 18);

            Rect lifeTimeRect = new Rect(position.x, position.y + 48,
                position.width - 18, 18);

            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(effectRect, property.FindPropertyRelative("effect"), new GUIContent("Effect: "));

            EditorGUI.PropertyField(lifeTimeRect,
                property.FindPropertyRelative("lifeTime"),
                new GUIContent("Life Time: "));

            EditorGUI.indentLevel--;

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 4.0f;
        }
    }
}