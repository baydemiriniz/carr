using UnityEngine;

namespace Extensions
{
    [System.Serializable]
    public class FloatRangeData : BaseRangeData<float>
    {
       public override float Get(float lerpTime) => 
           Mathf.Lerp(min, max, lerpTime);

       public override float Get() => 
           Random.Range(min, max);

       public override float Clamp(float val) => 
           Mathf.Clamp(val, min, max);

       public override void Clamp(ref float val) => 
           val = Mathf.Clamp(val, min, max);
    }
}