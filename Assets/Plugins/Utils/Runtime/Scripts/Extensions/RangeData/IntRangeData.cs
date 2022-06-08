using UnityEngine;

namespace Extensions
{
	[System.Serializable]
	public class IntRangeData : BaseRangeData<int>
	{
		public override int Get(float lerpTime) =>
			(int)Mathf.Lerp(min, max, lerpTime);

		public override int Get() => 
			Random.Range(min, max);

		public override int Clamp(int val) => 
			Mathf.Clamp(val, min, max);

		public override void Clamp(ref int val) => 
			val = Mathf.Clamp(val, min, max);
	}
}
