using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting_Pooled : MonoBehaviour
{
    [Tooltip("The person prefab object that will be spawned at random")]
    public GameObject BulletPrefab;

    [Tooltip("Where to spawn the new bullet")]
    public Transform BulletSpawn;

    public Completed.ObjectPool BulletPool = null;

    public int PoolSize = 10;

    public float MinSpawnDelay = 0.5f;

    private float TimeSinceLastSpawn;

    private void Start()
    {
        TimeSinceLastSpawn = MinSpawnDelay;
        BulletPool = new Completed.ObjectPool(BulletPrefab, PoolSize);
    }

    private void Update()
    {

        TimeSinceLastSpawn += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && TimeSinceLastSpawn >= MinSpawnDelay)
        {
            ShootBullet();
            TimeSinceLastSpawn = 0.0f;
        }
    }

    /// <summary>
    /// Shoot a bullet by getting it from the pool
    /// </summary>
    private void ShootBullet()
    {
        GameObject bullet = BulletPool.GetPooledObject();
        if (bullet == null) return;
        bullet.transform.position = BulletSpawn.position;
        bullet.transform.rotation= BulletSpawn.rotation;
    }
}
