using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{
    /// <summary>
    /// A super simple 'bullet' behavior that will move this object
    /// in its forward direction at a given speed
    /// </summary>
    /// <author>Ben Hoffman</author>
    public class Bullet_Movement : MonoBehaviour
    {
        /// <summary>
        /// Speed at which this bullet will move
        /// </summary>
        [Tooltip("Speed at which this bullet will move")]
        public float speed = 5.0f;

        void Update()
        {
            // Calculate this bullet's movement
            Vector3 moveDir = transform.forward * speed * Time.deltaTime;
            // Update the current position
            transform.position = transform.position + moveDir;
        }
    }
}