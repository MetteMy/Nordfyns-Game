using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;


    // Start is called before the first frame update
    void Start()
    {
        //health = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

       
        if (other.CompareTag("enemybullet"))
        {
            health -= 1.0f;
            Debug.Log("liv reduceret");
        }
    }

}