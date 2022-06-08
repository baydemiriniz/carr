using System;
using UnityEngine;

namespace Extensions
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ReadOnlyAttribute : PropertyAttribute { }
}
