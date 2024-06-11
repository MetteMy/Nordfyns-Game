using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawnerBullet : MonoBehaviour
{
    public float bulletLife = 2f;  // Defines how long before the bullet is destroyed
    public float speed = 1f;
    public float bombSpawnInterval = 4f;  // Time between each bomb spawn
    public GameObject bombPrefab;  // Reference to the bomb prefab

    private Vector2 spawnPoint;
    private float timer = 0f;
    private float bombSpawnTimer = 0f;

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (timer > bulletLife)
        {
            Destroy(this.gameObject);
        }

        timer += Time.deltaTime;
        bombSpawnTimer += Time.deltaTime;

        transform.position = Movement(timer);

        if (bombSpawnTimer >= bombSpawnInterval)
        {
            SpawnBomb();
            bombSpawnTimer = 0f;
        }
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

    private void SpawnBomb()
    {
        if (bombPrefab)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }
}
