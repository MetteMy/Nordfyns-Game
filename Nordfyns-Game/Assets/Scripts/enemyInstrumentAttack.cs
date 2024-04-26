using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInstrumentAttack : MonoBehaviour
{
 
    public GameObject prefab; 
    public Transform bulletTransform;
    
    public float shootingInterval; 

    private float period = 0.0f;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (period > shootingInterval)
        {
            GameObject shockwave = Instantiate(prefab, this.transform.position, Quaternion.identity);
            period = 0;
        }
        period += Time.deltaTime;
            

           
        }




    }

    // void OnTriggerEnter2D(Collider2D other) { 

    //     if (other.CompareTag("enemy")){

    //         canInteract = true; 
            
            

    //     }
    //     Debug.Log("ENTERED");
    // }

    // void OnTriggerExit2D(Collider2D other){
    //     canInteract = false;
    // }





