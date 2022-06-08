namespace Extensions
{
	[System.Serializable]
	public abstract class BaseRangeData<T>
	{
		public T min;
		public T max;

		/// <summary>
		/// returns lerp a value between min-max about lerpTime  
		/// </summary>
		/// <param name="time">time for lerp operation should range [0.0, 1.0]</param>
		/// <returns>float</returns>
		public abstract T Get(float time);
		
		/// <summary>
		/// Returns a random value between min-max
		/// </summary>
		/// <returns>float</returns>
		public abstract T Get();

		/// <summary>
		/// Returns a clamped value between min-max
		/// </summary>
		/// <param name="val">value to clam</param>
		/// <returns>float</returns>
		public abstract T Clamp(T val);
		
		/// <summary>
		/// Clamps referenced value between min-max
		/// </summary>
		/// <param name="val">value to clam</param>
		public abstract void Clamp(ref T val);
	}
}
