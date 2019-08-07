using UnityEngine;
using System.Collections.Generic;

namespace Boris.Game
{

    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
        public bool shouldExpand;
    }

    public class PoolManager : MonoBehaviour
    {
        public static PoolManager SharedInstance;
        public List<ObjectPoolItem> itemsToPool;
        public List<GameObject> pooledObjects;

        void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            pooledObjects = new List<GameObject>();

            foreach (ObjectPoolItem item in itemsToPool)
            {
                for (int i = 0; i < item.amountToPool; i++)
                {
                    GameObject obj = (GameObject) Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }
            }
        }

        public GameObject GetPooledObject(string tag)
        {
            foreach (var t in pooledObjects)
            {
                if (!t.activeInHierarchy && t.tag == tag)
                {
                    return t;
                }
            }

            foreach (ObjectPoolItem item in itemsToPool)
            {
                if (item.objectToPool.tag == tag)
                {
                    if (item.shouldExpand)
                    {
                        GameObject obj = (GameObject) Instantiate(item.objectToPool);
                        obj.SetActive(false);
                        pooledObjects.Add(obj);
                        return obj;
                    }
                }
            }

            return null;
        }

        void Update()
        {

        }
    }
}