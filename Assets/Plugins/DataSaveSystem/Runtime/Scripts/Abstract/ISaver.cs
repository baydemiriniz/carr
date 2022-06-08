using UnityEngine;

namespace DataSave
{
	public interface ISaver<T> where T : IData, new()
	{
		string EditorSavePath { get; }
		string BuildSavePath { get; }

		string GetPath();
		
		void Save(T data);
		T Load();
		void Delete();
	}
}
