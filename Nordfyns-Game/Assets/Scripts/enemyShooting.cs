using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    public GameObject prefab;
    public Transform bulletTransform;
    private Camera mainCam;
    private Vector2 playerPos;
    private float period = 0.0f;
    public float shootingInterval; 
    //public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (period > shootingInterval)
        {
            Instantiate(prefab, bulletTransform.position, Quaternion.identity);
            period = 0;
        }
        period += Time.deltaTime;

    }




}

