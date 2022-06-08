using Extensions;
using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
    [CustomPropertyDrawer(typeof(ColoredPropertyAttribute))]
    public class ColoredPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty prop, GUIContent label)
        {
            ColoredPropertyAttribute colored = (ColoredPropertyAttribute) attribute;
            if (colored == null)
                return;

            Color beforeColor = colored.isBackground ? GUI.backgroundColor : GUI.color;

            if (colored.isBackground )
                GUI.backgroundColor = new Color(colored.r, colored.g, colored.b, 1.0f);    
            else
                GUI.color = new Color(colored.r, colored.g, colored.b, 1.0f);
            
            EditorGUI.BeginProperty(rect, label, prop);
            EditorGUI.PropertyField(rect, prop);
            EditorGUI.EndProperty();

            if (colored.isBackground)
                GUI.backgroundColor = beforeColor;
            else
                GUI.color = beforeColor;
        }
    }
}