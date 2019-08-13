using UnityEngine;
using System.Collections.Generic;

namespace Boris.Game
{
    public class PoolManager : MonoBehaviour
    {
        public Dictionary<string,Stack<GameObject>> itemsToPool = new Dictionary<string, Stack<GameObject>>();
        [SerializeField] private GameObject explodeParticle;

        void Awake()
        {
            InitPool(explodeParticle, 6);
        }

        public void InitPool(GameObject poolName, int amount)
        {
            var poolParent = new GameObject(poolName.name);
            poolParent.transform.SetParent(transform);
            
            itemsToPool.Add(poolName.name, new Stack<GameObject>());
            
            for (int i = 0; i < amount; i++)
            {
                var obj = Instantiate(poolName, poolParent.transform);
                obj.name = poolName.name;
                obj.gameObject.SetActive(false);
                
                itemsToPool[poolName.name].Push(obj);
            }
        }
        
        public GameObject GetPooledObject(string poolName)
        {
            var obj = itemsToPool[poolName].Pop();
            return obj;
        }

        public void ReturnPooledObject(GameObject poolName)
        {
            poolName.gameObject.SetActive(false);
            itemsToPool[poolName.name].Push(poolName);
        }
    }
}