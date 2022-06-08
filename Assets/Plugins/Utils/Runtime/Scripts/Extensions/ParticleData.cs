using UnityEngine;

namespace Extensions
{
    [System.Serializable]
    public struct ParticleData
    {
        [HideInInspector] public ParticleSystem effect;
        [HideInInspector, Min(0.0f)] public float lifeTime;

        public void Play()
        {
            if (!effect)
            {
                Debug.LogError("Particle effect has not been assigned");
                return;
            }

            effect.Play();
        }

        public void CreateAndPlay(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            if (!effect)
            {
                Debug.LogError("Particle effect has not been assigned");
                return;
            }

            ParticleSystem particle = Object.Instantiate(effect, position, rotation, parent);
            particle.Play();

            Object.Destroy(particle.gameObject, lifeTime);
        }
    }
}