using Extensions;
using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
    [CustomPropertyDrawer(typeof(Vector3RangeData))]
    public class Vector3RangeDataDrawer : BaseRangeDataDrawer { }
}