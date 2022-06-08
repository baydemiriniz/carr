using UnityEngine;

namespace Extensions
{
    [System.Serializable]
    public class Vector3RangeData : BaseRangeData<Vector3>
    {
        public override Vector3 Get(float time) => Vector3.Lerp(min, max, time);

        public override Vector3 Get()
        {
            Vector3 randomVec = new Vector3
            {
                x = Random.Range(min.x, max.x),
                y = Random.Range(min.y, max.y),
                z = Random.Range(min.z, max.z)
            };

            return randomVec;
        }

        public override Vector3 Clamp(Vector3 val)
        {
            Vector3 clampedVec = new Vector3
            {
                x = Mathf.Clamp(val.x, min.x, max.x),
                y = Mathf.Clamp(val.y, min.y, max.y),
                z = Mathf.Clamp(val.z, min.z, max.z)
            };

            return clampedVec;
        }

        public override void Clamp(ref Vector3 val)
        {
            val.x = Mathf.Clamp(val.x, min.x, max.x);
            val.y = Mathf.Clamp(val.y, min.y, max.y);
            val.z = Mathf.Clamp(val.z, min.z, max.z);
        }
    }
}