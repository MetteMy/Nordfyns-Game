using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, Wave }


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

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
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
            else
            {
                FireSingle();
            }
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
        GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        spawnedBullet.GetComponent<Lærkebullet>().speed = speed;
        spawnedBullet.GetComponent<Lærkebullet>().bulletLife = bulletLife;
        //spawnedBullet.transform.rotation = transform.rotation;
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
}
