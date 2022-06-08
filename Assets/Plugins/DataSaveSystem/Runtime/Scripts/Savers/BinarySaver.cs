using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DataSave
{
    public class BinarySaver<T> : ISaver<T> where T : IData, new()
    {
        public string EditorSavePath { get; } = "Assets/data.bin";
        public string BuildSavePath { get; } = $"{Application.persistentDataPath}/data.bin";

        public string GetPath() => Application.isEditor ? EditorSavePath : BuildSavePath;

        public void Save(T data)
        {
            if (data == null)
                throw new NullReferenceException("Data cannot be null");

            FileStream fileStream = new FileStream(GetPath(), FileMode.OpenOrCreate);

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                binaryFormatter.Serialize(fileStream, data);
            }
            catch (Exception e)
            {
                Debug.LogError($"Serialization failed due to: {e.Message}");
                throw;
            }
            finally
            {
                fileStream.Close();
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

            FileStream fileStream = new FileStream(path, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception e)
            {
                Debug.LogError($"Deserialization failed due to: {e.Message}");
                throw;
            }
            finally
            {
                fileStream.Close();
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