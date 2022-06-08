using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Extensions
{
    public static class VisibilityExtensions
    {
        public static void Show(this GameObject go) => go.SetActive(true);
        public static void Hide(this GameObject go) => go.SetActive(false);

        public static void Show(this Component cp) => cp.gameObject.SetActive(true);
        public static void Hide(this Component cp) => cp.gameObject.SetActive(false);

        public static void Enable(this Graphic gr) => gr.enabled = true;
        public static void Disable(this Graphic gr) => gr.enabled = false;
    }
    
    public static class SkinnedMeshRendererExtensions
    {
        /// <summary>
        /// Gets blend shape index of the blendShapeName parameter 
        /// </summary>
        public static void GetBlendShapeIndex(this SkinnedMeshRenderer skinnedMeshRenderer, string blendShapeName,
            out int blendShapeIndex)
        {
            Mesh mesh = skinnedMeshRenderer.sharedMesh;
            int count = mesh.blendShapeCount;
            for (int i = 0; i < count; i++)
            {
                if (!mesh.GetBlendShapeName(i).Equals(blendShapeName))
                {
                    continue;
                }

                blendShapeIndex = i;
                return;
            }

            blendShapeIndex = -1;
        }

        /// <summary>
        /// Sets the blend shape weight of blendShapeIndex parameter
        /// </summary>
        public static void SetBlendShapeWeight(this SkinnedMeshRenderer skinnedMeshRenderer, int blendShapeIndex,
            float blendShapeWeight)
        {
            if (!skinnedMeshRenderer
                || blendShapeIndex >= skinnedMeshRenderer.sharedMesh.blendShapeCount
                || blendShapeIndex < 0)
            {
                return;
            }

            blendShapeWeight = Mathf.Clamp(blendShapeWeight, 0.0f, 100.0f);
            skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeWeight);
        }

        /// <summary>
        /// Sets the blend shape weight of blendShapeName parameter
        /// </summary>
        public static void SetBlendShapeWeight(this SkinnedMeshRenderer skinnedMeshRenderer, string blendShapeName,
            float blendShapeWeight)
        {
            skinnedMeshRenderer.GetBlendShapeIndex(blendShapeName, out int blendShapeIndex);
            if (!skinnedMeshRenderer
                || blendShapeIndex >= skinnedMeshRenderer.sharedMesh.blendShapeCount
                || blendShapeIndex < 0)
            {
                return;
            }

            skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeWeight);
        }

        /// <summary>
        /// Returns the blend shape wight of blendShapeIndex
        /// </summary>
        public static float GetBlendShapeWeight(this SkinnedMeshRenderer skinnedMeshRenderer, int blendShapeIndex)
        {
            if (!skinnedMeshRenderer
                || blendShapeIndex >= skinnedMeshRenderer.sharedMesh.blendShapeCount
                || blendShapeIndex < 0)
            {
                return 0.0f;
            }

            return skinnedMeshRenderer.GetBlendShapeWeight(blendShapeIndex);
        }

        /// <summary>
        /// Returns the blend shape weight of blendShapeName parameter
        /// </summary>
        public static float GetBlendShapeWeight(this SkinnedMeshRenderer skinnedMeshRenderer, string blendShapeName)
        {
            skinnedMeshRenderer.GetBlendShapeIndex(blendShapeName, out int blendShapeIndex);
            if (!skinnedMeshRenderer
                || blendShapeIndex >= skinnedMeshRenderer.sharedMesh.blendShapeCount
                || blendShapeIndex < 0)
            {
                return 0.0f;
            }

            return skinnedMeshRenderer.GetBlendShapeWeight(blendShapeIndex);
        }
    }

    public static class RendererExtensions
    {
        #region 3D Renderer Common Features

        private static readonly int ColorProperty = Shader.PropertyToID("_Color");
        private static readonly int BaseColorProperty = Shader.PropertyToID("_BaseColor");

        /// <summary>
        /// Sets materials color;
        ///     if material's shader has _BaseColor property set it to _BaseColor property
        ///     if doesn't sets it to _Color property
        /// </summary>
        public static void SetColor(this Material material, Color color)
        {
            if (material.HasProperty(BaseColorProperty))
            {
                material.SetColor(BaseColorProperty, color);
                return;
            }

            material.SetColor(ColorProperty, color);
        }

        /// <summary>
        /// Sets materials color if material's shader has property
        /// </summary>
        public static void SetColor(this Material material, string shaderProp, Color color)
        {
            if (material.HasProperty(shaderProp))
            {
                material.SetColor(shaderProp, color);
            }
        }

        /// <summary>
        /// Sets materials color if material's shader has property
        /// </summary>
        public static void SetColor(this Material material, int shaderProp, Color color)
        {
            if (material.HasProperty(shaderProp))
            {
                material.SetColor(shaderProp, color);
            }
        }

        /// <summary>
        /// Changes Renderers material according to parameters 
        /// </summary>
        public static Renderer ChangeMaterial(this Renderer renderer, Material material, int materialIndex = 0)
        {
            Material[] materials = renderer.materials;
            if (materialIndex < materials.Length)
            {
                materials[materialIndex] = material;
            }
            else
            {
                Debug.LogError($"Renderer doesn't have a material at {materialIndex}");
            }

            renderer.materials = materials;

            return renderer;
        }

        #endregion 3D Renderer Common Features
    }

    public static class PositionExtensions
    {
        #region Object Local Position

        public static void SetLocalPosition(this Component component, Vector3 newLocalPosition) =>
            component.transform.localPosition = newLocalPosition;

        public static void SetLocalPosition(this Component component, Vector2 newLocalPosition) =>
            component.transform.localPosition = newLocalPosition;

        public static void SetLocalPosition(this Component component, float? x = null, float? y = null, float? z = null)
        {
            Transform transform = component.transform;
            Vector3 newLocalPosition = transform.localPosition;
            newLocalPosition.x = x ?? newLocalPosition.x;
            newLocalPosition.y = y ?? newLocalPosition.y;
            newLocalPosition.z = z ?? newLocalPosition.z;
            transform.localPosition = newLocalPosition;
        }

        #endregion Object Local Position

        #region Object World Position

        public static void SetPosition(this Component component, Vector3 newLocalPosition) =>
            component.transform.position = newLocalPosition;

        public static void SetPosition(this Component component, Vector2 newLocalPosition) =>
            component.transform.position = newLocalPosition;

        public static void SetPosition(this Component component, float? x = null, float? y = null, float? z = null)
        {
            Transform transform = component.transform;
            Vector3 newLocalPosition = transform.position;
            newLocalPosition.x = x ?? newLocalPosition.x;
            newLocalPosition.y = y ?? newLocalPosition.y;
            newLocalPosition.z = z ?? newLocalPosition.z;
            transform.position = newLocalPosition;
        }

        #endregion Object World Position
    }

    public static class RotationExtensions
    {
        #region Object Local Rotation

        public static void SetLocalRotation(this Component component, Quaternion newLocalRotation) =>
            component.transform.localRotation = newLocalRotation;

        public static void SetLocalRotation(this Component component, Vector3 newLocalRotation) =>
            component.transform.localRotation = Quaternion.Euler(newLocalRotation);

        #endregion Object Local Rotation

        #region Object World Rotation

        public static void SetRotation(this Component component, Quaternion newLocalRotation) =>
            component.transform.rotation = newLocalRotation;

        public static void SetRotation(this Component component, Vector3 newLocalRotation) =>
            component.transform.rotation = Quaternion.Euler(newLocalRotation);

        #endregion Object World Rotation

        #region Object World EulerAngles

        public static void SetEulerAngles(this Component component, float? x = null, float? y = null, float? z = null)
        {
            Transform transform = component.transform;
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = x ?? eulerAngles.x;
            eulerAngles.y = y ?? eulerAngles.y;
            eulerAngles.z = z ?? eulerAngles.z;
            transform.eulerAngles = eulerAngles;
        }

        public static void SetEulerAngles(this Component component, Vector3 eulerAngles) =>
            component.transform.eulerAngles = eulerAngles;

        #endregion Object World EulerAngles

        #region Object Local EulerAngles

        public static void SetLocalEulerAngles(this Component component, float? x = null, float? y = null,
            float? z = null)
        {
            Transform transform = component.transform;
            Vector3 eulerAngles = transform.localEulerAngles;
            eulerAngles.x = x ?? eulerAngles.x;
            eulerAngles.y = y ?? eulerAngles.y;
            eulerAngles.z = z ?? eulerAngles.z;
            transform.localEulerAngles = eulerAngles;
        }

        public static void SetLocalEulerAngles(this Component component, Vector3 eulerAngles) =>
            component.transform.localEulerAngles = eulerAngles;

        #endregion Object Local EulerAngles
    }

    public static class ListExtensions
    {
        #region List

        public static void Shuffle<T>(this IList<T> ts)
        {
            int count = ts.Count;
            int last = count - 1;
            for (int i = 0; i < last; ++i)
            {
                int r = Random.Range(i, count);
                T tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }

        public static T GetRandom<T>(this IList<T> ts, T defaultVal)
        {
            int count = ts.Count;

            return count == 0 ? default : ts[Random.Range(0, count)];
        }

        #endregion
    }

    public static class ParticleSystemExtensions
    {
        public static void SafePlay(this ParticleSystem particleSystem, bool includeChildren = true)
        {
            if (!particleSystem)
            {
                Debug.Log("Particle has not been assigned");
                return;
            }

            particleSystem.Play(includeChildren);
        }

        public static void SafeStop(this ParticleSystem particleSystem)
        {
            if (!particleSystem)
            {
                Debug.Log("Particle has not been assigned");
                return;
            }

            particleSystem.Stop();
        }


        public static void SafeStop(this ParticleSystem particleSystem, bool withChildren,
            ParticleSystemStopBehavior stopBehavior)
        {
            if (!particleSystem)
            {
                Debug.Log("Particle has not been assigned");
                return;
            }

            particleSystem.Stop(withChildren, stopBehavior);
        }
    }

    public static class AnimatorExtensions
    {
        public static void SafePlay(this Animator animator, string animationName)
        {
            if (!animator)
            {
                Debug.Log("Particle has not been assigned");
                return;
            }

            animator.Play(animationName);
        }

        public static void SafePlay(this Animator animator, int animationHash)
        {
            if (!animator)
            {
                Debug.Log("Particle has not been assigned");
                return;
            }

            animator.Play(animationHash);
        }

        public static float Duration(this Animator animator, string animationName, bool playAnimation = false)
        {
            AnimationClip clip =
                animator.runtimeAnimatorController.animationClips.FirstOrDefault(a => a.name.Equals(animationName));

            if (clip == null)
            {
                return 0.0f;
            }

            if (playAnimation)
            {
                animator.Play(animationName);
            }

            return clip.length;
        }

        public static float Duration(this Animator animator, int animationHash, bool playAnimation = false)
        {
            AnimationClip clip =
                animator.runtimeAnimatorController.animationClips.FirstOrDefault(a =>
                    a.GetHashCode().Equals(animationHash));

            if (clip == null)
            {
                return 0.0f;
            }

            if (playAnimation)
            {
                animator.Play(animationHash);
            }

            return clip.length;
        }

        public static YieldInstruction YieldDuration(this Animator animator, string animationName,
            bool playAnimation = false)
        {
            AnimationClip clip =
                animator.runtimeAnimatorController.animationClips.FirstOrDefault(a => a.name.Equals(animationName));

            if (clip == null)
            {
                return null;
            }

            if (playAnimation)
            {
                animator.Play(animationName);
            }

            return new WaitForSeconds(clip.length);
        }

        public static YieldInstruction YieldDuration(this Animator animator, int animationHash,
            bool playAnimation = false)
        {
            AnimationClip clip =
                animator.runtimeAnimatorController.animationClips.FirstOrDefault(a =>
                    a.GetHashCode().Equals(animationHash));

            if (clip == null)
            {
                return null;
            }

            if (playAnimation)
            {
                animator.Play(animationHash);
            }

            return new WaitForSeconds(clip.length);
        }
    }

    public static class DebugExtensions
    {
        public static void Log(this Component c, string message, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>");
        }

        public static void Log(this Component c, int message, Color color)
        {
            Debug.Log(
                $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message.ToString(CultureInfo.InvariantCulture)}</color>");
        }

        public static void Log(this Component c, float message, Color color)
        {
            Debug.Log(
                $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message.ToString(CultureInfo.InvariantCulture)}</color>");
        }

        public static void Log(this GameObject c, string message, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>");
        }

        public static void Log(this GameObject c, int message, Color color)
        {
            Debug.Log(
                $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message.ToString(CultureInfo.InvariantCulture)}</color>");
        }

        public static void Log(this GameObject c, float message, Color color)
        {
            Debug.Log(
                $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message.ToString(CultureInfo.InvariantCulture)}</color>");
        }

        public static void Log(this float f, string message, Color color)
        {
            Debug.Log(
                $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message} : {f.ToString(CultureInfo.InvariantCulture)}</color>");
        }

        public static void Log(this int i, string message, Color color)
        {
            Debug.Log(
                $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message} : {i.ToString(CultureInfo.InvariantCulture)}</color>");
        }

        public static void Log(this string s, string message, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message} : {s}</color>");
        }
    }

    public static class VectorExtensions
    {
        public static Vector3 Clamp(this  Vector3 val, Vector3 min, Vector3 max)
        {
            Vector3 clampedVec = new Vector3
            {
                x = Mathf.Clamp(val.x, min.x, max.x),
                y = Mathf.Clamp(val.y, min.y, max.y),
                z = Mathf.Clamp(val.z, min.z, max.z)
            };

            return clampedVec;
        }
    }

    public static class ColorExtensions
    {
        public static void ColorToString(this object s, out string colorHtmlString, Color color)
        {
            colorHtmlString = $"#{ColorUtility.ToHtmlStringRGBA(color)}";
        }

        public static bool StringToColor(this object s, string colorHtmlString, out Color color)
        {
            return ColorUtility.TryParseHtmlString(colorHtmlString, out color);
        }
    }

    public static class CameraExtensions
    {
        public static Vector3 GetWorldPositionOnPlane(this Camera camera, Vector3 screenPosition, float z)
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);
            Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
            xy.Raycast(ray, out float distance);
            return ray.GetPoint(distance);
        }

        public static Vector3 GetWorldPositionOnPlane(this Camera camera, Ray ray, float z)
        {
            Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
            xy.Raycast(ray, out float distance);
            return ray.GetPoint(distance);
        }
    }
}