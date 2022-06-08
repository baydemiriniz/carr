using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPooling : ObjectPoolingBase
{
    [SerializeField, FormerlySerializedAs("RegistreOnStart")]
    private PreRegister[] pooledPrefabs;

    private Dictionary<string, PoolObject> pools = new Dictionary<string, PoolObject>();

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < pooledPrefabs.Length; i++)
        {
            RegisterObject(pooledPrefabs[i].Name, pooledPrefabs[i].Prefab, pooledPrefabs[i].Lenght);
        }
    }

    public void RegisterObject(string poolName, GameObject prefab, int count)
    {
        if (prefab == null)
        {
            return;
        }

        var p = new PoolObject();
        p.Name = poolName;
        p.Prefab = prefab;
        GameObject g;
        p.PoolList = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            g = Instantiate(prefab, transform) as GameObject;
            p.PoolList[i] = g;
            g.SetActive(false);
        }
        pools.Add(poolName, p);
    }

    public override GameObject Instantiate(string objectName, Vector3 position, Quaternion rotation)
    {
        PoolObject pool = pools[objectName];
        if (pool != null)
        {
            GameObject g = pool.GetCurrent();
            if (g == null)
            {
                g = Instantiate(pool.Prefab, transform);
                pool.ReplaceCurrent(g);
            }
            g.transform.SetPositionAndRotation(position, rotation);
            g.SetActive(true);
            pool.SetNext();
            return g;
        }
        else
        {
            Debug.LogError(string.Format("{0} pool listesinde yok", objectName));
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PoolObject
    {
        public string Name;
        public GameObject Prefab;
        public GameObject[] PoolList;
        public int CurrentPool;

        public GameObject GetCurrent() => PoolList[CurrentPool];
        public void SetNext() { CurrentPool = (CurrentPool + 1) % PoolList.Length; }
        public void ReplaceCurrent(GameObject g) => PoolList[CurrentPool] = g;
    }

    [Serializable]
    public class PreRegister
    {
        public string Name;
        public GameObject Prefab;
        public int Lenght;
    }
}