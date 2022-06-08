using Extensions;
using UnityEditor;
using UnityEngine;

namespace ExtensionsEditor
{
    [CustomPropertyDrawer(typeof(FloatRangeData))]
    public class FloatRangeDataDrawer : BaseRangeDataDrawer { }
}