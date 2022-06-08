using Extensions;
using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
	[CustomPropertyDrawer(typeof(DetailedVector3Attribute))]
	public class DetailedVector3Drawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			GUI.Box(position, string.Empty, GUI.skin.window);

			Rect effectRect = new Rect(position.x, position.y + 8,
				position.width - 18, 18);

			EditorGUI.indentLevel++;
			EditorGUI.PropertyField(effectRect, property, label);

			Vector3 value = property.vector3Value;
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
