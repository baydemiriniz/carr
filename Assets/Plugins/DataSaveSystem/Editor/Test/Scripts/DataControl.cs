using DataSave;

namespace Test
{
    public class DataControl
    {
        #region Singleton

        private static DataControl instance = null;

        public static DataControl Instance
            => instance ?? (instance = new DataControl());

        private DataControl()
        {
            DataManager<TestData>.Instance.Initialize(SaveType.Json);
        }
        #endregion Singleton

        
        public TestData data;

        public void Save()
        {
            DataManager<TestData>.Instance.Save(data);
        }
        
        public void Load()
        {
            data = DataManager<TestData>.Instance.Load();
        }
        
        public void SaveConcurrent()
        {
            DataManager<TestData>.Instance.SaveConcurrent(data);
        }
        
        public void LoadConcurrent()
        {
            data = DataManager<TestData>.Instance.LoadConcurrent();
        }
    }
}