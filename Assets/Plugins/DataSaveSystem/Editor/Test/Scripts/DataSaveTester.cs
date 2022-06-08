using NUnit.Framework;
using UnityEngine;

namespace Test
{
    public static class DataSaveTester
    {
        [Test]
        public static void Save_Test()
        {
            TestData data = new TestData {level = 123};

            DataControl.Instance.data = data;
            DataControl.Instance.Save();
        }

        [Test]
        public static void Load_Test()
        {
            TestData data = new TestData {level = 123};

            DataControl.Instance.Load();

            Assert.True(data.level == DataControl.Instance.data.level);
            Debug.Log($"Coin: {data.coin}");
            Debug.Log($"Level: {data.level}");
        }
        
        [Test]
        public static void Save_Concurrent_Test()
        {
            TestData data = new TestData {level = 124};

            DataControl.Instance.data = data;
            DataControl.Instance.SaveConcurrent();
        }

        [Test]
        public static void Load_Concurrent_Test()
        {
            TestData data = new TestData {level = 124};

            DataControl.Instance.LoadConcurrent();

            Assert.True(data.level == DataControl.Instance.data.level);
            Debug.Log($"Coin: {DataControl.Instance.data.coin}");
            Debug.Log($"Level: {DataControl.Instance.data.level}");
        }
        
        [Test]
        public static void Load_ChangeCoin25_Save_Test()
        {
            DataControl.Instance.Load();
            DataControl.Instance.data.coin += 25;
            DataControl.Instance.Save();
        }

        [Test]
        public static void Load_ChangedCoin_Test()
        {
            DataControl.Instance.Load();
            Assert.True(DataControl.Instance.data.coin == 25);
        }
    }
}