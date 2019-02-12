using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{
    /// <summary>
    /// A simple object pool to use for objects that will be spawned and 
    /// can be reused, like bullets, item drops, etc. 
    /// 
    /// This can obviously be improved in a lot of ways, but it is a 
    /// starting point. 
    /// </summary>
    /// <author>Ben Hoffman</author>
    public class ObjectPool
    {
        /// <summary>
        /// The person prefab object that will be spawned at random
        /// </summary>
        private readonly GameObject PooledObj_Prefab;

        /// <summary>
        /// How many of these objects to instantiate on start
        /// </summary>
        private readonly int PooledAmount = 20;


        private List<GameObject> m_ObjectList;

        public ObjectPool(GameObject aBulletPrefab, int aPooledAmount)
        {
            this.PooledObj_Prefab = aBulletPrefab;
            this.PooledAmount = aPooledAmount;

            m_ObjectList = new List<GameObject>();

            for (int i = 0; i < PooledAmount; i++)
            {
                // Instantiate the pooled object and add it to our list
                m_ObjectList.Add(GameObject.Instantiate(PooledObj_Prefab));
                // Set it as INACTIVE
                m_ObjectList[i].SetActive(false);
            }
        }

        /// <summary>
        /// Loop through our list until we find an inactive object,
        /// when we find an active one return it. If there are no active objects in the 
        /// pool, then instantiate a new one
        /// </summary>
        /// <returns>One of the pooled objects</returns>
        public GameObject GetPooledObject()
        {
            // Loop through our known array
            for (int i = 0; i < m_ObjectList.Count; ++i)
            {
                // If the object at this spot is INACTIVE
                if (!m_ObjectList[i].activeInHierarchy)
                {
                    // Activate it in the hierarchy
                    m_ObjectList[i].SetActive(true);

                    // Return it
                    return m_ObjectList[i];
                }
            }

            return null;
        }
    }

}   // namespace Completed