using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{

    /// <summary>
    /// A simple example of how to spawn a bullet 
    /// </summary>
    public class Shooting_NoPool : MonoBehaviour
    {

        /// <summary>
        /// Where the bullet should be spawned
        /// </summary>
        public Transform BulletBarrel;

        /// <summary>
        /// The prefab to use as our bullet
        /// </summary>
        public GameObject Bullet_Prefab;

        public float MinSpawnDelay = 0.5f;

        private float TimeSinceLastSpawn;

        void Update()
        {
            TimeSinceLastSpawn += Time.deltaTime;

            if (Input.GetKey(KeyCode.Space) && TimeSinceLastSpawn >= MinSpawnDelay)
            {
                ShootBullet();
                TimeSinceLastSpawn = 0.0f;
            }
        }

        /// <summary>
        /// Spawn a new bullet dynamically at runtime at the barrel position
        /// </summary>
        void ShootBullet()
        {
            // Creates a new instance of a bullet at run time 
            Instantiate(Bullet_Prefab, BulletBarrel.position, BulletBarrel.rotation);
        }
    }
}