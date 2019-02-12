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
    public class ObjectPool : MonoBehaviour
    {
        /// <summary>
        /// The person prefab object that will be spawned at random
        /// </summary>
        [Tooltip("The person prefab object that will be spawned at random")]
        public GameObject PooledObj_Prefab;

        /// <summary>
        /// How many of these objects to instantiate on start
        /// </summary>
        [Tooltip("How many of these objects to instantiate on start")]
        public int PooledAmount = 20;

        /// <summary>
        /// If we need more then the initial pooled amount, then this will instantiate a new object
        /// </summary>
        [Tooltip("If we need more then the initial pooled amount, then this will instantiate a new object")]
        public bool WillGrow = true;

        private List<GameObject> m_ObjectList;

        private void Start()
        {
            m_ObjectList = new List<GameObject>();

            for (int i = 0; i < PooledAmount; i++)
            {
                // Instantiate the pooled object and add it to our list
                m_ObjectList.Add(Instantiate(PooledObj_Prefab));
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

            // return an instantiate pooled object
            GameObject temp = Instantiate(PooledObj_Prefab);
            // Add it to our object pooled
            m_ObjectList.Add(temp);
            // Return it
            return temp;
        }
    }

}   // namespace Completed