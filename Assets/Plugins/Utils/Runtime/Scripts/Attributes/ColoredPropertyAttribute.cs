using UnityEngine;

namespace Extensions
{
    public class ColoredPropertyAttribute : PropertyAttribute
    {
        public float r;
        public float g;
        public float b;
        public bool isBackground;

        public ColoredPropertyAttribute(float r, float g, float b, bool isBackground)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.isBackground = isBackground;
        }
    }
}