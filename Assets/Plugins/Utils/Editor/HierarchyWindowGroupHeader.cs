using Extensions;
using UnityEngine;
using UnityEditor;

namespace ExtensionsEditor
{
    [InitializeOnLoad]
    public static class HierarchyWindowGroupHeader
    {
        static HierarchyWindowGroupHeader()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (!gameObject)
                return;

            HeaderColorSelector colorSelector = gameObject.GetComponent<HeaderColorSelector>();
            if (!gameObject.name.StartsWith("---", System.StringComparison.Ordinal) && !colorSelector)
                return;

            EditorGUI.DrawRect(selectionRect, colorSelector ? colorSelector.headerColor : Color.gray);
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("-", "").ToUpperInvariant());
        }
    }
}