using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float detonationTime = 1f;  // Time before the bomb detonates
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public int bulletCount = 4;  // Number of bullets to shoot out
    public float bulletSpeed = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= detonationTime)
        {
            Detonate();
        }
    }

    private void Detonate()
    {
        // Spawn bullets in a circular pattern
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
            SpawnBullet(direction, angle);
        }

        // Destroy the bomb after detonation
        Destroy(gameObject);
    }

    private void SpawnBullet(Vector3 direction, float angle)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw the explosion radius in the editor for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f); // Adjust radius for visualization
    }
}
