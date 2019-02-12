using UnityEngine;

/// <summary>
/// Example of a non-pooled bullet object that is spawned and then deestroyed
/// after a lifetime. 
/// </summary>
public class BulletLifetime_NonPooled : MonoBehaviour
{
    /// <summary>
    /// How long this bullet will be alive before it gets 
    /// destroyed
    /// </summary>
    public float Lifetime = 2.0f;

    private void Start()
    {
        // Destroy this bullet after 2 seconds
        Destroy(this.gameObject, Lifetime);
    }
}
