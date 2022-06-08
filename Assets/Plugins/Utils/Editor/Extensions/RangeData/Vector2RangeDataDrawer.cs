using Extensions;
using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
    [CustomPropertyDrawer(typeof(Vector2RangeData))]
    public class Vector2RangeDataDrawer : BaseRangeDataDrawer { }
}