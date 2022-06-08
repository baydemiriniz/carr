using System;
using System.IO;
using UnityEngine;

namespace DataSave
{
    public class JsonSaver<T> : ISaver<T> where T : IData, new()
    {
        public string EditorSavePath { get; } = "Assets/data.json";
        public string BuildSavePath { get; } = $"{Application.persistentDataPath}/data.json";
     
        public string GetPath() => Application.isEditor ? EditorSavePath : BuildSavePath;

        public void Save(T data)
        {
            if (data == null)
                throw new NullReferenceException("Data cannot be null");

            string json;
            try
            {
                json = JsonUtility.ToJson(data);
            }
            catch (Exception e)
            {
                Debug.LogError($"Deserialization failed due to: {e.Message}");
                throw;
            }

            try
            {
                File.WriteAllText(GetPath(), json);
            }
            catch (Exception e)
            {
                Debug.LogError($"File save failed due to: {e.Message}");
                throw;
            }
        }

        public T Load()
        {
            string path = GetPath();

            T data = new T();
            if (!File.Exists(path))
            {
                data.Init();
                Save(data);

                return data;
            }

            string json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Debug.LogError($"Couldn't read data from {path} due to: {e.Message}");
                throw;
            }

            try
            {
                data = JsonUtility.FromJson<T>(json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Deserialization failed due to: {e.Message}");
                throw;
            }

            return data;
        }

        public void Delete()
        {
            if (!File.Exists(GetPath()))
                return;

            File.Delete(GetPath());
        }
    }
}