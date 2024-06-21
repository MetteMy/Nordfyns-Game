using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrumentAttack : MonoBehaviour
{
    bool canInteract = false; 
    public GameObject prefab; 
    public Transform bulletTransform;

    private EnemyHealth enemyHealth;

    //public int damage; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
            if (canInteract == true &&  Input.GetMouseButtonDown(0)){
            Debug.Log("MUUUSIIIC!!!"); 
            // canInteract = false; 
            //GameObject shockwave = Instantiate(prefab, this.transform.position, Quaternion.identity);
            enemyHealth = GetComponentInParent<EnemyHealth>();
            enemyHealth.health -= 1; //damage;
           
        }




    }

    void OnTriggerEnter2D(Collider2D other) { 

        if (other.CompareTag("Player")){

            canInteract = true; 
            Debug.Log("can interact true");
            

        }
        Debug.Log("ENTERED");
    }
  void OnTriggerStay2D(Collider2D other) { 

        if (other.CompareTag("Player")){

            canInteract = true; 
            Debug.Log("can interact true");
            

        }
        Debug.Log("ENTERED");
    }
    void OnTriggerExit2D(Collider2D other){
        canInteract = false;
    }


}


