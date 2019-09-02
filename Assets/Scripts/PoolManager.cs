using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Boris.Game
{
    public class PoolManager : MonoBehaviour
    {
        public Dictionary<string,Stack<GameObject>> itemsToPool = new Dictionary<string, Stack<GameObject>>();
        //public Dictionary<string,List<GameObject>> itemsNotInPool = new Dictionary<string, List<GameObject>>();
        [SerializeField] private GameObject explodeParticle;
        [SerializeField] private GameObject self;

        void Awake()
        {
            self = gameObject;
            InitPool(explodeParticle, 6);
        }

        public void InitPool(GameObject poolName, int amount)
        {
            var poolParent = new GameObject(poolName.name);

            poolParent.transform.SetParent(self.transform);
            
            itemsToPool.Add(poolName.name, new Stack<GameObject>());
            //itemsNotInPool.Add(poolName.name, new List<GameObject>());

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
            //itemsNotInPool[poolName].Add(obj);
            return obj;
        }

        public void ReturnPooledObject(GameObject poolName)
        {
            poolName.gameObject.SetActive(false);
            itemsToPool[poolName.name].Push(poolName);
            //itemsNotInPool[poolName.name].Remove(poolName);
        }

        public void ResetPools()
        {
            itemsToPool = new Dictionary<string, Stack<GameObject>>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            InitPool(explodeParticle, 6);
        }
    }
}