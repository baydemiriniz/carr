using UnityEngine;

namespace Extensions
{
	public class HeaderColorSelector : MonoBehaviour
	{
#if UNITY_EDITOR
		public Color headerColor = Color.gray;
#endif
	}
}
