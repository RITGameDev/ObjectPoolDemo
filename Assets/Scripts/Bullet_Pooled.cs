using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{
    /// <summary>
    /// A bullet that can be used in an object pool
    /// </summary>
    public class Bullet_Pooled : MonoBehaviour
    {
        /// <summary>
        /// The lifetime of this bullet
        /// </summary>
        public float Lifetime = 2.0f;

        private void OnEnable()
        {
            // Invoke the ReturnToPool method after <Lifetime> seconds
            Invoke("ReturnToPool", Lifetime);
        }

        void ReturnToPool()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            // Clean up any lingering after this object is returned to pool
            CancelInvoke();
        }
    }
}