using System.Threading;
using UnityEngine;

namespace DataSave
{
    public class DataManager<T> where T : IData, new()
    {
        #region Singleton

        private static DataManager<T> instance = null;

        public static DataManager<T> Instance
            => instance ?? (instance = new DataManager<T>());

        private DataManager() { }

        #endregion Singleton

        private ISaver<T> dataSaver;
        private bool isInitialized;

        public void Initialize(SaveType saveType)
        {
            if (isInitialized)
            {
                Debug.Log("DataManager is already initialized.");
                return;
            }

            isInitialized = true;
            InitSaver(saveType);
        }

        public void ForceInitialize(SaveType saveType)
        {
            InitSaver(saveType);
        }
        
        private void InitSaver(SaveType saveType)
        {
            switch (saveType)
            {
                case SaveType.Binary:
                    dataSaver = new BinarySaver<T>();
                    break;
                case SaveType.Json:
                    dataSaver = new JsonSaver<T>();
                    break;
            }
        }

        /// <summary>
        /// Saves given parameter with initialized save type
        /// </summary>
        /// <param name="data"> Data to save</param>
        public void Save(T data)
        {
            InitializationCheck();

            dataSaver.Save(data);
        }

        /// <summary>
        /// Loads saved with initialized save type
        /// </summary>
        /// <returns>Loaded data saved in disk</returns>
        public T Load()
        {
            InitializationCheck();

            return dataSaver.Load();
        }

        /// <summary>
        /// Delete saved data
        /// </summary>
        public void Delete()
        {
            InitializationCheck();

            dataSaver.Delete();
        }

        /// <summary>
        /// Saves given parameter with initialized save type on a new thread
        /// </summary>
        /// <param name="data"> Data to save</param>
        public void SaveConcurrent(T data)
        {
            InitializationCheck();

            void SaveThreadStart() => dataSaver.Save(data);
            Thread saveThread = new Thread(SaveThreadStart);
            saveThread.Start();
            saveThread.Join();
        }

        /// <summary>
        /// Loads saved with initialized save type on a new thread
        /// </summary>
        /// <returns>Loaded data saved in disk</returns>
        public T LoadConcurrent()
        {
            InitializationCheck();

            T data = new T();

            void LoadThreadStart()
            {
                data = dataSaver.Load();
            }

            Thread loadThread = new Thread(LoadThreadStart);
            loadThread.Start();
            loadThread.Join();
            
            return data;
        }
        
        private void InitializationCheck()
        {
            if (isInitialized)
                return;

            Debug.Log("DataManager is not initialized, initializing with Json save type");

            Initialize(SaveType.Json);
        }
    }

    public enum SaveType
    {
        Binary,
        Json
    }
}