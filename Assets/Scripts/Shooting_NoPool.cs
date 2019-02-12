using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShootBullet();
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
