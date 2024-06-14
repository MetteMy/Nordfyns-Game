using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, Wave, FollowPlayer }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [Header("Wave Attributes")]
    [SerializeField] private int bulletsInWave = 5;
    [SerializeField] private float angleSpread = 45f;

    [Header("Direction Attributes")]
    public Vector2 fireDirection = Vector2.right;


    private GameObject spawnedBullet;
    private float timer = 0f;

    public GameObject SpawnedBullet { get => spawnedBullet; set => spawnedBullet = value; }


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
            if (spawnerType == SpawnerType.Wave)
            {
                FireWave();
            }
            else if (spawnerType == SpawnerType.FollowPlayer){
                FireAtPlayer();
            }
            else
            {
                FireSingle();
            }
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }


        // if (bullet)
        // {
        //     spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        //     spawnedBullet.GetComponent<Lærkebullet>().speed = speed;
        //     spawnedBullet.GetComponent<Lærkebullet>().bulletLife = bulletLife;

        //     spawnedBullet.transform.rotation = transform.rotation;
        // }
    }


    private void FireSingle()
    {
        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, fireDirection);
        // GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        // spawnedBullet.GetComponent<Lærkebullet>().speed = speed;
        // spawnedBullet.GetComponent<Lærkebullet>().bulletLife = bulletLife;
        //spawnedBullet.transform.rotation = transform.rotation;

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
        
    

    private void FireWave()
    {
        float angleStep = angleSpread / (bulletsInWave - 1);
        float startingAngle = transform.eulerAngles.z - angleSpread / 2;

        for (int i = 0; i < bulletsInWave; i++)
        {
            float angle = startingAngle + (angleStep * i);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * fireDirection;
            Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, direction);
            //Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            GameObject spawnedBullet = Instantiate(bullet, transform.position, bulletRotation);
            spawnedBullet.GetComponent<Lærkebullet>().speed = speed;
            spawnedBullet.GetComponent<Lærkebullet>().bulletLife = bulletLife;

        }
    }

        private void FireAtPlayer()
    {
        GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        enemyBulletScript enemyBullet = spawnedBullet.GetComponent<enemyBulletScript>();
        enemyBullet.force = speed;
        
    }
}
