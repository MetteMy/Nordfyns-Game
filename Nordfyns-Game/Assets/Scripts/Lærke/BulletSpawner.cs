using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
            if (spawnedBullet != null)
            {
                var lærkebullet = spawnedBullet.GetComponent<Lærkebullet>();
                if (lærkebullet != null)
                {
                    lærkebullet.speed = speed;
                    lærkebullet.bulletLife = bulletLife;
                }
                else
                {
                    var bombSpawnerBullet = spawnedBullet.GetComponent<BombSpawnerBullet>();
                    if (bombSpawnerBullet != null)
                    {
                        bombSpawnerBullet.speed = speed;
                        bombSpawnerBullet.bulletLife = bulletLife;
                    }
                    else
                    {
                        Debug.LogWarning("Spawned bullet does not have Lærkebullet or BombSpawnerBullet component.");
                    }
                }
            }
            else
            {
                Debug.LogError("Failed to instantiate bullet.");
            }
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }
    }
}
