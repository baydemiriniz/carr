using UnityEngine;

namespace Extensions
{
	[System.Serializable]
	public class Vector2RangeData : BaseRangeData<Vector2>
	{
		public override Vector2 Get(float time) => 
			Vector2.Lerp(min, max, time);

		public override Vector2 Get()
		{
			Vector2 randomVec = new Vector2
			{
				x = Random.Range(min.x, max.x),
				y = Random.Range(min.y, max.y)
			};

			return randomVec;
		}

		public override Vector2 Clamp(Vector2 val)
		{
			Vector2 clampedVec = new Vector2
			{
				x = Mathf.Clamp(val.x, min.x, max.x),
				y = Mathf.Clamp(val.y, min.y, max.y)
			};

			return clampedVec;
		}

		public override void Clamp(ref Vector2 val)
		{
			val.x = Mathf.Clamp(val.x, min.x, max.x);
			val.y = Mathf.Clamp(val.y, min.y, max.y);
		}
	}
}
